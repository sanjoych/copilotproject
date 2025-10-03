using System;
using System.Net.Sockets;
using System.Text;

public static class DoSocketIO
{
    public static string SendAndReceive(string ip, int port, string message)
    {
        try
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect(ip, port);
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] msgBytes = Encoding.UTF8.GetBytes(message);
                    stream.Write(msgBytes, 0, msgBytes.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    return $"Received: {response}";
                }
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
