namespace FamApp.Pages;



public class LinearGradientBrush : Microsoft.Maui.Controls.GradientBrush
{
    public override bool IsEmpty => throw new NotImplementedException();
}

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }
    async void LoginBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    async void SignUpBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

}
