namespace MauiAuthApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(ViewModels.LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}