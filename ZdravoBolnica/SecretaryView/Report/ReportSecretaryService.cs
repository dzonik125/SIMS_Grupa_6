using Model;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace Service
{
    public class ReportSecretaryService
    {
        AppointmentService appointmentService = new AppointmentService();
        public BindingList<Appointment> list1 = new BindingList<Appointment>();
        public RoomService roomService = new RoomService();
        public DateTime fromDate;
        public DateTime toDate;
        public void CreatePDF()
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 30);
                string textPDF = "    Zauzetost soba u bolnici";
                graphics.DrawString(textPDF, font, PdfBrushes.Black, new PointF(70, 0));
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
                table.Columns.Add("Broj sobe");
                table.Columns.Add("Tip");
                table.Columns.Add("Vreme pocetka");
                table.Columns.Add("Vreme zavrsetka");
                InitDataGrid();
                foreach (Appointment appointment in list1)
                {

                    table.Rows.Add(new string[] {appointment.Room.roomNum.ToString(),
                                                 appointment.Room.RoomTypeString,
                                                 appointment.startTime.ToString(),
                                                 appointment.GetEndTime().ToString()});
                }
                pdfLightTable.DataSource = table;
                pdfLightTable.Style.ShowHeader = true;
                pdfLightTable.Draw(page, new PointF(0, 100));
                doc.Save(@"..\..\..\Report\ScheduledAppointmentsReport.pdf");
                doc.Close(true);
            }
        }

        public void SendMessage()
        {
            MessageBox.Show("Izveštaj je uspešno kreiran!");
        }

        private void InitDataGrid()
        {
            BindingList<Appointment> examinationAppointments = new BindingList<Appointment>();
            list1 = new BindingList<Appointment>();
            FindDate();


            foreach (Appointment appointment in appointmentService.GetAllApointments())
            {
                if (appointment.startTime.CompareTo(fromDate) > 0 && appointment.startTime.CompareTo(toDate) < 0)
                {
                    examinationAppointments.Add(appointment);
                }
            }

            var reportExaminationsSorted = new BindingList<Appointment>(examinationAppointments.OrderBy(x => x.startTime).ToList());
            foreach (Room room in roomService.FindAll())
            {
                foreach (Appointment exApp in reportExaminationsSorted)
                {
                    if (room.roomNum == exApp.Room.roomNum)
                    {
                        list1.Add(exApp);
                    }
                }
            }

        }

        private void FindDate()
        {
            fromDate = DateTime.Today;
            toDate = DateTime.Today.AddDays(20);
        }



        public void GenerateReport()
        {
            CreatePDF();
            SendMessage();
        }
    }
}
