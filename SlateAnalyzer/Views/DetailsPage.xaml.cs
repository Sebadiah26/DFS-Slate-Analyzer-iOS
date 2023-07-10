namespace SlateAnalyzer.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(EntryDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}