namespace SlateAnalyzer;

public partial class SplashPage : ContentPage
{
	int count = 0;
	


    public SplashPage()
	{
		
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    
    private void OnEntriesClicked(object sender, EventArgs e)
    {
       // GoToEntries();
        //Shell.Current.GoToAsync(nameof(EntriesPage));
		//MainPage.
    }


    //[RelayCommand]
    //async void GoToEntries()
    //{
    //    await Shell.Current.GoToAsync(nameof(EntriesPage));
    //}
}

