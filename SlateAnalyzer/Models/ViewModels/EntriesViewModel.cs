using SlateAnalyzer.Services;
using SlateAnalyzer.Views;
using SlateAnalyzer.Models;
//using ContestModel = SlateAnalyzer.Models.ContestModel;
//using EntryModel = SlateAnalyzer.Models.EntryModel;

namespace SlateAnalyzer.ViewModels;

public partial class EntriesViewModel  : BaseViewModel, INotifyPropertyChanged
{
    public ObservableCollection<EntryModel> Entries { get; } = new();

    
    public ContestModel  contest { get; set; } = new();
    public EntryModel Entry { get; set; } = new();

    ContestService contestService;
    IConnectivity connectivity;
    IGeolocation geolocation;

   // public event PropertyChangedEventHandler PropertyChanged;

    public ContestModel Contest
    {
        get => this.contest;
        private set
        {
            this.contest = value;
            OnPropertyChanged();
        }
    }


    public EntriesViewModel(ContestService contestService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "DFS Contest Entries Viewer";
        this.contestService = contestService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
        //EntrySize = 100;
        //TextSize = "SmallLabel";
    }
    
    [RelayCommand]
    async Task GoToDetails(EntryModel entry)
    {
        if (entry == null)
        return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Entry", entry }
        });
    }

    [ObservableProperty]
    bool isRefreshing;

    //[ObservableProperty]
    //int entrySize;

    //[ObservableProperty]
    //string textSize;

    [RelayCommand]
    async Task GetEntriesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            IsRefreshing = true;
            IsBusy = true;

          

            this.Contest = await contestService.GetContest(); 

           

            if (Entries.Count != 0)
                Entries.Clear();

            foreach(var entry in this.Contest.Entries)
                Entries.Add(entry);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get contest: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    [RelayCommand]
    async Task GetClosestEntry()
    {
        if (IsBusy || Entries.Count == 0)
            return;

        try
        {
            // Get cached location, else get real location.
            var location = await geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }

            // Find closest monkey to us
            //var first = Entries.OrderBy(m => location.CalculateDistance(
            //    new Location(0, 0), DistanceUnits.Miles))
            //    .FirstOrDefault();
            var first = Entries.FirstOrDefault();
                

           // await Shell.Current.DisplayAlert("", first.Name + " " +
             //   "", "OK");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to query location: {ex.Message}");
          //  await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    //public void OnPropertyChanged([CallerMemberName] string name = "") =>
    //       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

}
