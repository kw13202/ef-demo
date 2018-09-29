using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    /// <summary>
    /// 银行账户
    /// </summary>
    public class BankAccount : BillingDetail
    {
        /// <summary>
        /// 账户名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 所属金融银行
        /// </summary>
        public string Swift { get; set; }
    }
}
