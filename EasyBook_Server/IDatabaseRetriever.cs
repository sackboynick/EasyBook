using Model;

namespace EasyBook_Server;

public interface IDatabaseRetriever
{
    Task<Flight> getFlight(int flightId);
    Task<List<Flight>> getAllFlights();
    Task<Airport> getAirport(int airportId);
    Task<List<Airport>> getAllAirports();
    Task<Booking> getBooking(int bookingId);
    Task addBooking(Booking booking);
    Task removeBooking(int bookingId);
    Task<List<Booking>> getAllBookings();
    Task<Company> getCompany(int companyId);
    Task<List<Company>> getAllCompanies();
    Task<User> getUser(string email,string password);
    Task createUser(User user);
}