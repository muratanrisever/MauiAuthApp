using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAuthApp.Services;
using MauiAuthApp.Views;

namespace MauiAuthApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IUserService _userService;

    [ObservableProperty]
    private string _email = string.Empty;

    [ObservableProperty]
    private string _password = string.Empty;

    public LoginViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async Task Login()
    {
        var user = await _userService.LoginAsync(Email, Password);
        if (user != null)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            await Shell.Current.DisplayAlert("Hata", "E-posta veya şifre yanlış.", "Tamam");
        }
    }

    [RelayCommand]
    private async Task GoToRegister()
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}