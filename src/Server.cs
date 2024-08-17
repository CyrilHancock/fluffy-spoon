using codecrafters_http_server.src.Requests;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Logs from your program will appear here!");

Socket listener = null;
try
{
    short port = 4221;
    IPAddress localAddr = IPAddress.Parse("127.0.0.1");

    // Create a new socket for listening
    listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    // Bind the socket to the local endpoint
    IPEndPoint localEndPoint = new IPEndPoint(localAddr, port);
    listener.Bind(localEndPoint);

    // Start listening for incoming connections
    listener.Listen(10);
    Console.WriteLine("Server started. Waiting for a connection...");

    Byte[] bytes = new Byte[256];
    Requests request = new Requests();

    while (true)
    {
        // Accept a client connection
        using Socket handler = listener.Accept();
        Console.WriteLine("Connected!");

        using NetworkStream stream = new NetworkStream(handler);
        int i;
        StringBuilder requestData = new StringBuilder();

        // Read data from the client
        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        {
            string chunk = Encoding.ASCII.GetString(bytes, 0, i);
            requestData.Append(chunk);
            if (i < bytes.Length) break;
        }
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("Received:\n{0}", requestData);
        Console.ResetColor();
        // Process the request and prepare the response
        string response = request.HandleRequests(requestData.ToString());
        byte[] responseBytes = Encoding.ASCII.GetBytes(response);

        // Send the response back to the client
        stream.Write(responseBytes, 0, responseBytes.Length);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("Sent:\n{0}", response);
        Console.ResetColor();
    }
}
catch (SocketException e)
{
    Console.WriteLine("SocketException: {0}", e.Message);
}
finally
{
    listener?.Close();
}

Console.WriteLine("\nHit enter to continue...");
Console.Read();
