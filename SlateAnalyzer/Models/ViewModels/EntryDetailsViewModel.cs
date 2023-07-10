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


    // public EntryMemberModel EntryMember { get; } = new();

    public EntryDetailsViewModel()
    { }

    public List<EntryMemberModel> EntryMembers
    {
        get => this.entryMember;
        private set => this.entryMember = value;
    }

    public EntryModel Entry
    {
        get => this.entry;
        private set => this.entry = value;
    }

    //[ObservableProperty]
    //EntryModel entry;

    //[ObservableProperty]
    //EntryMemberModel entryMember;



    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Entry = query["Entry"] as EntryModel;
        EntryMembers = Entry.EntryMembers;
    }
}
