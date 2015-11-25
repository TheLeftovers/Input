using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace w
{
    public class Positions
    {
        public virtual string Time { get; set; }
        public virtual long UnitId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string RdY { get; set; }
        public virtual int Speed { get; set; }
        public virtual string Quality { get; set; }
        public virtual string RdX { get; set; }
        public virtual int Hdop { get; set; }
        public virtual int Course { get; set; }
        public virtual int NumSatellites { get; set; }

        public Positions()
        {}

        public Positions(string Time, long UnitId, DateTime Date, string RdX, string RdY, int Speed, string Quality, int Hdop, int Course, int NumSatellites)
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
    }
}