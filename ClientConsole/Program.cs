using Microsoft.AspNetCore.SignalR.Client;

namespace ClientConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionStr = "http://localhost:5232/msg-hub";
            var connection = new HubConnectionBuilder()
                .WithUrl(connectionStr)
                .Build();

            await connection.StartAsync();
            connection.On<string>("ReceiveMsg", msg =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"    {msg}");
                Console.ResetColor();
            });
            while (true)
            {
                var input = Console.ReadLine();
                await connection.SendAsync("BroadcastMsg", input);
            }
        }
    }
}