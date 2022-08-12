using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Model;
using TcpClient = NetCoreServer.TcpClient;

namespace EasyBook_Client.Data;

public class ServerDataRetriever:TcpClient,IClientMethods
{
    public ServerDataRetriever(string address, int port) : base(address, port)
    {
        flightsToDisplay = new List<Flight>();
        bookingsToDisplay = new List<Booking>();
        user = new User();
        Console.WriteLine($"TCP server address: {address}");
        Console.WriteLine($"TCP server port: {port}");
        Console.WriteLine();

        // Connect the client
        Console.Write("Client connecting...");
        ConnectAsync();
        Console.WriteLine("Done!");

    }
/*
    public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }
        */

    protected override void OnConnected()
        {
            Console.WriteLine($"Chat TCP client connected a new session with Id {Id}");
        }
/*
    protected override void OnDisconnected()
        {
            Console.WriteLine($"Chat TCP client disconnected a session with Id {Id}");

            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
        }
        */

    protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            string message= Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            Console.WriteLine(message);
            if (message.StartsWith("F"))
                flightsToDisplay = JsonSerializer.Deserialize<List<Flight>>(message.Substring(1));
            else if (message.StartsWith("B"))
                bookingsToDisplay = JsonSerializer.Deserialize<List<Booking>>(message.Substring(1));
            else if (message.StartsWith("U"))
                user = JsonSerializer.Deserialize<User>(message.Substring(1));
        }

    protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP client caught an error with code {error}");
        }

    private bool _stop;

    public List<Flight> flightsToDisplay;
    public List<Booking> bookingsToDisplay;
    public User user;
    public Flight selectedFlight;

    public Flight getSelectedFlight()
    {
        return selectedFlight;
    }

    public void selectFlight(Flight flight)
    {
        this.selectedFlight = flight;
    }


    public User getCurrentUser()
    {
        return user;
    }
    

    public List<Flight> getAllFlights()
    {
        flightsToDisplay= new List<Flight>();
        SendAsync("F");
        while (flightsToDisplay.Count==0)
        {
            Thread.Sleep(10);
        }

        return flightsToDisplay;
    }

    public List<Flight> getFlightsByDepDesDate(string depAirport, string desAirport, string date)
    {
        flightsToDisplay= new List<Flight>();
        SendAsync("FDEP"+depAirport+"DES"+desAirport+"DAT"+date);
        while (flightsToDisplay.Count==0)
        {
            Thread.Sleep(10);
        }
        return flightsToDisplay;
    }

    public List<Flight> getFlightsByDepDate(string depAirport, string date)
    {
        flightsToDisplay= new List<Flight>();
        SendAsync("FDEP"+depAirport+"DAT"+date);
        while (flightsToDisplay.Count==0)
        {
            Thread.Sleep(10);
        }
        return flightsToDisplay;
    }

    public List<Flight> getFlightsByDepCDate(string depCountry, string date)
    {
        flightsToDisplay= new List<Flight>();
        SendAsync("FCDP"+depCountry+"DAT"+date);
        while (flightsToDisplay.Count==0)
        {
            Thread.Sleep(10);
        }
        return flightsToDisplay;
    }

    public List<Flight> getFlightsByDepC(string depCountry)
    {
        flightsToDisplay = new List<Flight>();
        SendAsync("FCDP"+depCountry);
        while (flightsToDisplay.Count==0)
        {
            Thread.Sleep(10);
        }
        return flightsToDisplay;
    }

    public List<Booking> getBookings(string email)
    {
        bookingsToDisplay = new List<Booking>();
        SendAsync("B" + email);
        int i = 0;
        while (bookingsToDisplay.Count==0 || i<6)
        {
            Thread.Sleep(1000);
            i++;
        }
        
        return bookingsToDisplay;
    }

    public void makeBooking(Booking booking)
    {
        SendAsync("addB" + JsonSerializer.Serialize(booking));
    }

    public void removeBooking(int bookingId)
    {
        SendAsync("remB" + bookingId);
    }

    public User logIn(string email, string password)
    {
        user = null;
        SendAsync("U" + email + ":" + password);
        while (user == null)
        {
            Thread.Sleep(10);
        }

        return user;
    }

    public void registerUser(User userToReg)
    {
        SendAsync("regU" + JsonSerializer.Serialize(userToReg));
    }
}