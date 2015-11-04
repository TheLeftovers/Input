package project.pkg56;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Embeddable;

/**
 *
 * @author Steven v/d Stel
 */
@Embeddable
public class EventsPK implements Serializable {
    @Basic(optional = false)
    @Column(name = "date_time")
    private String dateTime;
    @Basic(optional = false)
    @Column(name = "unit_id")
    private int unitId;

    public EventsPK() {
    }

    public EventsPK(String dateTime, int unitId) {
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
        if (!(object instanceof EventsPK)) {
            return false;
        }
        EventsPK other = (EventsPK) object;
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
        return "project.pkg56.EventsPK[ dateTime=" + dateTime + ", unitId=" + unitId + " ]";
    }

}
