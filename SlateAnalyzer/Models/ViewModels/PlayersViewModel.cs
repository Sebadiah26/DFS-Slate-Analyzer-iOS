using SlateAnalyzer.Services;
using SlateAnalyzer.Views;
using SlateAnalyzer.Models;
//using ContestModel = SlateAnalyzer.Models.ContestModel;
//using EntryModel = SlateAnalyzer.Models.EntryModel;

namespace SlateAnalyzer.ViewModels;

public partial class PlayersViewModel  : BaseViewModel, INotifyPropertyChanged
{
   
    public ObservableCollection<ContestPlayerModel> ContestPlayers { get; } = new();

    public ContestModel  contest { get; set; } = new();
    public ContestPlayerModel contestPlayer { get; set; } = new();

    ContestService contestService;
    IConnectivity connectivity;
    IGeolocation geolocation;

  

    public ContestModel Contest
    {
        get => this.contest;
        private set
        {
            this.contest = value;
            OnPropertyChanged();
        }
    }


    public PlayersViewModel(ContestService contestService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "DFS GameDay Live";
        this.contestService = contestService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
        //EntrySize = 100;
        //TextSize = "SmallLabel";

        Shell.Current.Title = "DFS GameDay Live";
        Fetch();

    }

    async void Fetch()
    {

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


        if (ContestPlayers.Count != 0)
            ContestPlayers.Clear();

        foreach (var contestPlayer in this.Contest.ContestPlayers.OrderByDescending(x => Decimal.Parse(x.Drafted.Replace("%", ""))))
            ContestPlayers.Add(contestPlayer);

        OnPropertyChanged(nameof(ContestPlayers));

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
    async Task GoToDetails(ContestPlayerModel entry)
    {
        if (entry == null)
        return;

        await Shell.Current.GoToAsync(nameof(PlayerDetailsPage), true, new Dictionary<string, object>
        {
            {"ContestPlayer", contestPlayer }
        });
    }

    [ObservableProperty]
    bool isRefreshing;

    //[ObservableProperty]
    //int entrySize;

    //[ObservableProperty]
    //string textSize;

    [RelayCommand]
    async Task GetPlayersAsync()
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

           

            if (ContestPlayers.Count != 0)
                ContestPlayers.Clear();

            foreach(var contestPlayer in this.Contest.ContestPlayers)
                ContestPlayers.Add(contestPlayer);

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
        if (IsBusy || ContestPlayers.Count == 0)
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
            var first = ContestPlayers.FirstOrDefault();
                

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
