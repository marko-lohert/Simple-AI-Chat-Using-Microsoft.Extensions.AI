using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient chatClient = new OllamaApiClient("http://localhost:11434", "gemma3:4b");
List<ChatMessage> ChatHistory = new();

while (true)
{
    Console.Write("> ");
    string prompt = Console.ReadLine() ?? string.Empty;
    if (prompt.Equals("/bye", StringComparison.OrdinalIgnoreCase))
        return;

    ChatHistory.Add(new ChatMessage(ChatRole.User, prompt));
    List<ChatResponseUpdate> completeResponse = [];

    await foreach (ChatResponseUpdate responseUpdate in chatClient.GetStreamingResponseAsync(ChatHistory))
    {
        Console.Write(responseUpdate.Text);
        completeResponse.Add(responseUpdate);
    }

    ChatHistory.AddMessages(completeResponse);

    Console.WriteLine();
}