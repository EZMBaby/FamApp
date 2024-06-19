using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;

namespace FamApp.Frontend.Components
{
    static class CustomLabel
    {
        public static Label SetterLabel(string text, int left = 0, int up = 0, int right = 0, int down = 0, int fontsize = 12)
        {
            Label label = new Label()
            {
                FontSize = fontsize,
                Text = text,
                HorizontalTextAlignment = TextAlignment.Start,


            }.Margins(right, up, left, down);
            return label;
        }
    }
}

