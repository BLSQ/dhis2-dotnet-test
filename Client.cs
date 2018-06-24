using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Jil;

namespace dhis
{
  class Client
  {
    private HttpClient client = new HttpClient();
    private string baseUrl = null;

    public Client(string url, string user, string password)
    {
      baseUrl = url;
      var byteArray = Encoding.ASCII.GetBytes(user + ":" + password);
      client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    }

    public dynamic Get(string url)
    {
      var response = client.GetStringAsync(new Uri(baseUrl + "/api/" + url)).Result;
      return Jil.JSON.DeserializeDynamic(response);
    }
  }
}