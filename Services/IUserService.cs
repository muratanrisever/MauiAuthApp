using MauiAuthApp.Models;

namespace MauiAuthApp.Services;

public interface IUserService
{
    Task<User?> LoginAsync(string email, string password);
    Task RegisterAsync(User user);
}