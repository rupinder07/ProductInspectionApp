using Plugin.Media;
using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductInspection.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductView : ContentPage
	{
        ProductViewModel vm = new ProductViewModel();

        public ProductView(int inspectionId, int productId)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.FetchProductById(inspectionId, productId);
        }

        private void ProductSatisfactionSwitchToggled(object sender, ToggledEventArgs e)
        {
        //DisplayAlert("Toggled", vm.ProductStateBinding.StateSatisfactory.ToString(), "OK");
        }

        private void Reset(object sender, EventArgs e)
        {
         //   vm.ProductStateBinding = new Model.ProductState();
        }

        private void Submit(object sender, EventArgs e)
        {
            vm.OnSubmit();
            Navigation.PopAsync();
        }

        private async void UploadImage(object sender, EventArgs e)
        {


            var status = await Plugin.Permissions.CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Pick photo not supported", "Can not pick photo", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
            {
                await DisplayAlert("No Image Taken", "Can not take photo", "OK");
                return;
            }
            //vm.Product.Image = file.GetStream();
            file.Dispose();
        }

        private async void TakeImage(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No CameraAvailable", "Can not take photo", "OK");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(
                    new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        SaveToAlbum = true
                    }
                );
            if(file == null)
            {
                await DisplayAlert("No Image Taken", "Can not take photo", "OK");
                return;
            }
            //vm.Product.Image = file.GetStream();
            file.Dispose();
        }
    }
}