using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamenJuni
{
    public abstract class Performer
    {
        private string _name;
        private int _reservationNumber;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private int[][] _technicalSupplies;
        private List<string> _rider;

        public string Name { get => _name; set => _name = value; }
        public int ReservationNumber { get => _reservationNumber; set => _reservationNumber = value; }
        public TimeSpan StartTime { get => _startTime; set => _startTime = value; }
        public TimeSpan EndTime { get => _endTime; set => _endTime = value; }
        public int[][] TechnicalSupplies { get => _technicalSupplies; set => _technicalSupplies = value; }
        public List<string> Rider { get => _rider; set => _rider = value; }
        public override string ToString()
        {
            
            return $"{ StartTime:hh:mm}-{EndTime:hh:mm} {Name}";
        }
    }
}
