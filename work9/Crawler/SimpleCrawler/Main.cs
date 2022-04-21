using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrawler
{
    class MainClass
    {
        public static void Main()
        {
            try
            {
                /*static void Main(string[] args)
                {
                    SimpleCrawler myCrawler = new SimpleCrawler();
                    //
                    myCrawler.URL = "https://www.cnblogs.com/dstang2000/archive/2010/11/02/1867406.html";
                    Thread thread = new Thread(myCrawler.Crawl);
                    thread.Start();
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}