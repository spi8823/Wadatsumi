using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Wadatsumi.Data.Cod
{
    public record MatchResult(
        int ID, 
        string MatchID, 
        DateTime StartTime, 
        DateTime EndTime, 
        Map Map, 
        Mode Mode, 
        Result Result, 
        int KillCount, 
        int EliminateCount, 
        int DeathCount, 
        int Score)
    {
        public double KillDeathRatio => (double)KillCount / DeathCount;
        public TimeSpan MatchTime => EndTime - StartTime;
        public double TimeScore => (double)Score / MatchTime.Minutes;
        
        public static MatchResult Create(int id, string matchID, long starttime, long endtime, string map, string mode, string result, int kills, int eliminates, int deaths, int score)
        {
            return new MatchResult(
                id,
                matchID,
                DateTime.UnixEpoch + TimeSpan.FromSeconds(starttime),
                DateTime.UnixEpoch + TimeSpan.FromSeconds(endtime),
                EnumHelper.GetMap(map),
                EnumHelper.GetMode(mode),
                EnumHelper.GetResult(result),
                kills,
                eliminates,
                deaths,
                score);
        }
    }

    public class MatchResultService
    {
        private const string DatabaseFilePath = "wwwroot/cod/codbocw.db";
        private const string TableName = "match_results";
        private readonly static Dictionary<string, string> ColumnNames = new Dictionary<string, string>()
        {
            { nameof(MatchResult.ID), "id" },
            { nameof(MatchResult.MatchID), "matchID" },
            { nameof(MatchResult.StartTime), "start_time" },
            { nameof(MatchResult.EndTime), "end_time" },
            { nameof(MatchResult.Map), "map" },
            { nameof(MatchResult.Mode), "mode" },
            { nameof(MatchResult.Result), "result" },
            { nameof(MatchResult.KillCount), "kills" },
            { nameof(MatchResult.EliminateCount), "eliminates" },
            { nameof(MatchResult.DeathCount), "deaths" },
            { nameof(MatchResult.Score), "score" }
        };

        private SQLiteConnection connection { get; }
        public MatchResultService()
        {
            connection = new SQLiteConnection();
            connection.ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = DatabaseFilePath,
            }.ToString();
            connection.Open();
        }

        public IEnumerable<MatchResult> GetAll()
        {
            var command = new SQLiteCommand()
            {
                Connection = connection,
                CommandText = $"select * from {TableName}",
            };

            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
                yield break;

            while (reader.Read())
            {
                int column = 0;
                yield return MatchResult.Create(
                    (int)(long)reader.GetValue(column),
                    (string)reader.GetValue(++column),
                    (long)reader.GetValue(++column),
                    (long)reader.GetValue(++column),
                    (string)reader.GetValue(++column),
                    (string)reader.GetValue(++column),
                    (string)reader.GetValue(++column),
                    (int)(long)reader.GetValue(++column),
                    (int)(long)reader.GetValue(++column),
                    (int)(long)reader.GetValue(++column),
                    (int)(long)reader.GetValue(++column));
            }
        }
    }
}
