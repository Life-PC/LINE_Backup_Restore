using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace LINE_Backup_Restore.lib
{
    public class html
    {
        static string HeadFirst =
            "<!DOCTYPE html>\n" +
            "<html>\n" +
            "    <head>\n" +
            "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
            "        <style>\n";
        static string CustomCSS = "";
        static string HeadEnd ="    </head>\n" +
            "<body>\n";
        static string Title = "";
        static string footer = "</body>\n" +
            "</html>";

        public static void Title_Create(string title)
        {
             title = "<title>" + title + "</title>\n";
        }
        public static void CSS_Set(string customCSS)
        {
            CustomCSS = customCSS;
        }
        public static string DateTimeText_Create(string dateTime)
        {
            return "<h2 class=\"dateTime\">" + dateTime + "</h2>\n";
        }
        public static string SayLeftText_Create(string name, string text, string time)
        {
            text = text.Replace("\r\n", "<br>");
            return "    <div class=\"balloon_l\">\n" +
                "        <div class=\"faceicon\">\n" +
                "            <img src=\"image/left.png\" alt=\"\">\n" +
                "        </div>\n" +
                "        <p class=\"name\">" + name + "</p>\n" +
                "        <p class=\"says\">" + text + "</p>\n" +
                "        <p class=\"Time\">" + time + "</p>" +
                "    </div>\n";
        }
        public static string SayRightText_Create(string name, string text, string time)
        {
            text = text.Replace("\r\n", "<br>");
            return "    <div class=\"balloon_r\">\n" +
                "        <div class=\"faceicon\">\n" +
                "            <img src=\"image/right.png\" alt=\"\">\n" +
                "        </div>\n" +
                "        <p class=\"Time\">" + time + "</p>\n" +
                "        <div class=\"says\">\n" +
                "            <p>" + text + "</p>\n" +
                "        </div>\n" +
                "        <p class=\"name\">" + name + "</p>" + 
                "    </div>\n";
        }

        public static string HTMLText_Create(string bodyText)
        {
            return
                HeadFirst +
                CustomCSS +
                "        </style>\n" +
                Title +
                HeadEnd +
                bodyText +
                footer;
        }

        public static int HTMLFile_Create(string fileName, string fileText)
        {
            Encoding sjisEnc = Encoding.GetEncoding("UTF-8");
            using (StreamWriter writer = new StreamWriter(fileName, false, sjisEnc))
            {
                writer.Write(fileText);

            }

            string copyPath = Path.GetDirectoryName(fileName) + "\\image";

            if (!Directory.Exists(copyPath))
                Directory.CreateDirectory(copyPath);

            if (File.Exists("file\\left.png") && File.Exists("file\\right.png"))
            {
                File.Copy(@"file\\left.png", copyPath + @"\left.png", true);
                File.Copy(@"file\\right.png", copyPath + @"\right.png", true);
            }

            return 0;
        }
    }
}
