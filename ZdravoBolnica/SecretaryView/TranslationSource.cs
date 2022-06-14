namespace SIMS
{
    /*    public class TranslationSource : INotifyPropertyChanged
        {
            private static readonly TranslationSource instance = new TranslationSource();

            public static TranslationSource Instance
            {
                get { return instance; }
            }

         private readonly ResourceManager resManager = new ResourceManager("SIMS.SecretaryView", Assembly.GetExecutingAssembly());
            private CultureInfo currentCulture = null;

            public string this[string key]
            {
                get { return this.resManager.GetString(key, this.currentCulture); }
            }

            public CultureInfo CurrentCulture
            {
                get { return this.currentCulture; }
                set
                {
                    if (this.currentCulture != value)
                    {
                        this.currentCulture = value;
                        var @event = this.PropertyChanged;
                        if (@event != null)
                        {
                            @event.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                        }
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        public class LocExtension : Binding
        {
            public LocExtension(string name)
                : base("[" + name + "]")
            {
                this.Mode = BindingMode.OneWay;
                this.Source = TranslationSource.Instance;
            }
        }*/
}
