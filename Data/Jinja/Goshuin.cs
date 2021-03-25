using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Wadatsumi.Jinja.Data
{
    public class Goshuin
    {
        public int ID { get; set; }
        public virtual Jinja Jinja { get; set; }
        public DateTime VisitDate { get; set; }
        public string LoadTravelogue()
        {
            var filepath = PathDefine.GetGoshuinTraveloguePath(ID);
            if (System.IO.File.Exists(filepath))
                return File.ReadAllText(PathDefine.GetGoshuinTraveloguePath(ID));
            else
                return "";
        }

        public void SaveTravelogue(string content)
        {
            var filepath = PathDefine.GetGoshuinTraveloguePath(ID);
            if (!File.Exists(filepath))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            File.WriteAllText(filepath, content, System.Text.Encoding.UTF8);
        }
    }
}
