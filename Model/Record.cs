using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Record
    {
        public float Money { get; set; } = 0;

        public string Month { get; set; }
        public string Description { get; set; } = "Nothing";

        public long Id { get; set; }

        public Record(float money, string description, string month,long id)
        {
            Money = money;
            Description = description;
            Month = month;
            Id = id;


        }
        public Record(float money, string description,string month):this(money,description,month,0)
        { }





    }
}
