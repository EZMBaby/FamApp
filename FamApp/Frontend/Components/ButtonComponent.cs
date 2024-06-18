namespace FamApp.Frontend.Components
{
    class ButtonComponent : Button
    {
        public static readonly BindableProperty HoverBackgroundProperty =
            BindableProperty.Create(nameof(HoverBackgroundProperty),
                typeof(Color), typeof(ButtonComponent), Colors.LightYellow, BindingMode.OneWay);

        protected Color originalBackgroundColor;
        public Color HoverBackgroundColor
        {
            get { return (Color)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }

        public ButtonComponent()
        {
            PointerGestureRecognizer pointerGestureRecognizer = new PointerGestureRecognizer();
            pointerGestureRecognizer.PointerEntered += PointerGestureRecognizer_PointerEntered;
            pointerGestureRecognizer.PointerExited += PointerGestureRecognizer_PointerExited;
            GestureRecognizers.Add(pointerGestureRecognizer);
        }

        private void PointerGestureRecognizer_PointerExited(object? sender, PointerEventArgs e)
        {
            originalBackgroundColor = BackgroundColor;
            BackgroundColor = HoverBackgroundColor;
        }

        private void PointerGestureRecognizer_PointerEntered(object? sender, PointerEventArgs e)
        {
            BackgroundColor = originalBackgroundColor;
            originalBackgroundColor = null;
        }
    }
}
