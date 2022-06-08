using System.Threading.Tasks;
using Microsoft.Identity.Client;

public class Program 
{
    private const string _clientId = "7c523e0a-fd3a-46dd-a561-b33c0d28f98a";
    private const string _tenantId = "efef44b6-5f95-4ffa-b80b-1715dfc2d086";

    static async Task Main(string[] args) 
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

        string[] scopes = { "user.read" };

        AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
        System.Console.WriteLine($"Token: \t{ result.AccessToken }");
    }
}
