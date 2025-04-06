using System.Collections.Generic;
using System.Windows.Controls;

namespace UBYS_WPF.Services
{
    public class CompositeNavigationService : INavigationService
    {
        private readonly IEnumerable<INavigationService> _navigationServices;

        public CompositeNavigationService(params INavigationService[] navigationServices)
        {
            _navigationServices = navigationServices;
        }

        public void Navigate()
        {
            foreach (var navigationService in _navigationServices)
            {
                try
                {
                    navigationService.Navigate();
                }
                catch (Exception ex)
                {
                    // Hata yönetimi (loglama veya özel işleme)
                    Console.WriteLine($"Error navigating: {ex.Message}");
                }
            }
        }
    }

}
