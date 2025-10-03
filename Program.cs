
using System;
using System.Net.Sockets;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine($"Argument count: {args.Length}");
		string? ip;
		if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
		{
			ip = args[0];
			Console.WriteLine($"Using IP address from argument: {ip}");
		}
		else
		{
			Console.WriteLine("Enter IP address:");
			ip = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(ip))
			{
				Console.WriteLine("Invalid IP address.");
				return;
			}
		}
		int port;
		if (args.Length > 1 && int.TryParse(args[1], out port))
		{
			Console.WriteLine($"Using port from argument: {port}");
		}
		else
		{
			Console.WriteLine("Enter port:");
			string? portInput = Console.ReadLine();
			if (!int.TryParse(portInput, out port))
			{
				Console.WriteLine("Invalid port.");
				return;
			}
		}

		var result = DoSocketIO.SendAndReceive(ip, port, "Hello");
		Console.WriteLine(result);
	}
}

