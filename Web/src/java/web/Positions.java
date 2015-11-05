/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;

/**
 *
 * @author Johan Bos
 */
public class Positions {
    private long unitId;
    private double rdX;
    private double rdY;
    private int speed;
    private int course;
    private int numSatellites;
    private int hdop;
    private String quality;
    private Date date;
    private Date time;

    public Positions() {
    }

    public Positions(long unitId, double rdX, double rdY, int speed, int course, int numSatellites, int hdop, String quality, Date date, Date time) {
        this.unitId = unitId;
        this.rdX = rdX;
        this.rdY = rdY;
        this.speed = speed;
        this.course = course;
        this.numSatellites = numSatellites;
        this.hdop = hdop;
        this.quality = quality;
        this.date = date;
        this.time = time;
    }

    public long getUnitId() {
        return unitId;
    }

    public void setUnitId(long unitId) {
        this.unitId = unitId;
    }

    public double getRdX() {
        return rdX;
    }

    public void setRdX(double rdX) {
        this.rdX = rdX;
    }

    public double getRdY() {
        return rdY;
    }

    public void setRdY(double rdY) {
        this.rdY = rdY;
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

    public int getHdop() {
        return hdop;
    }

    public void setHdop(int hdop) {
        this.hdop = hdop;
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

    public Date getTime() {
        return time;
    }

    public void setTime(Date time) {
        this.time = time;
    }

    @Override
    public String toString() {
        return "Positions{" + "unitId=" + unitId + ", rdX=" + rdX + ", rdY=" + rdY + ", speed=" + speed + ", course=" + course + ", numSatellites=" + numSatellites + ", hdop=" + hdop + ", quality=" + quality + ", date=" + date + ", time=" + time + '}';
    }
    
    

    
}
