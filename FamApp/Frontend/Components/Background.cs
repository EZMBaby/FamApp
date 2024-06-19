using CommunityToolkit.Maui.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamApp.Frontend.Components
{
    static class CustomBackground
    {
        public static Frame SetterBackground(int right, int down, int left, int up)
        {
            Frame background = new Frame()
            {
                BackgroundColor = new Color(132, 127, 176),
                WidthRequest = 150,
                HeightRequest = 150,
                CornerRadius = 300,
            }.Margins(right, down, left, up);

            return background;
        }
    }
}
