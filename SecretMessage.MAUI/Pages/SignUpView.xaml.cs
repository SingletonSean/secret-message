namespace SecretMessage.MAUI.Pages;

public partial class SignUpView : ContentPage
{
	public SignUpView(SignUpViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}