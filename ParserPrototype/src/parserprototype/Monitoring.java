/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parserprototype;

import java.io.Serializable;
import java.math.BigInteger;
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
@Table(name = "monitoring")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Monitoring.findAll", query = "SELECT m FROM Monitoring m"),
    @NamedQuery(name = "Monitoring.findByUnitId", query = "SELECT m FROM Monitoring m WHERE m.monitoringPK.unitId = :unitId"),
    @NamedQuery(name = "Monitoring.findByType", query = "SELECT m FROM Monitoring m WHERE m.monitoringPK.type = :type"),
    @NamedQuery(name = "Monitoring.findByMin", query = "SELECT m FROM Monitoring m WHERE m.min = :min"),
    @NamedQuery(name = "Monitoring.findByMax", query = "SELECT m FROM Monitoring m WHERE m.max = :max"),
    @NamedQuery(name = "Monitoring.findByBeginTime", query = "SELECT m FROM Monitoring m WHERE m.monitoringPK.beginTime = :beginTime"),
    @NamedQuery(name = "Monitoring.findByEndTime", query = "SELECT m FROM Monitoring m WHERE m.monitoringPK.endTime = :endTime"),
    @NamedQuery(name = "Monitoring.findBySum", query = "SELECT m FROM Monitoring m WHERE m.sum = :sum")})
public class Monitoring implements Serializable {
    private static final long serialVersionUID = 1L;
    @EmbeddedId
    protected MonitoringPK monitoringPK;
    @Basic(optional = false)
    @Column(name = "min")
    private long min;
    @Basic(optional = false)
    @Column(name = "max")
    private long max;
    @Column(name = "sum")
    private long sum;

    public Monitoring() {
    }

    public Monitoring(MonitoringPK monitoringPK) {
        this.monitoringPK = monitoringPK;
    }

    public Monitoring(MonitoringPK monitoringPK, long min, long max) {
        this.monitoringPK = monitoringPK;
        this.min = min;
        this.max = max;
    }

    public Monitoring(long unitId, String type, Date beginTime, Date endTime) {
        this.monitoringPK = new MonitoringPK(unitId, type, beginTime, endTime);
    }

    public MonitoringPK getMonitoringPK() {
        return monitoringPK;
    }

    public void setMonitoringPK(MonitoringPK monitoringPK) {
        this.monitoringPK = monitoringPK;
    }

    public long getMin() {
        return min;
    }

    public void setMin(long min) {
        this.min = min;
    }

    public long getMax() {
        return max;
    }

    public void setMax(long max) {
        this.max = max;
    }

    public long getSum() {
        return sum;
    }

    public void setSum(long sum) {
        this.sum = sum;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (monitoringPK != null ? monitoringPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Monitoring)) {
            return false;
        }
        Monitoring other = (Monitoring) object;
        if ((this.monitoringPK == null && other.monitoringPK != null) || (this.monitoringPK != null && !this.monitoringPK.equals(other.monitoringPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "parserprototype.Monitoring[ monitoringPK=" + monitoringPK + " ]";
    }
    
}
