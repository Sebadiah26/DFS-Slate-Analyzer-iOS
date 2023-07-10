 namespace SlateAnalyzer;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(EntriesPage), typeof(EntriesPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
       
    }
}
