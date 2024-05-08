using FamApp.Classes;
using System.Text.RegularExpressions;

namespace FamApp.Pages;

public partial class SignUpPage : ContentPage
{
    private User newUser;
    private Regex regex;
    public User NewUser { get { return newUser; } set { newUser = value; } }
	public SignUpPage()
	{
		InitializeComponent();

        NewUser = new User();
        regex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
       
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