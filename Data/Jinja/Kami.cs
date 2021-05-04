using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wadatsumi.Jinja.Data
{
    public class Kami
    {
        public int ID { get; set; }
        public virtual ICollection<Shinmei> ShinmeiList { get; set; }
        public virtual ICollection<Theory> TheoryList { get; set; }
    }

    public class Shinmei
    {
        public int ID { get; set; }
        public virtual Kami Kami { get; set; }
        public string Name { get; set; }
        public string Kana { get; set; }

        public Shinmei() { }

        public Shinmei(string name, string kana)
        {
            Name = name;
            Kana = kana;
        }
    }
}
