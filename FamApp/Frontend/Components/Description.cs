using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Markup;

namespace FamApp.Frontend.Components
{
    static class Description
    {
        public static Label SetterDescription(string text)
        {
            Label description = new Label()
            {
                Text = text,
                HorizontalTextAlignment = TextAlignment.Center,
            }.Margins(0, 0, 0, 10);
            return description;
    }

    }
}
