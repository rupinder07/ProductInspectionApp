using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspections.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedInspection : TabbedPage
    {
        public SelectedInspection ()
        {
            InitializeComponent();
        }
    }
}