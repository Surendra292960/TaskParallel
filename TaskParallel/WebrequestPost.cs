using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TaskParallel
{
    class WebrequestPost
    {
        static void Main(string[] args)
        {
            PostRequest("http://posttestserver.com");
           // GetRequest("http://www.google.pk");

            Console.ReadKey();
        }

        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        // string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders header = content.Headers;
                        Console.WriteLine(header);
                    }
                }
            }
        }

        async static void PostRequest(string url)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>();
            {
                new KeyValuePair<string, string>("query1", "sp");
                new KeyValuePair<string, string>("query2", "sp2");
            }
            HttpContent q = new FormUrlEncodedContent(queries);

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url,q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                       // HttpContentHeaders header = content.Headers;
                        Console.WriteLine(mycontent);
                    }
                }
            }
        }
    }
}
