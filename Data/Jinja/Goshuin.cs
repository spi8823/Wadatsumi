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
            return PathDefine.LoadFile(filepath);
        }

        public void SaveTravelogue(string content)
        {
            var filepath = PathDefine.GetGoshuinTraveloguePath(ID);
            PathDefine.SaveFile(filepath, content);
        }
    }
}
