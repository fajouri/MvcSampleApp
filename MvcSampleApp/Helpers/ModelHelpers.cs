using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MvcSampleApp.Helpers
{
    public class ModelHelpers
    {
        public static TModel ToModel<TModel,TViewModel>(TViewModel viewModel) where TModel : new()
        {
            var viewModelProperties = (typeof(TViewModel)).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var modelProperties = (typeof(TModel)).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var model = new TModel();

            foreach(var propertyInfo in viewModelProperties)
            {
                var value = propertyInfo.GetValue(viewModel, null);

                if(modelProperties.Any(p => p.Name.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    var modelProperty = modelProperties.First(p => p.Name.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase));
                    modelProperty.SetValue(model, value);
                }
            }
            return model;
        }
    }
}