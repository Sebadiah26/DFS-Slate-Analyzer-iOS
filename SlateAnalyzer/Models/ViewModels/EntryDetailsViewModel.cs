using System.Net.Mail;
using System.Xml.Linq;

namespace SlateAnalyzer.ViewModels;


[QueryProperty(nameof(Entry), "Entry")]
public partial class EntryDetailsViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
{
    private List<EntryMemberModel> entryMember;
    private EntryModel entry;

    //public List<EntryMemberModel> EntryMembers { get; set; } = new();

    //public EntryModel Entry { get; set; } = new();
    public event PropertyChangedEventHandler PropertyChanged;

    // public EntryMemberModel EntryMember { get; } = new();

    public EntryDetailsViewModel()
    { }

    public List<EntryMemberModel> EntryMembers
    {
        get => this.entryMember;
        private set
        {
            this.entryMember = value;
            OnPropertyChanged();
        }
    }

    public EntryModel Entry
    {
        get => this.entry;
        private set { this.entry = value;
            OnPropertyChanged();
        }
    }

    //[ObservableProperty]
    //EntryModel entry;

    //[ObservableProperty]
    //EntryMemberModel entryMember;

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Entry = query["Entry"] as EntryModel;
        EntryMembers = Entry.EntryMembers;
    }
}
