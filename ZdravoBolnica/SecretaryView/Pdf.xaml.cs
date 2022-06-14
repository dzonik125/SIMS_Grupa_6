using System.Windows;

namespace SIMS.SecretaryView
{
    /// <summary>
    /// Interaction logic for Pdf.xaml
    /// </summary>
    public partial class Pdf : Window
    {
        public Pdf()
        {
            InitializeComponent();
            pdfViewer.Load(@"..\..\..\Report\ScheduledAppointmentsReport.pdf");
        }
    }
}
