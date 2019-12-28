using Ivony.Html;
using Ivony.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSourData
{
    #region C# 爬虫 Jumony-html解析
    //https://www.cnblogs.com/cang12138/p/7486003.html

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region C# 爬虫 Jumony-html解析
            GetDataByJumony();
            #endregion
        }
        #region C# 爬虫 Jumony-html解析
        static void GetDataByJumony()
        {
            Console.WriteLine("开始跑数据");

            for (var i = 1; i < 51; i++)
            {
                var path = "http://cn.coovee.com/company/c63.html?p=" + i.ToString();

            IHtmlDocument source = new JumonyParser().LoadDocument(path, System.Text.Encoding.GetEncoding("utf-8"));

            var company = source.Find(".company-l-item");
            Console.WriteLine(company.Count());
            foreach (var item in company)
            {
                var a = item.Find(".dt h4 a").FirstOrDefault();

               // if (!a.InnerText().StartsWith("中润油联天下网络")) continue;

                Console.WriteLine("公司名=" + a.InnerText());
                var span = item.Find(".dt p span").FirstOrDefault();
                Console.WriteLine("联系人=" + span.InnerText());
                var zhuying = item.Find(".dd p").FirstOrDefault();
                Console.WriteLine("主营=" + zhuying.InnerText().Replace("主营：",""));

                var url = item.Find(".dd ul li").Last().Find("a").FirstOrDefault().Attribute("href").Value();
                Console.WriteLine(url);
                System.Threading.Thread.Sleep(1000);
                source = new JumonyParser().LoadDocument(url, System.Text.Encoding.GetEncoding("utf-8"));
                var tel = source.Find(".company-contact-info p").ToList<IHtmlElement>()[1].InnerText();
                Console.WriteLine("电话=" + tel.Replace("联系电话：", ""));
                var adress = source.Find(".company-contact-info p").ToList<IHtmlElement>()[3].InnerText();
                Console.WriteLine("地址=" + adress.Replace("公司地址：", "").Replace("  ", ""));

                System.Threading.Thread.Sleep(1000);
            }
            System.Threading.Thread.Sleep(2000);
            }
        }
        #endregion
    }
}
