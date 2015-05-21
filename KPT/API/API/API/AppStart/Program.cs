using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.Owin.Hosting;

namespace API.AppStart
{
	public static class Program
	{
		static void Main()
		{

			// Start OWIN host 
			try
			{
				using (WebApp.Start<Startup>("http://localhost:9000/"))
				{
					Console.WriteLine("API: Started Successfully!\n" +
									  "IP: localhost:9000 (Local)\n\n" +
									  "Hit any key to stop.");
					Console.ReadLine();
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				Console.ReadLine();
			}
		}

		private static string LocalIpAddress()
		{
			var localIp = "";
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
			{
				localIp = ip.ToString();
				break;
			}
			return localIp;
		}
	} 
}