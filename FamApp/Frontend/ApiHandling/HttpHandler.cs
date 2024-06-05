using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamApp.Frontend.ApiHandling
{
    internal class HttpHandler
    {
        //Um mit der API zu Kommunizieren
        private readonly HttpClient _client;

        //darauf liegt die API stetzen wir als Base String
        private readonly string _url;

        //Getter für den HttpClient und Url
        public HttpClient Client { get { return _client; } }
        public string Url { get { return _url; } }

        //Constructor
        public HttpHandler()
        {
            _client = new HttpClient();
            _url = "http://10.1.216.203:8082/api/";
        }
    }
}
