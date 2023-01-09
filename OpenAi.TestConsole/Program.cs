using Microsoft.Extensions.Configuration;

namespace OpenAi.TestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string apiKey = configuration["ApiKey"];

            using var httpClient = new HttpClient();
            var client = new OpenAI.ApiClients.OpenAIApiClient(httpClient);

            client.ApiKey = apiKey;
            var c_code = "Console.WriteLine(\"Hello World\")";

            // Docs see: https://beta.openai.com/docs/guides/code/code-completion-limited-beta
            // Idea see: https://github.com/evyatar9/GptHidra/blob/5919fdc9c4d3cf43834a8be8e318497eba89a1f4/GptHidra.py#L28
            var result = await client.CreateCompletionAsync(new OpenAI.ApiClients.CreateCompletionRequest
            {
                Max_tokens = 2048,
                Model = "text-davinci-003", // "code-davinci-002",
                Prompt = "Explain this code:\n" + c_code
            });

            foreach (var c in result.Choices)
            {
                Console.WriteLine(c.Text);
            }
        }
    }
}