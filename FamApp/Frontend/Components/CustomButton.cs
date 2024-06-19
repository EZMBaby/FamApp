using CommunityToolkit.Maui.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamApp.Frontend.Components
{
    static class CustomButton
    {
        public static Button SetterButton(string text, int right= 0, int up = 0, int left = 0, int down = 0)
        {
            Button button = new Button()
            {
                Text = text,


            }.Margins(right, up, left, down);

            return button;
        }

        public static TButton OnCLicked<TButton>(this TButton button, EventHandler onClick) where TButton : Button
        {
            button.Clicked += onClick;
            return button;
        }
    }
}
