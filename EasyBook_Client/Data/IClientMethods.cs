using Model;

namespace EasyBook_Client;

public interface IClientMethods
{
    User getCurrentUser();
    Flight getSelectedFlight();
    void selectFlight(Flight flight);
    List<Flight> getAllFlights();
    List<Flight> getFlightsByDepDesDate(string depAirport, string desAirport, string date);
    List<Flight> getFlightsByDepDate(string depAirport, string date);
    List<Flight> getFlightsByDepCDate(string depCountry, string date);
    List<Flight> getFlightsByDepC(string depCountry);
    List<Booking> getBookings(string email);
    void makeBooking(Booking booking);
    void removeBooking(int bookingId);
    User logIn(string email, string password);
    void registerUser(User user);
}