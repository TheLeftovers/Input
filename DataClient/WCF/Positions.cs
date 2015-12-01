using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF
{
    public class Positions
    {
        public virtual long UnitId { get; set; }
        public virtual int RdX { get; set; }
        public virtual int RdY { get; set; }
        public virtual int Speed { get; set; }
        public virtual int Course { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Time { get; set; }
        public virtual int NumSatellites { get; set; }
        public virtual string Quality { get; set; }
        public virtual int Hdop { get; set; }

        public Positions()
        {}

        public Positions(string Time, long UnitId, DateTime Date, int RdX, int RdY, int Speed, string Quality, int Hdop, int Course, int NumSatellites)
        {
            this.Course = Course;
            this.Date = Date;
            this.Hdop = Hdop;
            this.NumSatellites = NumSatellites;
            this.Quality = Quality;
            this.RdX = RdX;
            this.RdY = RdY;
            this.Speed = Speed;
            this.Time = Time;
            this.UnitId = UnitId;
        }

        public override string ToString()
        {
            return String.Format("Position: {0}, Unit ID:{1}, Speed:{2}, Date:{3}, Time{4}, Course{5}, Quality{6}, RdX{7}, RdY{8}, HDOP{9}, NumSatellites{10}", UnitId, Speed, Date, Time, Course, Quality, RdX, RdY, Hdop, NumSatellites);
        }
    }
}