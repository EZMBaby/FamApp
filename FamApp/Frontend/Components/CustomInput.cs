using CommunityToolkit.Maui.Markup;

namespace FamApp.Frontend.Components
{
    static class CustomInput
    {
        public static StackLayout Create(
            string labelText, 
            string placeholder, 
            MainViewModel viewModel
            )
        {
            StackLayout views = new StackLayout()
            {

                Children =
                {

                    new Label()
                    {
                       Text = viewModel.Name,
                        HorizontalTextAlignment = TextAlignment.Start,
                        VerticalTextAlignment = TextAlignment.End,
                        TextColor = Colors.White,
                    }.Margins(10, 0, 0, 0),
                   
                    new Entry()
                    {
                        Placeholder = placeholder,
                        TextColor = Colors.White,
                        FontSize = 15,
                        HeightRequest = 44,
                        Keyboard = Keyboard.Text,
                        BackgroundColor = Colors.AliceBlue,
                        
                     } .Margin(6, 6)
                       .Bind(Entry.TextProperty, nameof(viewModel.Name), BindingMode.TwoWay)
                }
                
            }.Width(400);

            return views;
        }
    }
}
