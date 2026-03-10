using SampleProject.Views;

namespace SampleProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
        }
    }
}