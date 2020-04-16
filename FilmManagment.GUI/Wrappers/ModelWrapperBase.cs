using FilmManagment.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FilmManagment.GUI.Wrappers
{
    public abstract class ModelWrapperBase<T> : ViewModelBase
    {
        public T localModel { get; }

        protected ModelWrapperBase(T model)
        {
            if (model == null)
                throw new ArgumentException("Null reference: " + nameof(model));
            localModel = model;
        }

        public Guid Id
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        protected PropertyType GetValue<PropertyType>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = localModel.GetType().GetProperty(propertyName);
            return (PropertyType)propertyInfo.GetValue(localModel);
        }

        protected void SetValue<PropertyType>(PropertyType value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = localModel.GetType().GetProperty(propertyName);
            var propertyValue = propertyInfo.GetValue(localModel);
            if ( !Equals(propertyInfo,propertyValue))
            {
                propertyInfo.SetValue(localModel, value);
                OnPropertyChanged();
            }
        }

        // TODO: Add RegisterCollection method
    }
}
