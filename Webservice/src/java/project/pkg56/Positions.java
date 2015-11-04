/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project.pkg56;

/**
 *
 * @author Johan Bos
 */
public class Positions {
    private int rdX;
    private int rdY;
    private int Speed;
    private int Course;
    private int numSatellites;
    private int HDOP;
    private String Quality;
    protected PositionsPK positionsPK;

    public Positions(PositionsPK positionsPK, int rdX, int rdY, int Speed, int Course, int numSatellites, int HDOP, String Quality) {
        this.positionsPK = positionsPK;
        this.rdX = rdX;
        this.rdY = rdY;
        this.Speed = Speed;
        this.Course = Course;
        this.numSatellites = numSatellites;
        this.HDOP = HDOP;
        this.Quality = Quality;
    }

    Positions(){}
    
    public Positions(PositionsPK positionsPK) {
        this.positionsPK = positionsPK;
    }

    public int getRdX() {
        return rdX;
    }

    public void setRdX(int rdX) {
        this.rdX = rdX;
    }

    public int getRdY() {
        return rdY;
    }

    public void setRdY(int rdY) {
        this.rdY = rdY;
    }

    public int getSpeed() {
        return Speed;
    }

    public void setSpeed(int Speed) {
        this.Speed = Speed;
    }

    public int getCourse() {
        return Course;
    }

    public void setCourse(int Course) {
        this.Course = Course;
    }

    public int getNumSatellites() {
        return numSatellites;
    }

    public void setNumSatellites(int numSatellites) {
        this.numSatellites = numSatellites;
    }

    public int getHDOP() {
        return HDOP;
    }

    public void setHDOP(int HDOP) {
        this.HDOP = HDOP;
    }

    public String getQuality() {
        return Quality;
    }

    public void setQuality(String Quality) {
        this.Quality = Quality;
    }
    
    
    
}
