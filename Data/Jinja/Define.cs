using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Wadatsumi.Jinja.Data
{
    public static class PathDefine
    {
        public const string JinjaResourceRootPath = "wwwroot/jinja_resource";
        public const string JinjaRootPath = JinjaResourceRootPath + "/jinja";
        public const string GoshuinRootPath = JinjaResourceRootPath + "/goshuin";
        public const string TheoryRootPath = JinjaResourceRootPath + "/theory";
        public const string JinjaDBFilePath = JinjaResourceRootPath + "/jinja.db";
        public const string ImagesFolderPath = JinjaResourceRootPath + "/images";
        public static string GetJinjaAriticlePath(int id) => $"{JinjaRootPath}/{id}/article.html";
        public static string GetGoshuinTraveloguePath(int id) => $"{GoshuinRootPath}/{id}/travelogue.html";
        public static string GetTheoryArticlePath(int id) => $"{TheoryRootPath}/{id}/article.html";

        public const string RootUrl = "/Jinja";
        public const string JinjaNewUrl = RootUrl + "/New";
        public const string JinjaListUrl = RootUrl + "/List";
        public static string JinjaUrl(int id) => $"{RootUrl}/{id}";
        public static string JinjaEditUrl(int id) => $"{RootUrl}/Edit/{id}";

        public const string GoshuinRootUrl = RootUrl + "/Goshuin";
        public const string GoshuinListUrl = GoshuinRootUrl + "/List";
        public static string GoshuinUrl(int id) => $"{GoshuinRootUrl}/{id}";
        public static string GoshuinEditUrl(int id) => $"{GoshuinRootUrl}/Edit/{id}";

        public const string KamiRootUrl = RootUrl + "/Kami";
        public const string KamiNewUrl = KamiRootUrl + "/New";
        public const string KamiListUrl = KamiRootUrl + "/List";
        public static string KamiUrl(int id) => $"{KamiRootUrl}/{id}";
        public static string KamiEditUrl(int id) => $"{KamiRootUrl}/Edit/{id}";

        public const string TheoryRootUrl = RootUrl + "/Theory";
        public const string TheoryNewUrl = TheoryRootUrl + "/New";
        public const string TheoryListUrl = TheoryRootUrl + "/List";
        public static string TheoryUrl(int id) => $"{TheoryRootUrl}/{id}";
        public static string TheoryEditUrl(int id) => $"{TheoryRootUrl}/Edit/{id}";

        public static string LoadFile(string filepath)
        {
            if (File.Exists(filepath))
                return File.ReadAllText(filepath);
            else
                return "";
        }

        public static void SaveFile(string filepath, string content)
        {
            if (!File.Exists(filepath))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            File.WriteAllText(filepath, content, System.Text.Encoding.UTF8);
        }
    }
}
