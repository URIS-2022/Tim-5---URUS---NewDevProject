

using Newtonsoft.Json;

public static class HttpClient<T> where T : class
{
    //private static readonly string Token = AppConfig.Get("AuthenticationServiceToken");
    private static readonly HttpClient Client = new HttpClient();

    static HttpClient()
    {
        /* Client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);*/
        Client.DefaultRequestHeaders.Add("Accept-Language", Thread.CurrentThread.CurrentCulture.Name);
    }

    public static async Task<T> GetAsync(string url)
    {
        Client.DefaultRequestHeaders.Remove("Accept-Language");
        Client.DefaultRequestHeaders.Add("Accept-Language", Thread.CurrentThread.CurrentCulture.Name);
        T result = null;
        var response = await Client.GetAsync(new Uri(url));
        response.EnsureSuccessStatusCode();
        await response.Content.ReadAsStringAsync().ContinueWith(x =>
        {
            if (x.IsFaulted)
                if (x.Exception != null)
                    throw x.Exception;

            result = JsonConvert.DeserializeObject<T>(x.Result);
        });

        return result;
    }
}