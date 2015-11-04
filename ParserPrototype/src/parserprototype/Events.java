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
@Table(name = "events")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Events.findAll", query = "SELECT e FROM Events e"),
    @NamedQuery(name = "Events.findByUnitId", query = "SELECT e FROM Events e WHERE e.eventsPK.unitId = :unitId"),
    @NamedQuery(name = "Events.findByPort", query = "SELECT e FROM Events e WHERE e.port = :port"),
    @NamedQuery(name = "Events.findByValue", query = "SELECT e FROM Events e WHERE e.value = :value"),
    @NamedQuery(name = "Events.findByDate", query = "SELECT e FROM Events e WHERE e.eventsPK.date = :date"),
    @NamedQuery(name = "Events.findByTime", query = "SELECT e FROM Events e WHERE e.eventsPK.time = :time")})
public class Events implements Serializable {
    private static final long serialVersionUID = 1L;
    @EmbeddedId
    protected EventsPK eventsPK;
    @Basic(optional = false)
    @Column(name = "port")
    private String port;
    @Basic(optional = false)
    @Column(name = "value")
    private boolean value;

    public Events() {
    }

    public Events(EventsPK eventsPK) {
        this.eventsPK = eventsPK;
    }

    public Events(EventsPK eventsPK, String port, boolean value) {
        this.eventsPK = eventsPK;
        this.port = port;
        this.value = value;
    }

    public Events(long unitId, Date date, Date time) {
        this.eventsPK = new EventsPK(unitId, date, time);
    }

    public EventsPK getEventsPK() {
        return eventsPK;
    }

    public void setEventsPK(EventsPK eventsPK) {
        this.eventsPK = eventsPK;
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

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (eventsPK != null ? eventsPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Events)) {
            return false;
        }
        Events other = (Events) object;
        if ((this.eventsPK == null && other.eventsPK != null) || (this.eventsPK != null && !this.eventsPK.equals(other.eventsPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "parserprototype.Events[ eventsPK=" + eventsPK + " ]";
    }
    
}
