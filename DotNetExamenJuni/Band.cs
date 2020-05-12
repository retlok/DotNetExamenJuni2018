using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExamenJuni
{
    public class Band : Performer
    {
        private int _memberCount;

        public int MemberCount { get => _memberCount; set => _memberCount = value; }

        public Band(int memberCount, string name, int reservationNumber, string startTime, string endTime, int[] technicalSupplies, List<string> rider)
        {
            Name = name;
            ReservationNumber = reservationNumber;
            StartTime = TimeSpan.Parse(startTime);
            EndTime = TimeSpan.Parse(endTime);
            TechnicalSupplies = technicalSupplies;
            Rider = rider;
            _memberCount = memberCount;
        }
    }
}
