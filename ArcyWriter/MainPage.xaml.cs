namespace ArcyWriter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var pointerEnteredRecognizer = new PointerGestureRecognizer();
            pointerEnteredRecognizer.PointerEntered += OnPointerEntered;
            graphicsFrame.GestureRecognizers.Add(pointerEnteredRecognizer);

            var pointerExitedRecognizer = new PointerGestureRecognizer();
            pointerExitedRecognizer.PointerExited += OnPointerExited;
            graphicsFrame.GestureRecognizers.Add(pointerExitedRecognizer);
        }

        private void OnPointerEntered(object sender, PointerEventArgs e)
        {
            graphicsFrame.BackgroundColor = Color.FromArgb("#303030");

            tooltipContainer.IsVisible = true;

            tooltipFrame.FadeTo(1, 300);
        } 

        private void OnPointerExited(object sender, PointerEventArgs e)
        {
            graphicsFrame.BackgroundColor = Color.FromArgb("#373737");

            tooltipFrame.FadeTo(0, 50).ContinueWith((t) =>
            {
                tooltipFrame.Dispatcher.Dispatch(() =>
                {
                    tooltipContainer.IsVisible = false; 
                });
            });
        }


        public void UpdateTheme()
        {
            BackgroundColor = (Color)Application.Current.Resources["PageBackgroundColor"];
        }
    }
}
