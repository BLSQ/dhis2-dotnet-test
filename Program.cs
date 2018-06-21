using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace marocco
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            var byteArray = Encoding.ASCII.GetBytes("admin:district");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = client.GetStringAsync(new Uri("https://play.dhis2.org/2.29/api/organisationUnits")).Result;
            Console.Write(response);
        }
    }
}
