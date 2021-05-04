using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wadatsumi.Jinja.Data
{
    public class Theory
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<TheoryRelation> ReferenceList { get; set; }

        public string LoadArticle() => PathDefine.LoadFile(PathDefine.GetTheoryArticlePath(ID));
        public void SaveArticle(string content) => PathDefine.SaveFile(PathDefine.GetTheoryArticlePath(ID), content);
    }

    public class TheoryRelation
    {
        public int ID { get; set; }
        public virtual Theory Theory { get; set; }
        public virtual Jinja Jinja { get; set; }
        public virtual Kami Kami { get; set; }
    }
}
