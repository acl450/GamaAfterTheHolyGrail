using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GamaAfterTheHolyGrail.Cooperacion.ChartsModule
{
    public class MainWindowViewModel
    {
        public ObservableCollection<TestClass> Errors { get; private set; }

        public MainWindowViewModel()
        {
            Errors = new ObservableCollection<TestClass>();
            Errors.Add(new TestClass() { Category = "Homosexual", Number = 45 });
            Errors.Add(new TestClass() { Category = "Lesbiana", Number = 84 });
            Errors.Add(new TestClass() { Category = "Bisexual", Number = 242 });
            Errors.Add(new TestClass() { Category = "Gay", Number = 345});

            OtherChartInitialize();

            contextMenu = new ContextMenu();
            contextMenu.Items.Add("Acción 1");
            contextMenu.Items.Add("Acción 1");
        }

        public ContextMenu contextMenu { get; set; }

        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                // selected item has changed
                selectedItem = value;
            }
        }

        private void OtherChartInitialize()
        {
            this.TheChart = new PieChart();

            //create a new SeriesCollection
            var seriesCollection = new SeriesCollection();

            //create some LineSeries if ypu need so

            var bisexualSerie = new MyPieSeries("Bisexual", 45);
            var heterosexualSerie = new MyPieSeries("Heterosexual", 84);
            var lesbianaSerie = new MyPieSeries("Lesbiana", 242);
            var gaySerie = new MyPieSeries("Gay", 345);
            var gaySerie2 = new MyPieSeries("Gay2", 345);
            var gaySerie3 = new MyPieSeries("Gay3", 345);


            //add series to seriesCollection
            seriesCollection.Add(bisexualSerie);
            seriesCollection.Add(heterosexualSerie);
            seriesCollection.Add(lesbianaSerie);
            seriesCollection.Add(gaySerie);
            seriesCollection.Add(gaySerie2);
            seriesCollection.Add(gaySerie3);

            //now just assing this seriesCollectionto your chart
            //you can use wpf bindings if you need it
            this.TheChart.Series = seriesCollection;

            //create some labels if necessary
            var labels = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dec" };
            //this.TheChart.AxixX.Labels = labels;
        }

        public PieChart TheChart { get; set; }

    }

    // class which represent a data point in the chart
    public class TestClass
    {
        public string Category { get; set; }
        public int Number { get; set; }
    }
}
