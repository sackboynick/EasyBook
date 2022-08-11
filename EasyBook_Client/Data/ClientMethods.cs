using Model;

namespace EasyBook_Client.Data;

public class ClientMethods:IClientMethods
{
    public ServerDataRetriever _clientMethods;

    public ClientMethods()
    {
        this._clientMethods = new ServerDataRetriever("0.0.0.0",1111);
        
        
    }

    public User getCurrentUser()
    {
        return _clientMethods.getCurrentUser();
    }

    public void selectFlight(Flight flight)
    {
        _clientMethods.selectedFlight = flight;
    }

    public Flight getSelectedFlight()
    {
        return _clientMethods.selectedFlight;
    }
    

    public List<Flight> getAllFlights()
    {
        return _clientMethods.getAllFlights();
    }

    public List<Flight> getFlightsByDepDesDate(string depAirport, string desAirport, string date)
    {
        return _clientMethods.getFlightsByDepDesDate(depAirport, desAirport, date);
    }

    public List<Flight> getFlightsByDepDate(string depAirport, string date)
    {
        return _clientMethods.getFlightsByDepDate(depAirport, date);
    }

    public List<Flight> getFlightsByDepCDate(string depCountry, string date)
    {
        return _clientMethods.getFlightsByDepCDate(depCountry, date);
    }

    public List<Flight> getFlightsByDepC(string depCountry)
    {
        return _clientMethods.getFlightsByDepC(depCountry);
    }

    public List<Booking> getBookings(string email)
    {
        return _clientMethods.getBookings(email);
    }

    public void makeBooking(Booking booking)
    {
        _clientMethods.makeBooking(booking);
    }

    public void removeBooking(int bookingId)
    {
        _clientMethods.removeBooking(bookingId);
    }

    public User logIn(string email, string password)
    {
        return _clientMethods.logIn(email, password);
    }

    public void registerUser(User user)
    {
        _clientMethods.registerUser(user);
    }
}