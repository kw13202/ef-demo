using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTransactionDemo.Model
{
    /// <summary>
    /// 预定
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// 预订Id
        /// </summary>
        public int BookingId { get; set; }
        /// <summary>
        /// 预订人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 预订日期
        /// </summary>
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
