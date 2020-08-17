using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCDS.Models
{
    class SensorDataModel
    {
        public DateTime Date { get; set; }
        public ushort Value { get; set; }

        public SensorDataModel(DateTime date, ushort value)
        {
            Date = date;
            Value = value;
        }
    }
}
