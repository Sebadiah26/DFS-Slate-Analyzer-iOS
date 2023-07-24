namespace SlateAnalyzer;

public partial class App : Application
{
 

    public App()
	{
        
        InitializeComponent();
        Shell.Current.CurrentItem = Tabs;

        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(EntriesPage), typeof(EntriesPage));
        Routing.RegisterRoute(nameof(PlayersPage), typeof(PlayersPage));
        Routing.RegisterRoute(nameof(SlateAnalyzer.Pages.MainPage), typeof(MainPage));



    }
}
