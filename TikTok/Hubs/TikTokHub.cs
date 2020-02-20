using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TickTock.Hubs
{
	internal class TikTokHub: Hub
	{
		public async Task SendTik(int tick)
		{
			await Clients.All.SendAsync("tik", tick);
		}

		public async Task Ack(int tick)
		{
			Console.WriteLine($"Acknowledged tick {tick} from connectionId={Context.ConnectionId}");
		}

		public override Task OnConnectedAsync()
		{
			Console.WriteLine($"OnConnectedAsync: ConnectionId={Context.ConnectionId}");
			return Task.CompletedTask;
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{
			Console.WriteLine($"OnDisconnectedAsync: ConnectionId={Context.ConnectionId}");
			return Task.CompletedTask;
		}
	}

	internal interface ITikTokClient
	{
		Task Tik(int id);
	}
}