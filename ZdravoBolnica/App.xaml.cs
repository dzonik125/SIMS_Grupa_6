using System.Windows;
using static SIMS.TranslationSoruce;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ChangeLanguage(string currLang)
        {
            if (currLang.Equals("en-US"))
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
            }
        }



    }
}
