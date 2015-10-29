/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parserprototype;

import java.util.Date;

/**
 *
 * @author Roy van den Heuvel
 */
public class Position {

    private Date date;
    private String time;
    private long unitId;
    private float rdx;
    private float rdy;
    private int speed;
    private int course;
    private int numSatallites;
    private int HDOP;
    private String quality;

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public long getUnitId() {
        return unitId;
    }

    public void setUnitId(long unitId) {
        this.unitId = unitId;
    }

    public float getRdx() {
        return rdx;
    }

    public void setRdx(float rdx) {
        this.rdx = rdx;
    }

    public float getRdy() {
        return rdy;
    }

    public void setRdy(float rdy) {
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

    public int getNumSatallites() {
        return numSatallites;
    }

    public void setNumSatallites(int numSatallites) {
        this.numSatallites = numSatallites;
    }

    public int getHDOP() {
        return HDOP;
    }

    public void setHDOP(int HDOP) {
        this.HDOP = HDOP;
    }

    public String getQuality() {
        return quality;
    }

    public void setQuality(String quality) {
        this.quality = quality;
    }

    public Position() {
    }

}
