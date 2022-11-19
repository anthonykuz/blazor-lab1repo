using blazor_lab1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace blazor_lab1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }

    // -----------------------------------------------------

    public enum InstanceSize { S1, S2, S3 }

    public class AzureAppService
    {
        public InstanceSize Size { get; set; }
        private int instanceCount;
        readonly double[] instancePrices = new double[] { 0.084, 0.169, 0.337 };

        public int InstanceCount
        {
            get { return instanceCount; }
            set
            {
                if (value >= 0 && value <= 10)
                {
                    instanceCount = value;
                }
            }
        }

        public double this[InstanceSize size]
        {
            get 
            {
                return instancePrices[(int)size];
            }
        }

        public double CalculateYearly()
        {
            return Math.Round(instancePrices[(int)Size] * instanceCount, 2);
        }
    }
}