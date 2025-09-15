using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAuthApp.Models;
using MauiAuthApp.Services;

namespace MauiAuthApp.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IUserService _userService;

    [ObservableProperty]
    private string _email = string.Empty;
    
    [ObservableProperty]
    private string _password = string.Empty;

    public RegisterViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async Task Register()
    {
        var user = new User { Email = this.Email, Password = this.Password };
        await _userService.RegisterAsync(user);
        await Shell.Current.DisplayAlert("Başarılı", "Hesabınız oluşturuldu. Şimdi giriş yapabilirsiniz.", "Tamam");
        await Shell.Current.GoToAsync(".."); 
    }
}