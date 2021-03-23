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

    public class Prefecture
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Municipality
    {
        public int ID { get; set; }
        public virtual Prefecture Prefecture { get; set; }
        public string MuniCd { get; set; }
        public string Name { get; set; }
    }



    public class Location
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual Prefecture Prefecture { get; set; }
        public virtual Municipality Municipality { get; set; }
        public string Address { get; set; }

        public Location() { }
        public Location(Geolocation geo, JinjaDbContext jinjadb)
        {
            Latitude = geo.Latitude;
            Longitude = geo.Longitude;
            Prefecture = jinjadb.PrefectureDbSet.Find(geo.PrefectureID);
            Municipality = jinjadb.MunicipalityDbSet.First(m => m.MuniCd == geo.MunicipalityID.ToString());
            Address = geo.Address;
        }
    }
}
