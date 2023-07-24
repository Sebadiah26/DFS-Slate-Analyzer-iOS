namespace SlateAnalyzer.Pages;
public partial class DetailsPage : ContentPage
{
	public DetailsPage(EntryDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
       
    }
}