using SIMS.Model;
using SIMS.Service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SIMS.SecretaryView
{
    public partial class VacationPeriodPage : Page
    {
        public BindingList<VacationPeriod> list = new BindingList<VacationPeriod>();
        public List<VacationPeriod> vacationPeriods = new List<VacationPeriod>();
        public VacationPeriodService vacationPeriodService = new VacationPeriodService();

        public List<VacationPeriod> period = new List<VacationPeriod>();
        public VacationPeriod vp;
        public VacationPeriodPage()
        {
            InitializeComponent();

            comment.Visibility = Visibility.Collapsed;
            rejectCommentBox.Visibility = Visibility.Collapsed;
            commentBox.Visibility = Visibility.Collapsed;
            commentVacationPeriod.Visibility = Visibility.Collapsed;
            statusLabel.Visibility = Visibility.Collapsed;
            statusBox.Visibility = Visibility.Collapsed;
            accept.Visibility = Visibility.Collapsed;
            reject.Visibility = Visibility.Collapsed;

            vacationPeriodTable.ItemsSource = list;
            vacationPeriods = vacationPeriodService.FindAll();
            vacationPeriodService.bindDoctorsWithVacationPeriods(vacationPeriods);
            foreach (VacationPeriod v in vacationPeriods)
            {
                list.Add(v);
            }

        }

        private void statusBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (statusBox.SelectedItem.Equals("Odbijeno"))
            {
                rejectCommentBox.IsReadOnly = false;
                comment.Visibility = Visibility.Visible;
                rejectCommentBox.Visibility = Visibility.Visible;

                commentVacationPeriod.Visibility = Visibility.Collapsed;
                commentBox.Visibility = Visibility.Collapsed;

                statusLabel.Visibility = Visibility.Visible;
                statusBox.Visibility = Visibility.Visible;
                accept.Visibility = Visibility.Visible;
                reject.Visibility = Visibility.Visible;
            }
            else if (statusBox.SelectedItem.Equals("Odobreno"))
            {
                comment.Visibility = Visibility.Collapsed;
                rejectCommentBox.Visibility = Visibility.Collapsed;
                commentVacationPeriod.Visibility = Visibility.Collapsed;
                commentBox.Visibility = Visibility.Collapsed;
                statusLabel.Visibility = Visibility.Visible;
                statusBox.Visibility = Visibility.Visible;
                accept.Visibility = Visibility.Visible;
                reject.Visibility = Visibility.Visible;
            }
            else
            {
                comment.Visibility = Visibility.Collapsed;
                rejectCommentBox.Visibility = Visibility.Collapsed;
                commentVacationPeriod.Visibility = Visibility.Visible;
                commentBox.Visibility = Visibility.Visible;
                statusLabel.Visibility = Visibility.Visible;
                statusBox.Visibility = Visibility.Visible;
                accept.Visibility = Visibility.Visible;
                reject.Visibility = Visibility.Visible;
            }
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataGridCellTarget = (DataGridCell)sender;
            VacationPeriod selectedVacationPeriod = dataGridCellTarget.DataContext as VacationPeriod;

            if (Conversion.VacationPeriodStatusTypeToString(selectedVacationPeriod.status).Equals("Odbijeno"))
            {
                rejectCommentBox.IsReadOnly = true;
                vp = vacationPeriodService.FindById(selectedVacationPeriod.id);
                rejectCommentBox.Text = vp.rejectComment;
                statusBox.SelectedIndex = 2;
                comment.Visibility = Visibility.Visible;
                rejectCommentBox.Visibility = Visibility.Visible;
                commentBox.Visibility = Visibility.Collapsed;
                commentVacationPeriod.Visibility = Visibility.Collapsed;
                statusLabel.Visibility = Visibility.Collapsed;
                statusBox.Visibility = Visibility.Collapsed;
                accept.Visibility = Visibility.Collapsed;
                reject.Visibility = Visibility.Collapsed;
                statusBox.IsEditable = false;
                statusBox.IsHitTestVisible = false;
                statusBox.Focusable = false;
            }
            else if (Conversion.VacationPeriodStatusTypeToString(selectedVacationPeriod.status).Equals("Na cekanju"))
            {

                statusBox.ItemsSource = Conversion.GetVacationPeriodStatusType();
                vp = vacationPeriodService.FindById(selectedVacationPeriod.id);
                commentBox.Text = vp.comment;
                commentBox.IsReadOnly = true;
                // statusBox.IsEditable = true;
                statusBox.IsHitTestVisible = true;
                statusBox.Focusable = true;
                if (vp.status.ToString().Equals("accepted"))
                {
                    statusBox.SelectedIndex = 0;
                }
                else if (vp.status.ToString().Equals("waiting"))
                {
                    statusBox.SelectedIndex = 1;
                }
            }
            else
            {
                SecretaryView.Instance.SetContent(new VacationPeriodPage());
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            vp.status = Conversion.StringToVacationStatusType(statusBox.SelectedItem.ToString());
            vp.rejectComment = rejectCommentBox.Text;

            vacationPeriodService.Update(vp);
            SecretaryView.Instance.SetContent(new VacationPeriodPage());


        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            SecretaryView.Instance.SetContent(new VacationPeriodPage());
        }


    }
}
