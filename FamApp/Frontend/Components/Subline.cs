using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;

namespace FamApp.Frontend.Components
{
    static class Subline
    {
        public static Label SetterSubline(string text, int right = 0, int up = 0, int left = 0, int down = 0)
        {
        Label subline = new Label()
        {
            Text = text,
            FontSize = 14,
            HorizontalTextAlignment= TextAlignment.Center,
        }.Margins(right, up, left, down);
            return subline;
        }
    }
}
