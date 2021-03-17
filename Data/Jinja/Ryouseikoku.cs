using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wadatsumi.Data.Jinja
{
    public class Ryouseikoku
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Region Region { get; set; }
    }

    public class Region
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
