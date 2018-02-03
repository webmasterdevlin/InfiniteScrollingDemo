using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteScrollingDemo
{
    public class DataService
    {
        private readonly List<string> _data = new List<string>
        {
            "Sasuke", "Kakashi", "Naruto", "Madara", "Sakura", "Itachi", "Orochimaru", "Minato", "Obito",
            "Kiba", "Tsunade", "Hashirama", "Pain", "Jiraiya", "Rock Lee", "Shiakamaru", "Hinata", "Gaara",
            "Neji", "Kabuto", "Sarotobi", "Shino", "Guy", "Choji", "Ino", "Kurama",
            "Temari", "Killer Bee", "Sasori", "Kisame", "Tobirama", "Danzo", "Tenten", "Kaguya", "Konohamaru",
            "Zetsu", "Deidara", "Asuma", "Zabuza", "Sarada", "Kushina", "Karin", "Iruka", "Sai", "Konan",
            "Kankuro", "Yamato", "Haku", "Hidan", "Kurenai", "Kakazu",
        };

        public async Task<List<string>> GetItemsAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(2000);

            return _data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
