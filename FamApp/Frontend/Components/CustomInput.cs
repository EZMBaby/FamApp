using CommunityToolkit.Maui.Markup;
using FamApp.Pages;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace FamApp.Frontend.Components
{
    class CustomInput
    {
        public Entry GetCustomInput(string text, MainViewModel viewModel)
        {
            // TODO: Grid as Layout for Component
            Entry entry = new Entry()
            {
                Keyboard = Keyboard.Numeric,
                BackgroundColor = Colors.AliceBlue
            }.FontSize(15)
                    .Placeholder(text)
                    .TextColor(Colors.Black)
                    .Height(44)
                    .Margin(6, 6)
                    .Bind(Entry.TextProperty, nameof(viewModel.Name), BindingMode.TwoWay);

            return entry;
        }
    }
}
