namespace Model;

public class Booking
{
    public Booking(Flight flight,User user,int luggage,Company company, string firstName,string lastName,string passportId,string status)
    {
        this.idBooking = 0;
        this.flight = flight;
        this.user = user;
        this.luggage = luggage;
        this.company = company;
        this.firstName = firstName;
        this.lastName = lastName;
        this.passportId = passportId;
        this.status = status;
    }
    public Booking()
    {
        
    }
    public int idBooking { get; set; }
    public Flight flight { get; set; }
    public User user { get; set; }
    public int luggage { get; set; }
    
    public Company company { get; set; }
    public double finalPrice()
    {
        return flight.price + flight.priceForLuggage * luggage;
    }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string passportId { get; set; }
    public string status { get; set; }
}