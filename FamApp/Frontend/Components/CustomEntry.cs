using CommunityToolkit.Maui.Markup;
//für den fall das wir mal ein Entry ohne Label brauchen
namespace FamApp.Frontend.Components
{
    static class PasswordEntry
    {
        public static Entry SetterEntry(string placeholder, int left, int up, int right, int down, MainViewModel viewModel)
        {
            Entry entry = new Entry()
            {
                WidthRequest = 200,
                Placeholder = placeholder,
                TextColor = Colors.White,
                FontSize = 15,
                HeightRequest = 44,
            }.Margin(6, 6)
                       .Bind(Entry.TextProperty, nameof(viewModel.Name), BindingMode.TwoWay);


     return entry;
        }
    }
}
