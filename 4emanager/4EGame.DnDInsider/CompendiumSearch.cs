namespace Game.DnDInsider
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;

    public class CompendiumSearch
    {
        public void A()
        {

            var request = (HttpWebRequest)WebRequest.Create("http://www.wizards.com/dndinsider/compendium/login.aspx");
            request.CookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string email = "martin.richelieu@live.com"; 
            string password = "#Wizards3";

            string postData = "email=" + email + "&password=" + password + "&__VIEWSTATE=/wEPDwUKLTMxMzExNzE1NGRk5yeNnWQGSxW08LBMM/goQ8zo5Es=&__EVENTVALIDATION=/wEWBAL25N6oDwKyzcaDDQLyveCRDwK4+vrXBUx4g9s9PCt9gK77St3QWFU1ZunN&InsiderSignin=Sign In"; 
            string encodedData = HttpUtility.UrlEncode(postData, Encoding.UTF8);

            StreamWriter sWriter = new StreamWriter(request.GetRequestStream());
            sWriter.Write(encodedData);
            sWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
            
        }
    }
}
