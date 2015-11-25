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
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Roy van den Heuvel
 */
@Entity
@Table(name = "connections")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Connections.findAll", query = "SELECT c FROM Connections c"),
    @NamedQuery(name = "Connections.findByUnitId", query = "SELECT c FROM Connections c WHERE c.unitId = :unitId"),
    @NamedQuery(name = "Connections.findByPort", query = "SELECT c FROM Connections c WHERE c.port = :port"),
    @NamedQuery(name = "Connections.findByValue", query = "SELECT c FROM Connections c WHERE c.value = :value"),
    @NamedQuery(name = "Connections.findByDate", query = "SELECT c FROM Connections c WHERE c.date = :date"),
    @NamedQuery(name = "Connections.findByTime", query = "SELECT c FROM Connections c WHERE c.time = :time"),
    @NamedQuery(name = "Connections.findByConnId", query = "SELECT c FROM Connections c WHERE c.connId = :connId")})
public class Connections implements Serializable {
    private static final long serialVersionUID = 1L;
    @Basic(optional = false)
    @Column(name = "unit_id")
    private long unitId;
    @Basic(optional = false)
    @Column(name = "port")
    private String port;
    @Basic(optional = false)
    @Column(name = "value")
    private boolean value;
    @Basic(optional = false)
    @Column(name = "date")
    @Temporal(TemporalType.DATE)
    private Date date;
    @Basic(optional = false)
    @Column(name = "time")
    @Temporal(TemporalType.TIME)
    private Date time;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "conn_id")
    private Integer connId;

    public Connections() {
    }

    public Connections(Integer connId) {
        this.connId = connId;
    }

    public Connections(Integer connId, long unitId, String port, boolean value, Date date, Date time) {
        this.connId = connId;
        this.unitId = unitId;
        this.port = port;
        this.value = value;
        this.date = date;
        this.time = time;
    }

    public long getUnitId() {
        return unitId;
    }

    public void setUnitId(long unitId) {
        this.unitId = unitId;
    }

    public String getPort() {
        return port;
    }

    public void setPort(String port) {
        this.port = port;
    }

    public boolean getValue() {
        return value;
    }

    public void setValue(boolean value) {
        this.value = value;
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

    public Integer getConnId() {
        return connId;
    }

    public void setConnId(Integer connId) {
        this.connId = connId;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (connId != null ? connId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Connections)) {
            return false;
        }
        Connections other = (Connections) object;
        if ((this.connId == null && other.connId != null) || (this.connId != null && !this.connId.equals(other.connId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "parserprototype.Connections[ connId=" + connId + " ]";
    }
    
}
