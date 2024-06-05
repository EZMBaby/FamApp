using FamApp.Routes;

namespace FamApp.Pages;

public partial class LoginPage : ContentPage
{
    private Dictionary<string, string> validateData = new Dictionary<string, string>
    {
        { "timz", "123123" }
    };

    public class LinearGradientBrush : GradientBrush
    {
        public override bool IsEmpty => throw new NotImplementedException();
    }

    async void LoginAccount(object sender, EventArgs args)
    {
        string username = UsernameInput.Text;
        string password = PasswordInput.Text;
        if (CheckLoginData(username, password)) {
           bool action = await DisplayAlert("Angemeldet", "Login erfolgreich", "Okay", "Cancel");
            if (action)
            {
                await Navigation.PushAsync(new Hauptmenu());
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
        else
        {
            PasswordInput.Text = string.Empty;
            UsernameInput.Text = string.Empty;
            await DisplayAlert("Nicht Angemeldet", "Login fehlgeschlagen", "Okay", "Cancel");
        }
    }

    private bool CheckLoginData(string username, string password)
    {
        try
        {
            // TODO: hashedPassword aus der API holen
            string hashedPassword = PasswordHashing.Hash(validateData[username]);
            return PasswordHashing.Verify(password, hashedPassword);
        }
        catch
        {
            return false;
        }
    }

    public LoginPage()
	{
		InitializeComponent();
    }

}