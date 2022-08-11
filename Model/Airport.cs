namespace Model;

public class Airport
{
    public Airport(string nameAirport)
    {
        this.idAirport = 0;
        this.nameAirport = nameAirport;
    }
    public Airport()
    {
        
    }
    public int idAirport { get; set; }
    public string nameAirport { get; set; }
}