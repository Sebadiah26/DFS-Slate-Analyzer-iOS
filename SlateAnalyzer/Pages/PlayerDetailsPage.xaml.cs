namespace SlateAnalyzer.Pages;
public partial class PlayerDetailsPage : ContentPage
{
	public PlayerDetailsPage(PlayerDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
       
    }
}