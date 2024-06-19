using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;

namespace FamApp.Frontend.Components
{
    static class Headline
    {
        public static Label SetterHeadline(string text,int right, int down, int left, int up ) 
        {
            Label headline = new Label()
            {
                FontSize = 37,
                HorizontalTextAlignment= TextAlignment.Center,
                Text = text,
            }.Margins(right,down,left,up);

            return headline;
        }
    }
}
