using MauiApp1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class BlogClient
    {

        public async Task<List<MauiApp1.Models.Entry>> GetEntries(CancellationToken cancellationToken)
        {
            var results = new List<MauiApp1.Models.Entry>();
            var url = "https://chrisschmi.github.io/scripts/posts.json";

            var client = new HttpClient();

            var res = await client.GetAsync(url, cancellationToken);

            if(res.IsSuccessStatusCode)
            {
                var raw = await res.Content.ReadAsStringAsync(cancellationToken);
                var myDeserializedClass = JsonConvert.DeserializeObject<BlogRoot>(raw);

                if (myDeserializedClass.Entries.Any() == true)
                {
                    results.AddRange(myDeserializedClass.Entries);
                }
            }

            return results;
        }

    }
}
