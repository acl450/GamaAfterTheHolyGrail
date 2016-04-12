using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GamaAfterTheHolyGrail.CooperacionModule.Views
{
    public class BuscadorDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var result = new DataTemplate();

            var searhBoxView = new SearchBoxView();

            if (searhBoxView == null)
                throw new Exception("Error Interno: No se ha encontrado SearchBoxView");

            if (item is string)
            {
                result = searhBoxView.Resources["EsperarResultadoDataTemplate"] as DataTemplate;
            }
            else
            {
                result = searhBoxView.Resources["ResultadoDataTemplate"] as DataTemplate;
            }

            return result;
        }

        static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            var parent = parentObject as T;

            if (parent != null)
                return parent;

            return FindParent<T>(parentObject);
        }

    }
}
