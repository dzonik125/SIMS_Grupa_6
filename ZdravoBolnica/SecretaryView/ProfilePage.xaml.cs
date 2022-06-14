using SIMS.SecretaryView.ViewModel;
using System.Windows.Controls;

namespace SIMS.SecretaryView
{

    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {

            InitializeComponent();
            this.DataContext = new ProfilePageViewModel();
        }
    }
}
