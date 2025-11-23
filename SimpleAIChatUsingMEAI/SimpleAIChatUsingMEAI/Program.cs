using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient chatClient = new OllamaApiClient("http://localhost:11434", "gemma3:4b");

Console.Write("> ");
string prompt = Console.ReadLine() ?? string.Empty;
await foreach(ChatResponseUpdate responseUpdate in chatClient.GetStreamingResponseAsync(prompt))
{
    Console.Write(responseUpdate.Text);
}