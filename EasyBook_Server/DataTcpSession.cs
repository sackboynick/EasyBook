using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic.CompilerServices;
using Model;
using NetCoreServer;

namespace EasyBook_Server;

public class DataTcpSession:TcpSession
{
    private DatabaseDataRetriever _dataRetriever = new();
    public DataTcpSession(TcpServer server) : base(server)
    {
    }
    protected override void OnConnected()
        {
            Console.WriteLine($"Chat TCP session with Id {Id} connected!");

            // Send invite message
            string message = "Hello from TCP chat! Please send a message or '!' to disconnect the client!";
            SendAsync(message);
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Chat TCP session with Id {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            
            Console.WriteLine("Incoming: " + message);

            if (message.StartsWith("F"))
            {
                List<Flight> flights = _dataRetriever.getAllFlights().Result;
                SendAsync("F"+JsonSerializer.Serialize(flights));
            }
            else if (message.StartsWith("U"))
            {
                string email = "";
                int indexOfDivisor = message.IndexOf(":");
                email = message.Substring(1, indexOfDivisor - 1);
                string password = message.Substring(indexOfDivisor + 1);
                Console.WriteLine(email+" "+password);
                SendAsync("U"+JsonSerializer.Serialize(_dataRetriever.getUser(email, password).Result));
            }
            else if (message.StartsWith("B"))
            {
                Console.WriteLine(_dataRetriever.getAllBookings().Result.Count);
                SendAsync("B"+JsonSerializer.Serialize(_dataRetriever.getAllBookings().Result
                    .Where(booking => booking.user.email.Equals(message.Substring(1))).ToList()));
            }
            else if (message.Substring(0, 4).Equals("addB"))
            {
                _dataRetriever.addBooking(JsonSerializer.Deserialize<Booking>(message.Substring(4)));
            }
            else if (message.Substring(0, 4).Equals("remB"))
            {
                _dataRetriever.removeBooking(IntegerType.FromString(message.Substring(4)));
            }
            else if (message.Substring(0, 4).Equals("regU"))
            {
                Console.WriteLine(message);
                _dataRetriever.createUser(JsonSerializer.Deserialize<User>(message.Substring(4)));
                
            }

            // If the buffer starts with '!' the disconnect the current session
            if (message == "!")
                Disconnect();
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP session caught an error with code {error}");
        }
    }

    class DataTcpServer : TcpServer
    {
        public DataTcpServer(IPAddress address, int port) : base(address, port) {}

        protected override TcpSession CreateSession() { return new DataTcpSession(this); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP server caught an error with code {error}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // TCP server port
            int port = 1111;
            if (args.Length > 0)
                port = int.Parse(args[0]);

            Console.WriteLine($"TCP server port: {port}");

            Console.WriteLine();

            // Create a new TCP chat server
            var server = new DataTcpServer(IPAddress.Any, port);
            Console.WriteLine("Address: "+server.Address);

            // Start the server
            Console.Write("Server starting...");
            server.Start();
            Console.WriteLine("Done!");

            Console.WriteLine("Press Enter to stop the server or '!' to restart the server...");

            // Perform text input
            for (;;)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                // Restart the server
                if (line == "!")
                {
                    Console.Write("Server restarting...");
                    server.Restart();
                    Console.WriteLine("Done!");
                    continue;
                }

            }

            // Stop the server
            Console.Write("Server stopping...");
            server.Stop();
            Console.WriteLine("Done!");
        }
    }