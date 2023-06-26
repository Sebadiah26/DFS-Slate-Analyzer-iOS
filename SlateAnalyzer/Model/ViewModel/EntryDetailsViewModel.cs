namespace SlateAnalyzer.ViewModel;

[QueryProperty(nameof(Entry), "Entry")]
public partial class EntryDetailsViewModel : BaseViewModel
{
    IMap map;
    public EntryDetailsViewModel(IMap map)
    {
        this.map = map;
    }

    [ObservableProperty]
    EntryModel entry;

    [RelayCommand]
    async Task OpenMap()
    {
        try
        {
            await map.OpenAsync(0, 0, new MapLaunchOptions
            {
                Name = Entry.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
           // await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }
}
