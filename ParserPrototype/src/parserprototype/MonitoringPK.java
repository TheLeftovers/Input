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
import javax.persistence.Embeddable;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

/**
 *
 * @author Roy van den Heuvel
 */
@Embeddable
public class MonitoringPK implements Serializable {
    @Basic(optional = false)
    @Column(name = "unit_id")
    private long unitId;
    @Basic(optional = false)
    @Column(name = "type")
    private String type;
    @Basic(optional = false)
    @Column(name = "begin_time")
    @Temporal(TemporalType.TIME)
    private Date beginTime;
    @Basic(optional = false)
    @Column(name = "end_time")
    @Temporal(TemporalType.TIME)
    private Date endTime;

    public MonitoringPK() {
    }

    public MonitoringPK(long unitId, String type, Date beginTime, Date endTime) {
        this.unitId = unitId;
        this.type = type;
        this.beginTime = beginTime;
        this.endTime = endTime;
    }

    public long getUnitId() {
        return unitId;
    }

    public void setUnitId(long unitId) {
        this.unitId = unitId;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Date getBeginTime() {
        return beginTime;
    }

    public void setBeginTime(Date beginTime) {
        this.beginTime = beginTime;
    }

    public Date getEndTime() {
        return endTime;
    }

    public void setEndTime(Date endTime) {
        this.endTime = endTime;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (int) unitId;
        hash += (type != null ? type.hashCode() : 0);
        hash += (beginTime != null ? beginTime.hashCode() : 0);
        hash += (endTime != null ? endTime.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof MonitoringPK)) {
            return false;
        }
        MonitoringPK other = (MonitoringPK) object;
        if (this.unitId != other.unitId) {
            return false;
        }
        if ((this.type == null && other.type != null) || (this.type != null && !this.type.equals(other.type))) {
            return false;
        }
        if ((this.beginTime == null && other.beginTime != null) || (this.beginTime != null && !this.beginTime.equals(other.beginTime))) {
            return false;
        }
        if ((this.endTime == null && other.endTime != null) || (this.endTime != null && !this.endTime.equals(other.endTime))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "parserprototype.MonitoringPK[ unitId=" + unitId + ", type=" + type + ", beginTime=" + beginTime + ", endTime=" + endTime + " ]";
    }
    
}
