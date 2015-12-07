/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import java.sql.Date;
import java.sql.Time;

/**
 *
 * @author Roy van den Heuvel
 */
public class Position {
    long unitId;
    double rdx;
    double rdy;
    int speed;
    int course;
    int numSatellites;
    String quality;
    Date date;
    Time time;
    int HDOP;

    public Position(long unitId, double rdx, double rdy, int speed, int course, int numSatellites, String quality, Date date, Time time, int HDOP) {
        this.unitId = unitId;
        this.rdx = rdx;
        this.rdy = rdy;
        this.speed = speed;
        this.course = course;
        this.numSatellites = numSatellites;
        this.quality = quality;
        this.date = date;
        this.time = time;
        this.HDOP = HDOP;
    }

    public Position() {
    }

    
    
    public int getHDOP() {
        return HDOP;
    }

    public void setHDOP(int HDOP) {
        this.HDOP = HDOP;
    }

    public long getUnitId() {
        return unitId;
    }

    public void setUnitId(long unitId) {
        this.unitId = unitId;
    }

    public double getRdx() {
        return rdx;
    }

    public void setRdx(double rdx) {
        this.rdx = rdx;
    }

    public double getRdy() {
        return rdy;
    }

    public void setRdy(double rdy) {
        this.rdy = rdy;
    }

    public int getSpeed() {
        return speed;
    }

    public void setSpeed(int speed) {
        this.speed = speed;
    }

    public int getCourse() {
        return course;
    }

    public void setCourse(int course) {
        this.course = course;
    }

    public int getNumSatellites() {
        return numSatellites;
    }

    public void setNumSatellites(int numSatellites) {
        this.numSatellites = numSatellites;
    }

    public String getQuality() {
        return quality;
    }

    public void setQuality(String quality) {
        this.quality = quality;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public Time getTime() {
        return time;
    }

    public void setTime(Time time) {
        this.time = time;
    }
    
    
}
