using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Wadatsumi.Jinja.Data
{
    public class Jinja
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Kana { get; set; }
        public virtual Location Location { get; set; }
        public virtual Ryouseikoku Ryouseikoku { get; set; }
        public virtual List<Saijin> SaijinList { get; set; }
    }

    public class Saijin
    {
        public int ID { get; set; }
        public virtual Jinja Jinja { get; set; }
        public virtual Kami Kami { get; set; }
    }
}
