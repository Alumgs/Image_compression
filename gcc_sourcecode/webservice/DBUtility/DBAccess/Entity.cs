using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    [Serializable]
    public class MobileUserInfo
    {
        public MobileUserInfo(int _userid, int _usertype, string _realname)
        {
            userid = _userid; usertype = _usertype; realname = _realname;
        }
        public int userid { get; set; }
        public int usertype { get; set; }
        public string realname { get; set; }
    }
    [Serializable]
    public class Mini_ChartData
    {
        public List<string> xlabel;
        public List<double> serial1;
        public List<double> serial2;
        public List<PieData> ieserial;
        public List<PieData> pieserial;
        public int pieTotal;
        public string unit;
        public string serialname;
        public string unitname;
        public string serial1name;
        public int max;
        public Mini_ChartData()
        {
            xlabel = new List<string>();
            serial1 = new List<double>();
            serial2 = new List<double>();
            ieserial = new List<PieData>();
            
            pieserial = new List<PieData>();

        pieTotal = 0;
            unit = ""; unitname = "";
            max = 0;
        }
        public class PieData
        {
            public PieData(string _name, int _data)
            {
                name = _name;
                data = _data;
            }
            public string name { get; set; }
            public int data { get; set; }
            public string unit { get; set; }
            public string unitname { get; set; }
            public List<string> xlabel { get; set; }
            public string serial1name { get; set; }
            public string serial2name { get; set; }
            public List<double> serial1 { get; set; }
            public List<double> serial2 { get; set; }
            public List<PieData> pieserial { get; set; }
            public int pieTotal { get; set; }
            public int max { get; set; }
        }
    }
    [Serializable]
    public class PersonInfo
    {
        public PersonInfo(int _userid, int _usertype, string _realname)
        {
            userid = _userid; usertype = _usertype; realname = _realname;
        }
        public int userid { get; set; }
        public int usertype { get; set; }
        public string realname { get; set; }
    }
}

