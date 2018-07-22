using Inspections.Model;
using Inspections.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Inspections.ViewModel
{
    public class InspectionListViewModel : INotifyPropertyChanged
    {
        public InspectionListViewModel()
        {
            FetchInspections();   
        }

        private ObservableCollection<Inspection> _inspections = new ObservableCollection<Inspection>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Inspection> Inspections
        {
            get { return _inspections; }
            set
            {

                _inspections = value;
            }
        }


        public async void FetchInspections()
        {
            string content = await new RestClient().HttpClient.GetStringAsync("http://172.20.10.3:8080/inspection");
            List<Inspection> inspections = JsonConvert.DeserializeObject<List<Inspection>>(content);
            inspections.ForEach(Inspections.Add);
        }
    }


}
