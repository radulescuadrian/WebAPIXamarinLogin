using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFTests.Annotations;
using WPFTests.Services;

namespace WPFTests.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ApiServices _apiServices = new ApiServices();

        public string Token { get; set; }

        private IEnumerable<string> _values;
        public IEnumerable<string> Values
        {
            get => _values;
            set
            {
                _values = value;
                OnPropertyChanged();
            }
        }

        public async void GetValues()
        {
            Values = await _apiServices.GetValuesAsync(Token);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
