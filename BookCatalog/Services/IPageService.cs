using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookCatalog.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
    }
}
