namespace SecretMessage.MAUI.Pages;

public partial class SignInView : ContentPage
{
	public SignInView(SignInViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}