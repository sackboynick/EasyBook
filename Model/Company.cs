namespace Model;


public class Company
{
    public Company(string nameCompany)
    {
        this.nameCompany = nameCompany;
    }
    public Company()
    {
        
    }
    public int idCompany { get; set; }
    public string nameCompany { get; set; }
}