using ConsoleApp1;
using System.Net.Http;
using System.Reflection;
using System.Text;

class Program
{

    static async Task Main()
    {
        ApiClient<string> api = new ApiClient<string>("https://api.apilayer.com/sentiment/analysis");
        var postResponse = await api.Post("It's a beatiful Day outside...");
        var list = postResponse.Data;
        foreach (var response in list)
        {
            Console.WriteLine(response);
        }
    }
}