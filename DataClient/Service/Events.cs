using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class Events
    {
        public virtual long UnitId { get; set; }
        public virtual string Port { get; set; }
        public virtual Boolean Value { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime Time { get; set; }

        public Events() { }

        public Events(long UnitId, string Port, Boolean Value, DateTime Date, DateTime Time)
        {
            this.UnitId = UnitId;
            this.Port = Port;
            this.Value = Value;
            this.Date = Date;
            this.Time = Time;
        }

        public override string ToString()
        {
            return String.Format("Event: {0}, Unit ID:{1}, Port:{2}, Value:{3}, Date{4}, Time{5}", UnitId, Port, Value, Date, Time);
        }
    }
}