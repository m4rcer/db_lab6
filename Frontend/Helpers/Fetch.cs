using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Frontend.Helpers
{
    internal class Fetch
    {
        public static async Task<T> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("email", Data.email);
                client.DefaultRequestHeaders.Add("password", Data.password);

                HttpResponseMessage response = await client.GetAsync(Data.serverUrl + url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(json);

                    T content = JsonConvert.DeserializeObject<T>(json);
                    return content;
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        public static async Task Post<T>(string url, T data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("email", Data.email);
                client.DefaultRequestHeaders.Add("password", Data.password);

                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(Data.serverUrl + url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
        }

        public static async Task Put<T>(string url, T data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("email", Data.email);
                client.DefaultRequestHeaders.Add("password", Data.password);

                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(Data.serverUrl + url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
        }

        public static async Task Delete(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("email", Data.email);
                client.DefaultRequestHeaders.Add("password", Data.password);

                var response = await client.DeleteAsync(Data.serverUrl + url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
        }
    }
}
