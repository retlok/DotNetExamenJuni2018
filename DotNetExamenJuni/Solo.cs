using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamenJuni
{
    public class Solo: Performer
    {
        private string _type;

        public string Type { get => _type; set => _type = value; }

        public Solo(string type, string name, int reservationNumber, string startTime, string endTime, int[] technicalSupplies, List<string> rider) 
        {
            Name = name;
            ReservationNumber = reservationNumber;
            StartTime = TimeSpan.Parse(startTime);
            EndTime = TimeSpan.Parse(endTime);
            TechnicalSupplies = technicalSupplies;
            Rider = rider;
            _type = type;
        }
    }
}
