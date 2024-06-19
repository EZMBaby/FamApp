using CommunityToolkit.Maui.Markup;
using FamApp.Frontend;
using FamApp.Frontend.Components;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace FamApp.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel viewModel = new();


    async void LoginBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    async void SignUpBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

    public MainPage()
    {
        Content = new Grid
        {
            RowDefinitions = Rows.Define(100,Star,100),

            ColumnDefinitions = Columns.Define(30,Star,30),

            Children =
            {      
                CustomBackground
                    .SetterBackground(-80,-40,0,0)
                    .Row(0)
                    .Column(0),

                new StackLayout
                {
                   Headline
                    .SetterHeadline("Welcome", 0,30,0,-10),

                   Subline
                    .SetterSubline("to"),

                   Headline
                    .SetterHeadline("FamApp", 0, -15, 0, 80),

                   Description
                    .SetterDescription("New Here? Sign up now!"),

                   CustomButton
                    .SetterButton("Sign up now", 0,0,0,30)
                    .Invoke(signup => signup.Clicked += SignUpBtnClicked),

                   Description
                    .SetterDescription("Already registered? Log in here"),

                   CustomButton
                    .SetterButton("Login")
                    .Invoke(button => button.Clicked += LoginBtnClicked),

                   CustomInput
                    .Create("Test", "Placeholder", viewModel)

                }.Row(1)
                    .Column(1)
                    .Margins(20,0,20,0),

                 CustomBackground
                    .SetterBackground(0,40,30,-80)
                    .Row(2)
                    .Column(2),


            }
            
        };
    }


}
