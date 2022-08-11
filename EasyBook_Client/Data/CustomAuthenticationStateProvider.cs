using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Model;

namespace EasyBook_Client.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IClientMethods _userService;
        private static User _cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime, [FromServices] IClientMethods userService)
        {
            _jsRuntime = jsRuntime;
            _userService = userService;
        }

        public static string GetUsername()
        {
            return _cachedUser.email;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (_cachedUser == null)
            {
                string userAsJson = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User tmp = JsonSerializer.Deserialize<User>(userAsJson);
                    if (tmp != null) ValidateLogin(tmp.email, tmp.password);
                }
            }
            else
            {
                identity = SetupClaimsForUser(_cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        public void ValidateLogin(string username, string password)
        {
            Console.WriteLine("Validating log in");
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");
            ClaimsIdentity identity = new ClaimsIdentity();
            try
            {
                User user = _userService.logIn(username, password);
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonSerializer.Serialize(user);
                _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                _cachedUser = user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void Logout()
        {
            _cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                
                new Claim("Email", user.email),
                new Claim("FirstName", user.name),
                new Claim("LastName", user.surname),
                new Claim("Phone",user.phone),
                new Claim("Sex",user.sex.ToString()),
                new Claim("Password", user.password)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }
    }
}