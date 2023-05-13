using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBAccess
{
    /// <summary>
    /// MiniResponse 的摘要说明
    /// </summary>
    [Serializable]
    public class MiniResponse
    {
        public MiniResponse()
        {
            status = 1; msg = "";
        }
        public int status { get; set; }   //1. 成功  0：失败
        public string msg { get; set; }
        public object data { get; set; }
    }
}