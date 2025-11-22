using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient chatClient = new OllamaApiClient("http://localhost:11434", "gemma3:4b");

Console.Write("> ");
string prompt = Console.ReadLine() ?? string.Empty;
ChatResponse response = await chatClient.GetResponseAsync(prompt);

Console.WriteLine(response.Text);