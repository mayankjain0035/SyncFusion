using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChartGettingStarted
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondayPage : ContentPage
    {
        private Model selectedDatapoint;
        //ViewModel view = new ViewModel();
        private ChartZoomPanBehavior zoomPanBehavior;
        public SecondayPage(Model selectedDatapoint)
        {
            InitializeComponent();

            zoomPanBehavior = new ChartZoomPanBehavior();
            chart.ChartBehaviors.Add(zoomPanBehavior);
            zoomPanBehavior.ZoomMode = ZoomMode.X;
            zoomPanBehavior.Zoom(0.2f);

            zoomIn.Clicked += ZoomIn_Clicked;
            zoomOut.Clicked += ZoomOut_Clicked;
            zoomReset.Clicked += ZoomReset_Clicked;

            chart.Title.Text = "Sales in the " + selectedDatapoint.Type + " segment";
            if (selectedDatapoint.Collections2 != null)
            {
                chart.Title.Text = "Title Goes Here";
            }
                //this.BindingContext = view;
                this.selectedDatapoint = selectedDatapoint;
            

            
            chart.Legend = new ChartLegend();
            
            ColumnSeries series = new ColumnSeries
            {
                XBindingPath = "Type",
                YBindingPath = "Value",
                ItemsSource = selectedDatapoint.Collections,
                DataMarker = new ChartDataMarker(),
                Label = "One Location"
            };
            
            ColumnSeries series1 = null;
            if (selectedDatapoint.Collections2 != null) {
                series1 = new ColumnSeries
                {
                    XBindingPath = "Type",
                    YBindingPath = "Value",
                    ItemsSource = selectedDatapoint.Collections2,
                    DataMarker = new ChartDataMarker(),
                    Label = "Similar Location"
                };
            }
            
            series.DataMarker.LabelContent = LabelContent.YValue;
            series1.DataMarker.LabelContent = LabelContent.YValue;

            chart.Series.Add(series);
            
            if (selectedDatapoint.Collections2 != null && series != null)
            {               
                chart.Series.Add(series1);
            }
            
            chart.PrimaryAxis = new DateTimeAxis() { Interval = 1, LabelRotationAngle = 180 };
            chart.PrimaryAxis.LabelRotationAngle = 90;

            

            
        }

        private void ZoomReset_Clicked(object sender, EventArgs e)
        {
            zoomPanBehavior.Reset();
        }

        private void ZoomOut_Clicked(object sender, EventArgs e)
        {
            zoomPanBehavior.ZoomOut();
        }

        private void ZoomIn_Clicked(object sender, EventArgs e)
        {
            //zoomPanBehavior.ZoomIn();
            var factor = primary.ZoomFactor;
            //zoomPanBehavior.ZoomToFactor(primary, e.CurrentZoomPosition, e.CurrentZoomFactor / 4);
            zoomPanBehavior.ZoomToFactor(primary, (float)primary.ZoomPosition, (float)factor);
        }
    }
}