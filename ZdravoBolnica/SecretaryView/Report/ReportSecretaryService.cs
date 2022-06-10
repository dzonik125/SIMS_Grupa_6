using Model;
using Repository;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Data;
using System.Drawing;
using System.Windows;

namespace Service
{
    public class ReportSecretaryService
    {
        private DateTime fromDate, toDate;
        RoomsCRUD rr = new RoomsCRUD();
        public void CreatePDF()
        {
            using (PdfDocument doc = new PdfDocument())
            {
                // FindDate();
                PdfPage page = doc.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                string textPDF = "Sobe u bolnici " + fromDate.ToShortDateString() + " - " + toDate.ToShortDateString();
                graphics.DrawString(textPDF, font, PdfBrushes.Black, new PointF(70, 0));
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
                table.Columns.Add("Broj sobe");
                table.Columns.Add("Tip");
                //  table.Columns.Add("Time");
                //   table.Columns.Add("Patient");
                //  table.Columns.Add("Doctor");
                //  table.Columns.Add("Room");
                // table.Columns.Add("Appointment type");
                foreach (Room room in rr.FindAll())
                {

                    table.Rows.Add(new string[] {room.roomNum.ToString(),
                                                 room.RoomTypeString,});
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
            MessageBox.Show("Report is succesfully created!");
        }

        private void FindDate()
        {
            fromDate = DateTime.Today;
            toDate = DateTime.Today.AddDays(6);
        }

        public void GenerateReport()
        {
            CreatePDF();
            SendMessage();
        }
    }
}
