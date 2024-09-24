using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Classes.Bases
{
    public enum DataObjectStateEnum { None, Added, Confirmed, Modified, Deleted }

    public class BaseModel : IDisposable, INotifyPropertyChanged
    {
        public BaseModel()
        {
            DataObjectState = DataObjectStateEnum.Added;
        }

        [DisplayName("Código")]
        public long Id { get; set; }

        [DoNotNotify]
        [JsonIgnore]
        public DataObjectStateEnum DataObjectState { get; private set; }

        [DoNotNotify]
        [JsonIgnore]
        public string MensagemValidacao { get; set; }    

        public void SetAdded()
        {
            DataObjectState = DataObjectStateEnum.Added;
        }
        public void SetConfirmed()
        {
            DataObjectState = DataObjectStateEnum.Confirmed;
        }
        public void SetModified()
        {
            DataObjectState = DataObjectStateEnum.Modified;
        }
        public void SetDeleted()
        {
            DataObjectState = DataObjectStateEnum.Deleted;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName, object before, object after)
        {
            if (before != after && DataObjectState == DataObjectStateEnum.Confirmed)
                DataObjectState = DataObjectStateEnum.Modified;
        }

        public BaseModel ShallowCopy()
        {
            return (BaseModel)MemberwiseClone();
        }
        public void RestoreValues(BaseModel _baseModelOriginal)
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Count(); ++i)
            {
                if (properties[i].CanWrite)
                    properties[i].SetValue(this, properties[i].GetValue(_baseModelOriginal));
            }
        }

        ~BaseModel()
        { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
