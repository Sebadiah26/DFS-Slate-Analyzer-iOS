namespace SlateAnalyzer.Pages;


    public partial class EntriesPage : ContentPage
    {
       


        public EntriesPage(EntriesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            
        }

      
    }
