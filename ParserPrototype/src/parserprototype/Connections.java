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
@Table(name = "connections")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Connections.findAll", query = "SELECT c FROM Connections c"),
    @NamedQuery(name = "Connections.findByUnitId", query = "SELECT c FROM Connections c WHERE c.connectionsPK.unitId = :unitId"),
    @NamedQuery(name = "Connections.findByPort", query = "SELECT c FROM Connections c WHERE c.port = :port"),
    @NamedQuery(name = "Connections.findByValue", query = "SELECT c FROM Connections c WHERE c.value = :value"),
    @NamedQuery(name = "Connections.findByDate", query = "SELECT c FROM Connections c WHERE c.connectionsPK.date = :date"),
    @NamedQuery(name = "Connections.findByTime", query = "SELECT c FROM Connections c WHERE c.connectionsPK.time = :time")})
public class Connections implements Serializable {
    private static final long serialVersionUID = 1L;
    @EmbeddedId
    protected ConnectionsPK connectionsPK;
    @Basic(optional = false)
    @Column(name = "port")
    private String port;
    @Basic(optional = false)
    @Column(name = "value")
    private boolean value;

    public Connections() {
    }

    public Connections(ConnectionsPK connectionsPK) {
        this.connectionsPK = connectionsPK;
    }

    public Connections(ConnectionsPK connectionsPK, String port, boolean value) {
        this.connectionsPK = connectionsPK;
        this.port = port;
        this.value = value;
    }

    public Connections(long unitId, Date date, Date time) {
        this.connectionsPK = new ConnectionsPK(unitId, date, time);
    }

    public ConnectionsPK getConnectionsPK() {
        return connectionsPK;
    }

    public void setConnectionsPK(ConnectionsPK connectionsPK) {
        this.connectionsPK = connectionsPK;
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
        hash += (connectionsPK != null ? connectionsPK.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Connections)) {
            return false;
        }
        Connections other = (Connections) object;
        if ((this.connectionsPK == null && other.connectionsPK != null) || (this.connectionsPK != null && !this.connectionsPK.equals(other.connectionsPK))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "parserprototype.Connections[ connectionsPK=" + connectionsPK + " ]";
    }
    
}
