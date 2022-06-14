using System;
using System.Windows;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ResourceDictionary ThemeDictionary
        {
            get { return Current.Resources.MergedDictionaries[0]; }
        }


        public void ChangeTheme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public void ChangeLanguage(string currLang)
        {
            if (currLang.Equals("en-US"))
            {
                //      TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                //     TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
            }
        }



    }
}
