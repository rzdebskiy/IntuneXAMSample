//-----------------------------------------------------------------------------------
// <copyright company="Microsoft" file="PropertyNotifyBase.cs">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------

using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace IntuneMAMFormsSample
{
    public class PropertyNotifyBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (this.properties.ContainsKey(propertyName) &&
                object.Equals(this.properties[propertyName], value))
            {
                return false;
            }

            this.properties[propertyName] = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected T GetProperty<T>([CallerMemberName] string propertyName = null, T defaultValue = default(T))
        {
            if (this.properties.ContainsKey(propertyName))
            {
                return (T)this.properties[propertyName];
            }

            return defaultValue;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                this.ExecuteEventHandler(propertyName, eventHandler);
            }
        }

        private void ExecuteEventHandler(string propertyName, PropertyChangedEventHandler eventHandler)
        {
            eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
