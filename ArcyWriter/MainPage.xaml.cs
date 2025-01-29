using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using ArcyWriter.DAL;

namespace ArcyWriter
{
    public partial class MainPage : ContentPage
    {
        private readonly AppDbContext _dbContext;
        public ObservableCollection<Project> Projects { get; set; } = new();

        public MainPage(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;

            LoadProjects();
            BindingContext = this;

            var pointerEnteredRecognizer = new PointerGestureRecognizer();
            pointerEnteredRecognizer.PointerEntered += OnPointerEntered;
            addProjectFrame.GestureRecognizers.Add(pointerEnteredRecognizer);

            var pointerExitedRecognizer = new PointerGestureRecognizer();
            pointerExitedRecognizer.PointerExited += OnPointerExited;
            addProjectFrame.GestureRecognizers.Add(pointerExitedRecognizer);
        }

        private void LoadProjects()
        {
            var projects = _dbContext.Projects.ToList();
            Projects.Clear();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
        }

        private void OnAddProjectTapped(object sender, EventArgs e)
        {
            var project = new Project { Title = "Untitled Novel", Author = "Unknown Author" };
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            Projects.Add(project);
        }

        private void OnPointerEntered(object sender, PointerEventArgs e)
        {
            addProjectFrame.BackgroundColor = Color.FromArgb("#303030");
            tooltipContainer.IsVisible = true;
            tooltipFrame.FadeTo(1, 300);
        }

        private void OnPointerExited(object sender, PointerEventArgs e)
        {
            addProjectFrame.BackgroundColor = Color.FromArgb("#373737");
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