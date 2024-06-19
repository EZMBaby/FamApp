using CommunityToolkit.Maui.Markup;
using FamApp.Frontend;
using FamApp.Frontend.Components;
using FamApp.Frontend.Handling;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace FamApp.Pages;

public partial class LoginPage : ContentPage
{
    private readonly MainViewModel viewModel = new();
    private Dictionary<string, string> validateData = new Dictionary<string, string>
    {
        { "timz", PasswordHashing.Hash("123123") }
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
            return PasswordHashing.Verify(password, validateData[username]);
        }
        catch
        {
            return false;
        }
    }

    public LoginPage()
	{
        Content = new Grid()
        {
            RowDefinitions = Rows.Define(100, Star, 100),

            ColumnDefinitions = Columns.Define(30, Star, 30),

            Children =
            {
                 CustomBackground.SetterBackground(-80,-40,0,0).Row(0).Column(0),

                new StackLayout
                {
                    Headline.SetterHeadline("Log in", 0, -20,0,-8),

                    Subline.SetterSubline("Sign in to continue", 0,0,0,80),

                    CustomInput.Create("Username", "Username",viewModel),

                    CustomInput.Create("Passwort", "Passwort",viewModel),

                    CustomButton.SetterButton("Anmelden",0,30,0,10),
                    //.Invoke(button => button.Clicked += LoginAccount),

                    Subline.SetterSubline("Already Registered? Click here!"),

                    CustomButton.SetterButton("Jetzt Registrieren")
                    .Invoke(button => button.Clicked += SignUpBtnClicked)

                }.Row(1).Column(1).Margins(20,0,20,0),

                 CustomBackground.SetterBackground(0,40,30,-80).Row(2).Column(2),

            }
        };
    }
    async void SignUpBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

}