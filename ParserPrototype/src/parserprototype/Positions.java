/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parserprototype;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Roy van den Heuvel
 */
@Entity
@Table(name = "positions")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Positions.findAll", query = "SELECT p FROM Positions p"),
    @NamedQuery(name = "Positions.findByUnitId", query = "SELECT p FROM Positions p WHERE p.positionsPK.unitId = :unitId"),
    @NamedQuery(name = "Positions.findByRdX", query = "SELECT p FROM Positions p WHERE p.rdX = :rdX"),
    @NamedQuery(name = "Positions.findByRdY", query = "SELECT p FROM Positions p WHERE p.rdY = :rdY"),
    @NamedQuery(name = "Positions.findBySpeed", query = "SELECT p FROM Positions p WHERE p.speed = :speed"),
    @NamedQuery(name = "Positions.findByCourse", query = "SELECT p FROM Positions p WHERE p.course = :course"),
    @NamedQuery(name = "Positions.findByNumSatellites", query = "SELECT p FROM Positions p WHERE p.numSatellites = :numSatellites"),
    @NamedQuery(name = "Positions.findByHdop", query = "SELECT p FROM Positions p WHERE p.hdop = :hdop"),
    @NamedQuery(name = "Positions.findByQuality", query = "SELECT p FROM Positions p WHERE p.quality = :quality"),
    @NamedQuery(name = "Positions.findByDate", query = "SELECT p FROM Positions p WHERE p.positionsPK.date = :date"),
    @NamedQuery(name = "Positions.findByTime", query = "SELECT p FROM Positions p WHERE p.positionsPK.time = :time")})
public class Positions implements Serializable {
    private static final long serialVersionUID = 1L;
    @EmbeddedId
    protected PositionsPK positionsPK;
    @Basic(optional = false)
    @Column(name = "rd_x")
    private double rdX;
    @Basic(optional = false)
    @Column(name = "rd_y")
    private double rdY;
    @Basic(optional = false)
    @Column(name = "speed")
    private int speed;
    @Basic(optional = false)
    @Column(name = "course")
    private int course;
    @Basic(optional = false)
    @Column(name = "num_satellites")
    private int numSatellites;
    @Basic(optional = false)
    @Column(name = "hdop")
    private int hdop;
    @Basic(optional = false)
    @Column(name = "quality")
    private String quality;

    public Positions() {
    }

    public Positions(PositionsPK positionsPK) {
        this.positionsPK = positionsPK;
    }

    public Positions(PositionsPK positionsPK, double rdX, double rdY, int speed, int course, int numSatellites, int hdop, String quality) {
        this.positionsPK = positionsPK;
        this.rdX = rdX;
        this.rdY = rdY;
        this.speed = speed;
        this.course = course;
        this.numSatellites = numSatellites;
        this.hdop = hdop;
        this.quality = quality;
    }

    public Positions(long unitId, Date date, Date time) {
        this.positionsPK = new PositionsPK(unitId, date, time);
    }

    public PositionsPK getPositionsPK() {
        return positionsPK;
    }

    public void setPositionsPK(PositionsPK positionsPK) {
        this.positionsPK = positionsPK;
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

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (positionsPK != null ? positionsPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Positions)) {
            return false;
        }
        Positions other = (Positions) object;
        if ((this.positionsPK == null && other.positionsPK != null) || (this.positionsPK != null && !this.positionsPK.equals(other.positionsPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "parserprototype.Positions[ positionsPK=" + positionsPK + " ]";
    }
    
}
