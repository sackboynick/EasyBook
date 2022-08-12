namespace Model;

public class Booking
{
    public Booking(int flightNo,Flight flight,User user,int luggage,double finalPrice,string firstName,string lastName,string passportId,string status)
    {
        this.idBooking = 0;
        this.flightNo = flightNo;
        this.flight = flight;
        this.user = user;
        this.luggage = luggage;
        this.firstName = firstName;
        this.lastName = lastName;
        this.finalPrice = finalPrice;
        this.passportId = passportId;
        this.status = status;
    }
    public Booking()
    {
        
    }
    public int idBooking { get; set; }
    public int flightNo { get; set; }
    public Flight flight { get; set; }
    public User user { get; set; }
    public int luggage { get; set; }
    public double finalPrice { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string passportId { get; set; }
    public string status { get; set; }
    public int idFlight { get; set; }
}