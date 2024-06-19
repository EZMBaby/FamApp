using CommunityToolkit.Maui.Markup;
using System.Runtime.CompilerServices;

namespace FamApp.Frontend.Components
{
    static class CustomInput
    {
        public static StackLayout Create(
            string labelText, 
            string placeholder,
            MainViewModel viewModel)
        {
            
            StackLayout views = new StackLayout()
            {
                Children =
                {
                    new Label()
                    {
                        Text = labelText,
                        HorizontalTextAlignment = TextAlignment.Start,
                        VerticalTextAlignment = TextAlignment.End,
                        TextColor = Colors.White,
                    }.Margins(10, 0, 0, 0)
                        .Bind(Label.TextProperty, getter: (MainViewModel mvm) => mvm.Name),

                    new Entry()
                    {
                        Keyboard = Keyboard.Text,
                        BackgroundColor = Colors.AliceBlue,
                    }.FontSize(15)
                            .Placeholder(placeholder)
                            .TextColor(Colors.White)
                            .Height(44)
                            .Margin(6, 6)
                            .Bind(Entry.TextProperty, 
                                getter: (MainViewModel mvm) => mvm.Name,
                                setter: (MainViewModel mvm, string code) => mvm.Name = code)
                }
            }.Width(400);

            return views;
        }
    }
}
