using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTransactionDemo.Model
{
    /// <summary>
    /// 航班
    /// </summary>
    public class FlighBooking
    {
        /// <summary>
        /// 航班Id
        /// </summary>
        public int FlightId { get; set; }
        /// <summary>
        /// 航班名称
        /// </summary>
        public string FlightName { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 出行日期
        /// </summary>
        public DateTime TravellingDate { get; set; }
    }
}
