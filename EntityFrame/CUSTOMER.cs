//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrame
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER
    {
        public string CUST_CODE { get; set; }
        public string CUST_NAME { get; set; }
        public string CUST_CITY { get; set; }
        public string WORKING_AREA { get; set; }
        public string CUST_COUNTRY { get; set; }
        public Nullable<int> GRADE { get; set; }
        public int OPENING_AMT { get; set; }
        public int RECEIVE_AMT { get; set; }
        public int PAYMENT_AMT { get; set; }
        public int OUTSTANDING_AMT { get; set; }
        public string PHONE_NO { get; set; }
        public string AGENT_CODE { get; set; }
    
        public virtual AGENT AGENT { get; set; }
    }
}
