using CommunityToolkit.Maui.Markup;
using FamApp.Frontend;
using FamApp.Frontend.Components;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace FamApp.Pages;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel viewModel = new();
    CustomInput input = new();

    public MainPage()
    {
        Content = new StackLayout
        {

            Children =
            {
                new Label()
                    .Text("Customer name:"),

                input.GetCustomInput("Test1", viewModel),
                input.GetCustomInput("Test2", viewModel),
                input.GetCustomInput("Test3", viewModel)
            }
        };
    }


}
