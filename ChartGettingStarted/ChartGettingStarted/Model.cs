using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartGettingStarted
{
    public class Model
    {
        public string Type { get; set; }

        public double? Value { get; set; }

        public ObservableCollection<Model> Collections
        {
            get;
            set;
        }

        public ObservableCollection<Model> Collections2
        {
            get;
            set;
        }

        public Model(string type, double? value)
        {
            Type = type;
            Value = value;
        }

        public Model(string type, double? value, ObservableCollection<Model> collections)
        {
            Type = type;
            Value = value;
            Collections = collections;
        }

        public Model(string type, double? value, ObservableCollection<Model> collections1, ObservableCollection<Model> collections2)
        {
            Type = type;
            Value = value;
            Collections = collections1;
            Collections2 = collections2;
        }

    }

    public class LocationGraphDataList
    {
        private double? _totalSalesAmount;
        public double? totalSalesAmount {
            get
            {
                return _totalSalesAmount;
            }
            set
            {
                if (value == null)
                    _totalSalesAmount = 0;
                else
                    _totalSalesAmount = value;
                
            }
        }

        private double? _totalSalesVolumeUnits;
        public double? totalSalesVolumeUnits {
            get
            {
                return _totalSalesVolumeUnits;
            }
            set
            {
                if (value == null)
                    _totalSalesVolumeUnits = 0;
                else
                    _totalSalesVolumeUnits = value;

            }
        }

        private string _periodKey;
        public string periodKey
        {
            get
            {
                return _periodKey;
            }
            set
            {
                _periodKey = value;
                _periodKey = _periodKey.Insert(6, @"/");
                _periodKey = _periodKey.Insert(4, @"/");
            }
        }
    }

    public class SimilarLocationGraphDataList
    {
        private double? _totalSalesAmount;
        public double? totalSalesAmount
        {
            get
            {
                return _totalSalesAmount;
            }
            set
            {
                if (value == null)
                    _totalSalesAmount = 0;
                else
                    _totalSalesAmount = value;

            }
        }

        private double? _totalSalesVolumeUnits;
        public double? totalSalesVolumeUnits
        {
            get
            {
                return _totalSalesVolumeUnits;
            }
            set
            {
                if (value == null)
                    _totalSalesVolumeUnits = 0;
                else
                    _totalSalesVolumeUnits = value;

            }
        }

        private string _periodKey;
        public string periodKey
        {
            get
            {
                return _periodKey;
            }
            set
            {
                _periodKey = value;
                _periodKey = _periodKey.Insert(6, @"/");
                _periodKey = _periodKey.Insert(4, @"/");
            }
        }
    }

    public class RootObject
    {
        public List<LocationGraphDataList> locationGraphDataList { get; set; }
        public List<SimilarLocationGraphDataList> similarLocationGraphDataList { get; set; }
    }
}
