//using IntelliJ.Lang.Annotations;
using MauiApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entry = MauiApp1.Models.Entry;

namespace MauiApp1
{
    public class BlogClient : INotifyPropertyChanged
    {
        private HttpClient _client;
        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            private set
            {
                _isBusy = value;
                NotifyPropertyChanged();
            }
        }
        public BlogClient()
        {
            _client = new();
            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task<List<Entry>> GetEntries(CancellationToken cancellationToken)
        {
            IsBusy = true;
            var results = new List<MauiApp1.Models.Entry>();
            var url = "https://chrisschmi.github.io/scripts/posts.json";

            var res = await _client.GetAsync(url, cancellationToken);

            if (res.IsSuccessStatusCode)
            {
                var raw = await res.Content.ReadAsStringAsync(cancellationToken);
                var myDeserializedClass = JsonConvert.DeserializeObject<BlogRoot>(raw);

                if (myDeserializedClass.Entries.Any() == true)
                {
                    results.AddRange(myDeserializedClass.Entries);
                }
            }

            IsBusy = false;

            return results;
        }
    }
}
