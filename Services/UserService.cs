using MauiAuthApp.Models;
using System.Text.Json;

namespace MauiAuthApp.Services;

public class UserService : IUserService
{
    public async Task<User?> LoginAsync(string email, string password)
    {
        var userJson = await SecureStorage.GetAsync(email);
        if (userJson == null)
        {
            return null; 
        }

        var user = JsonSerializer.Deserialize<User>(userJson);

        if (user != null && user.Password == password)
        {
            return user;
        }

        return null;
    }

    public async Task RegisterAsync(User user)
    {
        var userJson = JsonSerializer.Serialize(user);
        await SecureStorage.SetAsync(user.Email, userJson);
    }
}