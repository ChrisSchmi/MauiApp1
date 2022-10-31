using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;
using System.Collections.ObjectModel;

namespace MauiApp1.Models
{
    public class MainPageModel : INotifyPropertyChanged
    {
        CancellationTokenSource _cancellationTokenSource;
        INavigation Navigation;
        public MainPageModel(BlogClient blogClient, INavigation navigation)
        {
            if(blogClient == null)
            {
                throw new ArgumentNullException($"{nameof(blogClient)} can not be null!");
            }

            if (navigation == null)
            {
                throw new ArgumentNullException($"{nameof(navigation)} can not be null!");
            }


            Navigation = navigation;

            _cancellationTokenSource = new CancellationTokenSource();

            

            var cancellationToken = _cancellationTokenSource.Token;

            _blogClient = blogClient;
            _blogEntries = new List<Entry>();
            IsLoading = false;
            HasDelay = false;

            LoadEntries = new Command(async () => {

                    if (_blogClient.IsBusy == false)
                    {
                        await LoadBlogEntries(cancellationToken);
                    }             
                });

            OpenEntry = new Command(async (payload) => {
                // https://stackoverflow.com/questions/73447092/net-maui-swipeitem-command-binding-to-viewmodel-ancestor-fails

                if (payload != null && payload is Entry)
                {
                    var entry = ((Entry)payload);

                    await Navigation.PushAsync(new BlogDatailsPage(entry));


                    Debug.WriteLine($"Open: {entry.Date}");
                }
            
            });

            var t = LoadBlogEntries(cancellationToken);

            Task.Run(() => t);
        }

        private List<Entry> _blogEntries;
        public List<Entry> BlogEntries
        {
            set
            {
                _blogEntries.Clear();
                _blogEntries = value;
                NotifyPropertyChanged("BlogEntries");
            }
            get
            {
                return _blogEntries;
            }
        }


        private BlogClient _blogClient;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand LoadEntries { get; set; }

        public ICommand OpenEntry { get; set; }

        public bool HasDelay { get; set; }


        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }
        

        public async Task LoadBlogEntries(CancellationToken cancellationToken)
        {
            try
            {
                if (_blogClient.IsBusy == true)
                {
                    Debug.WriteLine("_blogClient already busy...");
                    return;
                }

                Debug.WriteLine("LoadBlogEntries started...");

                IsLoading = true;


                var entries = await _blogClient?.GetEntries(cancellationToken);

                if (HasDelay == true)
                {
                    await Task.Delay(3000);
                }


                if (entries.Any() == true)
                {
                    BlogEntries = entries;
                }

                IsLoading = false;

                Debug.WriteLine("LoadBlogEntries finished...");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                IsLoading = false;
            }
        }

    }
}
