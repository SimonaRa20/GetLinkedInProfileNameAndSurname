using HtmlAgilityPack;
// need to install HtmlAgilityPack nuget
namespace LinkedInScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string link = "https://www.linkedin.com/in/simona-ragauskaite/";
            //string link = "https://www.linkedin.com/in/paulggibbons/";

            string name = string.Empty;
            string surname = string.Empty;

            ScrapeSerp(link, ref name, ref surname);
            Console.WriteLine("{0} {1}", name, surname);
        }

        public static void ScrapeSerp(string query, ref string name, ref string surname)
        {
            var url = "https://www.google.com/search?q=" + query + " &num=1&start=1";
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "user-agent=Mozilla/5.0" +
                " (Windows NT 10.0; Win64)" +
                " AppleWebKit/537.36 (KHTML, like Gecko)" +
                " Chrome/74.0.3729.169 Safari/537.36";

            var htmlDoc = web.Load(url);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='yuRUbf']");

            if (nodes != null)
            {
                var title = nodes.Descendants("h3").FirstOrDefault().InnerText;

                string[] array = title.Split(' ');
                name = array[0];
                surname = array[1];
            }
        }
    }
}