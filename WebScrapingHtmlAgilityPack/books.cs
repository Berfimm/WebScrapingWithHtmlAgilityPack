using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScrapingHtmlAgilityPack
{
    public partial class books : Form
    {
        public books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i,j;
            for(i = 1; i<51 ;i++)
            {
                getDataFromSite("http://books.toscrape.com/catalogue/category/books_1/index.html", "//*[@id='default']/div/div/div/aside/div[2]/ul/li/ul/li["+ i +"]/a", listBox1);

               
            }

            for (j = 1; j < 51; j++)
            {
                getDataFromSiteDip("http://books.toscrape.com/catalogue/category/books_1/index.html", "//*[@id='default']/div/div/div/aside/div[2]/ul/li/ul/li[" + j + "]/a", "href", listBox2);

            }


            int b;
            for (b = 1; b < 20; b++)
            {
                getDataFromSite("http://books.toscrape.com/catalogue/category/books/sequential-art_5/page-3.html", "//*[@id='default']/div/div/div/div/section/div[2]/ol/li["+ b +"]/article/h3/a", listBox3);


            }

        }

        public Uri url;
        public void getDataFromSite(String Url,String XPath,ListBox result)
        {

            url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);  
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            result.Items.Add(dokuman.DocumentNode.SelectSingleNode(XPath).InnerText);

        }

        public void getDataFromSiteDip(String Url, String XPath,String Dip,ListBox result)
        {

            url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url);
            // Html codes from url   
            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            // send to HtmlDocument    
            result.Items.Add(dokuman.DocumentNode.SelectSingleNode(XPath).Attributes[Dip].Value);

        }

    }
}
