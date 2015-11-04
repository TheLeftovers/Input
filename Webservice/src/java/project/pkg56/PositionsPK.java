/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project.pkg56;

import java.io.Serializable;

/**
 *
 * @author Johan Bos
 */
public class PositionsPK implements Serializable {

    private String dateTime;
    private int unitId;

    public PositionsPK() {
    }

    public PositionsPK(String dateTime, int unitId) {
        this.dateTime = dateTime;
        this.unitId = unitId;
    }

    public String getDateTime() {
        return dateTime;
    }

    public void setDateTime(String dateTime) {
        this.dateTime = dateTime;
    }

    public int getUnitId() {
        return unitId;
    }

    public void setUnitId(int unitId) {
        this.unitId = unitId;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (dateTime != null ? dateTime.hashCode() : 0);
        hash += (int) unitId;
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof PositionsPK)) {
            return false;
        }
        PositionsPK other = (PositionsPK) object;
        if ((this.dateTime == null && other.dateTime != null) || (this.dateTime != null && !this.dateTime.equals(other.dateTime))) {
            return false;
        }
        if (this.unitId != other.unitId) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "project.pkg56.PositionsPK[ dateTime=" + dateTime + ", unitId=" + unitId + " ]";
    }

}
