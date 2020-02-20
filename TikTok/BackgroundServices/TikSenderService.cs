using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TickTock.Hubs;

namespace TickTock.Background
{
	internal class TikSenderService : BackgroundService
	{
		private readonly TikTokHub _tikTokHub;
		private Timer _timer;
		private int _tick;

		public TikSenderService(TikTokHub tikTokHub)
		{
			_tikTokHub = tikTokHub;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			await using var timer = new Timer(
				async state =>
				{
					await _tikTokHub.SendTik(_tick++);
				},
				null,
				TimeSpan.FromSeconds(1),
				TimeSpan.FromSeconds(1)
			);

			await Task.Delay(999999);
		}
	}
}