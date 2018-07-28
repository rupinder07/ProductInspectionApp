using ProductInspection.Model;
using ProductInspection.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProductInspection.ViewModel
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
            set { _inspections = value; }
        }

        public ICommand LogoutCommand {
            get
            {
                return new Command(() =>
                {
                    LoginService.Logout();
                }); 
            }
        }



        public async void FetchInspections()
        {
            try
            {
                string content = await RestClient.HttpClient.GetStringAsync("inspection");
                List<Inspection> inspections = JsonConvert.DeserializeObject<List<Inspection>>(content);
                inspections.ForEach(Inspections.Add);
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }
    }


}
