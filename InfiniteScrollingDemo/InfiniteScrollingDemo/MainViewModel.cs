using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Extended;

namespace InfiniteScrollingDemo
{
    public class MainViewModel : BaseViewModel
    {
        private const int PageSize = 10;
        private readonly DataService _dataService = new DataService();
        public InfiniteScrollCollection<string> Items { get; }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Items = new InfiniteScrollCollection<string>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    int page = Items.Count / PageSize;
                    List<string> items = await _dataService.GetItemsAsync(page, PageSize);
                    IsBusy = false;
                    return items;
                },
                OnCanLoadMore = () => Items.Count < 44
            };
            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            List<string> items = await _dataService.GetItemsAsync(0, PageSize);
            Items.AddRange(items);
        }
    }
}
