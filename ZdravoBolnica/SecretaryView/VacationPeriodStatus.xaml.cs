using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;
using System.Windows;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for VacationPeriodStatus.xaml
    /// </summary>
    public partial class VacationPeriodStatus : Window
    {
        public List<VacationPeriod> period = new List<VacationPeriod>();
        public VacationPeriodService vps = new VacationPeriodService();
        public VacationPeriod vp;
        public VacationPeriodStatus(VacationPeriod vacationPeriod)
        {
            InitializeComponent();
            //selectedVacationPeriod = vacationPeriod;
            statusBox.ItemsSource = Conversion.GetVacationPeriodStatusType();


            vp = vps.FindById(vacationPeriod.id);

            commentBox.Text = vp.comment;

            if (vp.status.ToString().Equals("accepted"))
            {
                statusBox.SelectedIndex = 0;
                //comment.Visibility = Visibility.Collapsed;
                // commentBox.Visibility = Visibility.Collapsed;
            }
            else if (vp.status.ToString().Equals("waiting"))
            {
                statusBox.SelectedIndex = 1;
                //comment.Visibility = Visibility.Collapsed;
                // commentBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                statusBox.SelectedIndex = 2;
                comment.Visibility = Visibility.Visible;
                rejectCommentBox.Visibility = Visibility.Visible;
            }
        }

        private void statusBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (statusBox.SelectedItem.Equals("Odbijeno"))
            {
                comment.Visibility = Visibility.Visible;
                rejectCommentBox.Visibility = Visibility.Visible;
                commentBox.Visibility = Visibility.Collapsed;
                commentVacationPeriod.Visibility = Visibility.Collapsed;
            }
            else
            {
                comment.Visibility = Visibility.Collapsed;
                rejectCommentBox.Visibility = Visibility.Collapsed;
                commentVacationPeriod.Visibility = Visibility.Visible;
                commentBox.Visibility = Visibility.Visible;
            }
        }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            vp.status = Conversion.StringToVacationStatusType(statusBox.SelectedItem.ToString());
            vp.rejectComment = rejectCommentBox.Text;

            vps.Update(vp);

            this.Hide();
            SecretaryView.Instance.SetContent(new VacationPeriodPage());

        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

