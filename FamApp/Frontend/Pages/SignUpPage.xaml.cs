using CommunityToolkit.Maui.Markup;
using FamApp.Frontend;
using FamApp.Frontend.Classes;
using FamApp.Frontend.Components;
using System.Text.RegularExpressions;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace FamApp.Pages;

public partial class SignUpPage : ContentPage
{
    private readonly MainViewModel viewModel = new();
    private User newUser;
    private Regex regex;
    public User NewUser { get { return newUser; } set { newUser = value; } }
    public SignUpPage()
    {
        InitializeComponent();

        NewUser = new User();
        regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");

        Content = new Grid
        {
            RowDefinitions = Rows.Define(100, Star, 100),

            ColumnDefinitions = Columns.Define(30, Star, 30),

            Children =
            {
                 CustomBackground.SetterBackground(-80,-40,0,0)
                    .Row(0)
                    .Column(0),

                  new StackLayout
                {
                   Headline
                    .SetterHeadline("Creat new", 0,30,0,-10),

                   Headline
                   .SetterHeadline("Account" ,0,0,0,30),

                  CustomInput.Create("Vorname","Vorname", viewModel),
                  CustomInput.Create("Nachname","Nachname", viewModel),
                  CustomInput.Create("Email","Email", viewModel),
                  CustomInput.Create("Passwort","Passwort", viewModel, true),

                  CustomButton.SetterButton("Jetzt registieren",0,0,0,10)
                  .Invoke(button => button.Clicked += OnRegisterClick),
                  

                  CustomButton.SetterButton("Einloggen")
                  .Invoke(button => button.Clicked += LoginBtnClicked),
                  }.Row(0)
                   .RowSpan(2)
                   .Column(1)
                   .Margins(20,0,20,0),
                  CustomBackground
                    .SetterBackground(0, 40, 30, -80)
                    .Row(2)
                    .Column(2),
        } 
        };
    }
    async void LoginBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
    async void OnRegisterClick(object sender, EventArgs e)
    {
        Entry firstNameEntry = FirstNameInput;
        Entry lastNameEntry = LastNameInput;
        Entry emailEntry = EmailInput;
        Entry passwordEntry = PasswordInput;

        Entry[] entryArray = [
            firstNameEntry,
            lastNameEntry,
            emailEntry,
            passwordEntry
        ];

        bool valid = true;

        foreach ( var entry in entryArray )
        {
            if (entry.Text == null || entry.Text == "")
            {
                valid = false;
            }
        }

        if (!valid)
        {
            await DisplayAlert("Error", "", "OK");
        }

        else
        {
            User newUser = new();
            newUser.First_Name = firstNameEntry.Text;
            newUser.Last_Name = lastNameEntry.Text;
            newUser.Email = emailEntry.Text;
            newUser.Password = passwordEntry.Text;

            bool action = await DisplayAlert("Registriert", "Weiter zu Login?", "Okay", "Cancel");
            if (action)
            {
                await Navigation.PushAsync(new LoginPage());
            }

            else
            {
                await Navigation.PopAsync();
            }

            //User retrieve = User.CreateNewUser(newUser).Result;
        }
    }
}