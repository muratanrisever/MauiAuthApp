namespace MauiAuthApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(ViewModels.RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}