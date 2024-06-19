using CommunityToolkit.Maui.Markup;
using System.Runtime.CompilerServices;

namespace FamApp.Frontend.Components
{
    static class CustomInput
    {
        public static StackLayout Create(
            string labelText, 
            string placeholder, 
            MainViewModel viewModel,
            bool password = false
            )
        {
            
            StackLayout views = new StackLayout()
            {
                Children =
                {

                    CustomLabel.SetterLabel(labelText,8,0,8,-8),

                    new Entry()
                    {
                        WidthRequest = 200,
                        Placeholder = placeholder,
                        TextColor = Colors.White,
                        FontSize = 15,
                        HeightRequest = 44,
                        IsPassword = password,
                        Keyboard = Keyboard.Text,

                     } .Margin(6, 6)
                       .Bind(Entry.TextProperty, nameof(viewModel.Name), BindingMode.TwoWay),
                 
                }

            }.Width(250);

            return views;
        }
    }
}
