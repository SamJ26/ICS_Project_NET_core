using FilmManagment.BL;
using FilmManagment.BL.Models;
using FilmManagment.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FilmManagment.GUI.Wrappers
{
    public abstract class ModelWrapperBase<TModel> : ViewModelBase, IId where TModel : IId
    {
        public TModel usedModel { get; }

        protected ModelWrapperBase(TModel model)
        {
            if (model == null)
                throw new ArgumentException("Null reference: " + nameof(model));
            usedModel = model;
        }

        public Guid Id
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        protected PropertyType GetValue<PropertyType>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = usedModel.GetType().GetProperty(propertyName);
            return (PropertyType)propertyInfo.GetValue(usedModel);
        }

        protected void SetValue<PropertyType>(PropertyType value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = usedModel.GetType().GetProperty(propertyName);
            var propertyValue = propertyInfo.GetValue(usedModel);
            if ( !Equals(propertyInfo,propertyValue))
            {
                propertyInfo.SetValue(usedModel, value);
                OnPropertyChanged();
            }
        }

        protected void RegisterCollection<TWrappedCollection, T_BLmodel>(ObservableCollection<TWrappedCollection> wrappedCollection,
                                                                         ICollection<T_BLmodel> modelCollection) 
                                                                         where TWrappedCollection : ModelWrapperBase<T_BLmodel>, IId where T_BLmodel : IId
        {
            wrappedCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                foreach (var model in wrappedCollection.Select(i => i.usedModel))
                {
                    modelCollection.Add(model);
                }
            };
        }
    }
}
