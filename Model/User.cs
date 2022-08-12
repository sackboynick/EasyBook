namespace Model;

public class User
{

    public User(string name, string surname, char sex, string phone, string email, string password)
    {
        this.name = name;
        this.surname = surname;
        this.sex = sex;
        this.phone = phone;
        this.email = email;
        this.password = password;
    }

    public User()
    {
        
    }
    public int idUser { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string password { get; set; }
    public string phone { get; set; }
    
    public char sex { get; set; }
    public string surname { get; set; }
    

    
}