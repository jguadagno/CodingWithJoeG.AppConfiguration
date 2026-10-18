using System;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace CodingWithJoeG.AppConfiguration.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Option 1
            //var builder = new ConfigurationBuilder();
            //builder.AddAzureAppConfiguration("<replace me>");
            // var settings = builder.Build();
            
            // Option 2
            // var builder = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.json", false, true);
            // var settings = builder.Build();
            // builder.AddAzureAppConfiguration(options => 
            //     options.Connect(new Uri(settings["AppConfig:Endpoint"]), new EnvironmentCredential()));

            // Option 3
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true);
            var settings = builder.Build();
            builder.AddAzureAppConfiguration(options => 
                options.Connect(new Uri(settings["AppConfig:Endpoint"]), new DefaultAzureCredential()));
            
            settings = builder.Build();
            
            Console.WriteLine($"Stream Url={settings["StreamUrl"]}");
            Console.WriteLine(
                $"CodingWithJoeG:AppConfiguration:StreamUrl='{settings["CodingWithJoeG:AppConfiguration:StreamUrl"]}'");
            Console.WriteLine("Hello World!");
        }
    }
}