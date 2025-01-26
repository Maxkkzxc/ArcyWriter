namespace ArcyWriter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ApplyTheme(AppTheme.Dark);

            MainPage = new AppShell();
        }

        public void ApplyTheme(AppTheme theme)
        {
            Current.Resources.MergedDictionaries.Clear();

            if (theme == AppTheme.Dark)
            {
                var darkTheme = (ResourceDictionary)Current.Resources["DarkTheme"];
                Current.Resources.MergedDictionaries.Add(darkTheme);
            }
            else
            {
                var lightTheme = (ResourceDictionary)Current.Resources["LightTheme"];
                Current.Resources.MergedDictionaries.Add(lightTheme);
            }

            Current.UserAppTheme = theme;

            if (MainPage is MainPage mainPage)
            {
                mainPage.UpdateTheme();
            }
        }
    }
}
