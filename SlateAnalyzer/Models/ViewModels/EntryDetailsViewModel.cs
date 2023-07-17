using System.Net.Mail;
using System.Xml.Linq;

namespace SlateAnalyzer.ViewModels;


[QueryProperty(nameof(Entry), "Entry")]
public partial class EntryDetailsViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
{
    private List<EntryMemberModel> entryMember;
    private EntryModel entry;

   
    public event PropertyChangedEventHandler PropertyChanged;


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


    public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Entry = query["Entry"] as EntryModel;
        EntryMembers = Entry.EntryMembers;
    }
}
