using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaAfterTheHolyGrail.Cooperacion.ChartsModule
{
    public class MyPieSeries : PieSeries
    {
        public MyPieSeries(string title, double value)
        {
            this.Title = string.Format("{0}: {1}", title, value.ToString());
            this.Values = new ChartValues<double> { value };
        }
    }
}
