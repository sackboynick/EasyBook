using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Model;

namespace EasyBook_Server;

public class DatabaseDataRetriever : IDatabaseRetriever
{
    public async Task<Flight> getFlight(int flightId)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetFlight?id="+flightId).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Flight flight = JsonSerializer.Deserialize<Flight>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }) ?? throw new InvalidOperationException();

        return flight;
    }

    public async Task<List<Flight>> getAllFlights()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetAllFlights").ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        List<Flight> flights = JsonSerializer.Deserialize<List<Flight>>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return flights;
    }

    public async Task<Airport> getAirport(int airportId)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetAirport?id="+airportId).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Airport airport = JsonSerializer.Deserialize<Airport>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return airport;
    }

    public async Task<List<Airport>> getAllAirports()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetAllAirports").ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        List<Airport> airports = JsonSerializer.Deserialize<List<Airport>>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return airports;
    }

    public async Task<Booking> getBooking(int bookingId)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetBooking?id="+bookingId).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Booking booking = JsonSerializer.Deserialize<Booking>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return booking;
    }

    public async Task addBooking(Booking booking)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
        
        string bookingAsJson = JsonSerializer.Serialize(booking);
        StringContent content = new StringContent(
            bookingAsJson,
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage response = await client.PostAsync("http://localhost:8080/AddBooking", content).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        
    }

    public async Task removeBooking(int bookingId)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
                
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/RemoveBooking?id="+bookingId).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
    }

    public async Task<List<Booking>> getAllBookings()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetAllBookings").ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Console.WriteLine(result);
        List<Booking> bookings = JsonSerializer.Deserialize<List<Booking>>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return bookings;
    }

    public async Task<Company> getCompany(int companyId)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetCompany?id="+companyId).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        Company company = JsonSerializer.Deserialize<Company>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return company;
    }

    public async Task<List<Company>> getAllCompanies()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/GetAllCompanies").ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        List<Company> companies = JsonSerializer.Deserialize<List<Company>>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return companies;
    }

    public async Task<User> getUser(string email, string password)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
            
            
        HttpResponseMessage response = await client.GetAsync("http://localhost:8080/CheckUser?Email="+email+"&Password="+password).ConfigureAwait(false);
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return user;
    }

    public async Task createUser(User user)
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        using HttpClient client = new HttpClient(clientHandler);
            
            
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent",".NET Foundation Repository Reporter");
        
        string userAsJson = JsonSerializer.Serialize(user);
        StringContent content = new StringContent(
            userAsJson,
            Encoding.UTF8,
            "application/json"
        );
        HttpResponseMessage response = await client.PostAsync("http://localhost:8080/AddUser", content).ConfigureAwait(false);
        Console.WriteLine(content.ToString());
        Console.WriteLine(response.Content.ToString());
        if(!response.IsSuccessStatusCode)
            throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
    }
}