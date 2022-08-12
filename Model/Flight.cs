namespace Model;

public class Flight 
{
    public Flight(int flightNO, Airport departureAirport, string departureCountry, string departureContinent,
        Airport destinationAirport, string destinationCountry, string destinationContinent,Company company, DateTime dateTime,
        double length, int totalSeats, int totalBookedSeats, double price, double priceForLuggage, string status)
    {
        this.idFlight = 0;
        this.flightNO = flightNO;
        this.departureAirport = departureAirport;
        this.departureCountry = departureCountry;
        this.departureContinent = departureContinent;
        this.destinationAirport = destinationAirport;
        this.destinationCountry = destinationCountry;
        this.destinationContinent = destinationContinent;
        this.company = company;
        this.dateTime = dateTime;
        this.length = length;
        this.totalSeats = totalSeats;
        this.totalBookedSeats = totalBookedSeats;
        this.price = price;
        this.priceForLuggage = priceForLuggage;
        this.status = status;

    }
    public Flight()
    {
        
    }
    public int idFlight { get; set; }
    public int flightNO { get; set; }
    public Airport departureAirport { get; set; }
    public string departureCountry { get; set; }
    public string departureContinent { get; set; }
    public Airport destinationAirport { get; set; }
    public string destinationCountry { get; set; }
    public string destinationContinent { get; set; }
    public Company company { get; set; }
    public DateTime dateTime{ get; set; }
    public double length { get; set; }
    public int totalSeats { get; set; }
    public int totalBookedSeats { get; set; }
    public double price { get; set; }
    public double priceForLuggage { get; set; }
    public string status;
}