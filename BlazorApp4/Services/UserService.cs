// Services/UserService.cs
using System.Collections.Generic;
using System.Linq;
using BlazorApp4.Shared;

namespace BlazorApp4.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Username = "admin", Password = "admin", Role = "Admin" },
            new User { Username = "user", Password = "user", Role = "User" }
        };

        public User Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
