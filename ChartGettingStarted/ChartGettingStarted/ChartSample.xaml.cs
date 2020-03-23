using Syncfusion.SfChart.XForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ChartGettingStarted
{
    public partial class ChartSample : ContentPage
    {
        ViewModel view ;

        public ChartSample()
        {
            InitializeComponent();
            view = new ViewModel();
            chart.BindingContext = view;

        }

        private void Chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
        {
           
            IList items = e.SelectedSeries.ItemsSource as IList;
            Model selectedDatapoint = items[e.SelectedDataPointIndex] as Model;
            Navigation.PushAsync(new SecondayPage(selectedDatapoint));
            series.SelectedDataPointIndex = -1;
        }
    }
}
