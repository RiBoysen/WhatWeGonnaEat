using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WhatWeGonnaEat.DataAcces.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// All models have a Unique Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This wil Notify when the properties are changed, used for updating the user interfac(GUI)
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
