using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wadatsumi.Data.Jinja
{
    public static class PathDefine
    {
        public const string JinjaResourceRootPath = "wwwroot/jinja_resource/";
        public const string GoshuinRootPath = JinjaResourceRootPath + "goshuin/";
        public const string JinjaDBFilePath = JinjaResourceRootPath + "jinja.db";
        public const string ImagesFolderPath = JinjaResourceRootPath + "images/";

        public static string GetGoshuinTraveloguePath(int id) => $"{GoshuinRootPath}{id}/travelogue.html";
    }
}
