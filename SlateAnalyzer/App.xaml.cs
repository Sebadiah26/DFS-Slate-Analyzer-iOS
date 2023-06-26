namespace SlateAnalyzer;

public partial class App : Application
{
   

    public App(EntriesViewModel viewModel)
	{
        
        InitializeComponent();
        MainPage = new AppShell();
        //MainPage = new EntriesPage(viewModel);
    }
}
