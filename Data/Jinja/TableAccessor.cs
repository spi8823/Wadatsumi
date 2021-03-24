using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;
using System.Data.SQLite;

namespace Wadatsumi.Jinja.Data
{
    public class TableAccessor<T> where T : struct
    {
        private SQLiteConnection Connection { get; }
        private string TableName { get; }
        private (PropertyInfo property, ColumnAttribute attribute)[] ColumnDatas { get; }

        public TableAccessor(SQLiteConnection connection)
        {
            var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
            if (attribute is not TableAttribute tableAttribute)
                throw new Exception();

            Connection = connection;
            TableName = tableAttribute.Name;
            ColumnDatas = GetColumnProperties();
        }

        public (PropertyInfo, ColumnAttribute)[] GetColumnProperties()
        {
            var columns = from info in typeof(T).GetProperties()
                          let columnAttribute = Attribute.GetCustomAttribute(info, typeof(ColumnAttribute)) as ColumnAttribute
                          where columnAttribute is not null
                          orderby columnAttribute.Index
                          select (info, columnAttribute);

            return columns.ToArray();
        }

        private object GetPropertyValue(SQLiteDataReader reader, PropertyInfo propertyInfo, ColumnAttribute columnAttribute)
        {
            var value = reader.GetValue(columnAttribute.Index);
            var type = propertyInfo.PropertyType;

            if (type == typeof(int) || type == typeof(float) || type == typeof(double) || type == typeof(string))
            {
                return value;
            }
            else
            {
                var json = (string)value;
                return JsonSerializer.Deserialize(json, type);
            }
        }

        public IEnumerable<T> GetDataSimpleWhere(string propertyName, object propertyValue)
        {
            var columnData = ColumnDatas.First(cd => cd.property.Name == propertyName);

            var command = new SQLiteCommand()
            {
                Connection = Connection,
                CommandText = $"select * from {TableName} where {columnData.attribute.Name} = {PropertyValueToQueryParam(propertyValue, columnData.property)}",
            };

            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
                yield break;

            while (reader.Read())
            {
                yield return GetDataFromReader(reader);
            }
        }

        public IEnumerable<T> GetDatas()
        {
            var command = new SQLiteCommand()
            {
                Connection = Connection,
                CommandText = $"select * from {TableName}"
            };
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
                yield break;

            while (reader.Read())
            {
                yield return GetDataFromReader(reader);
            }
        }

        private T GetDataFromReader(SQLiteDataReader reader)
        {
            var data = default(T);
            foreach (var columnData in ColumnDatas)
            {
                columnData.property.SetValue(data, GetPropertyValue(reader, columnData.property, columnData.attribute));
            }
            return data;
        }

        private string PropertyToQueryParam(T data, PropertyInfo info)
        {
            return PropertyValueToQueryParam(info.GetValue(data), info);
        }

        private string PropertyValueToQueryParam(object propertyValue, PropertyInfo info)
        {
            var type = info.PropertyType;
            if (type == typeof(int) || type == typeof(float) || type == typeof(double))
            {
                return info.GetValue(propertyValue).ToString();
            }
            else if (type == typeof(string))
            {
                return $"\'{propertyValue}\'";
            }
            else
            {
                return $"\'{JsonSerializer.Serialize(propertyValue)}\'";
            }
        }

        public void SetData(int key, T data)
        {
            //name = valueの形の文字列リスト
            var columnvalues = from cd in ColumnDatas where !cd.attribute.IsPrimaryKey select $"{cd.attribute.Name} = {PropertyToQueryParam(data, cd.property)}";

            var command = new SQLiteCommand()
            {
                Connection = Connection,
                CommandText = $"update {TableName} set {string.Join(',', columnvalues)}"
            };
            command.ExecuteNonQuery();
        }

        public void InsertData(T data)
        {
            var columns = from cd in ColumnDatas
                          where !cd.attribute.IsPrimaryKey
                          orderby cd.attribute.Index
                          select cd.attribute.Name;

            var values = from cd in ColumnDatas
                         where !cd.attribute.IsPrimaryKey
                         orderby cd.attribute.Index
                         select PropertyToQueryParam(data, cd.property);

            var command = new SQLiteCommand()
            {
                Connection = Connection,
                CommandText = $"insert into {TableName} ({string.Join(',', columns)}) values ({string.Join(',', values)})"
            };
        }
    }

    /// <summary>
    /// データベースのテーブルに格納される構造体
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }
        public TableAttribute(string name) { Name = name; }
    }

    /// <summary>
    /// データベースのカラムとなるメンバ変数
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public int Index { get; }
        public string Name { get; }
        public bool IsPrimaryKey { get; }
        public ColumnAttribute(int index, string name, bool isPrimaryKey = false) { Index = index; Name = name; IsPrimaryKey = isPrimaryKey; }
    }
}
