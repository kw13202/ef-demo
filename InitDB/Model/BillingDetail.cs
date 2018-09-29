using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    /// <summary>
    /// 账户明细
    /// </summary>
    public abstract class BillingDetail
    {
        /// <summary>
        /// 账户明细ID
        /// </summary>
        public int BillingDetailId { get; set; }
        /// <summary>
        /// 账户所属者
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Number { get; set; }
    }
}
