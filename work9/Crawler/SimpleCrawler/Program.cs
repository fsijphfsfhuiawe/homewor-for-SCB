using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    public class SimpleCrawler
    {
        public string URL { get; set; }
        private int count = 0;

        private void Crawl()
        {
            Console.WriteLine("爬行开始");
            if (!IsTrue(URL)) return;
            while (true)
            {
                string current = null;
                current = URL;
                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载方法：获取其内容
                Console.WriteLine(html);
                Console.WriteLine("爬行结束");
                return;
            }
        }
        public bool IsTrue(string str)
        {
            try
            {
                string url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?.(html|aspx|jsp)$";
                return Regex.IsMatch(str, url);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong URL");
                return false;
            }
        }
        public string CompleteURL(string str)
        {

            return str;
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
    }
}


