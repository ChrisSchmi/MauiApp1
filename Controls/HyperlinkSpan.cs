using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Controls
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label
    /// </summary>
    public class HyperlinkSpan : Span
    {
        public static readonly BindableProperty UrlProperty =
            BindableProperty.Create(nameof(Url), typeof(string), typeof(HyperlinkSpan), null);

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public HyperlinkSpan()
        {
            TextDecorations = TextDecorations.Underline;
            TextColor = Colors.Blue;

            var tapGestureRecognizer = new TapGestureRecognizer()
            {
                // Launcher.OpenAsync is provided by Essentials.
                Command = new Command(async () =>
                {
                    System.Diagnostics.Debug.WriteLine(Url);
                    await Launcher.OpenAsync(Url);
                })
            };


            var clickGestureRecognizer = new ClickGestureRecognizer()
            {
                // Launcher.OpenAsync is provided by Essentials.
                Command = new Command(async () =>
                {
                    System.Diagnostics.Debug.WriteLine(Url);
                    await Launcher.OpenAsync(Url);
                })
            };

            GestureRecognizers.Add(tapGestureRecognizer);
            GestureRecognizers.Add(clickGestureRecognizer);
        }
    }
}
