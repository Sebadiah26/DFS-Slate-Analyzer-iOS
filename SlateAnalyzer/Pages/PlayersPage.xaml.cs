namespace SlateAnalyzer.Pages;


    public partial class PlayersPage : ContentPage
    {
       


        public PlayersPage(PlayersViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
      
            
        }

      
    }
