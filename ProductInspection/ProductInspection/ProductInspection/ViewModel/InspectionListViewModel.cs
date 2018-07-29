using ProductInspection.Model;
using ProductInspection.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using ProductInspection.repository;
using System.Globalization;

namespace ProductInspection.ViewModel
{
    public class InspectionListViewModel : INotifyPropertyChanged
    {
        private BaseRepository<Inspection> InspectionRepository = new BaseRepository<Inspection>(); 
        private LoginService Service = new LoginService();

        public InspectionListViewModel()
        {
            //Load all the insepctions to show on the page
            //Currently it will show all the inspections, this can be enhanced to show inspections only for logged in user
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
                    Service.Logout();
                }); 
            }
        }



        public async void FetchInspections()
        {
            if (await SyncService.IsBackendReachable())
            {
                try
                {
                    //fetch the inspections from Backend
                    string content = await RestClient.HttpClient.GetStringAsync("inspection");
                    List<Inspection> inspections = JsonConvert.DeserializeObject<List<Inspection>>(content);
                    inspections.ForEach(Inspections.Add);
                    //Update the inspections in local DB so as to support offline application
                    UpdateInspectionsInLocalStorage(inspections);
                }
                catch
                {
                    List<Inspection> inspections = await InspectionRepository.GetItemsAsync();
                    inspections.ForEach(Inspections.Add);
                }
            }
            else
            {
                List<Inspection> inspections = await InspectionRepository.GetItemsAsync();
                inspections.ForEach(Inspections.Add);
            }
        }

        private async void UpdateInspectionsInLocalStorage(List<Inspection> inspections)
        {
            List<Inspection> existingInspections = await InspectionRepository.GetItemsAsync();
            if(existingInspections.Count == 0)
            {
                InspectionRepository.SaveAllItemsAsync(inspections);
            }
            else
            {
                AddNewInspectionsIfAny(inspections, existingInspections);
            }
        }

        private void AddNewInspectionsIfAny(List<Inspection> inspections, List<Inspection> existingInspections)
        {
            DateTime LastSyncTime = DateTime.MinValue;
            existingInspections.ForEach(inspection =>
            {
                if(inspection.LastSyncTime.CompareTo(LastSyncTime) > 0)
                {
                    LastSyncTime = inspection.LastSyncTime;
                }
            });

            List<Inspection> inspectionsToAdd = inspections.FindAll(inspection =>
                inspection.LastSyncTime.CompareTo(LastSyncTime) > 0
            );

            InspectionRepository.SaveAllItemsAsync(inspectionsToAdd);
        }
    }
}
