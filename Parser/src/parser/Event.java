package parser;

import java.sql.Date;
import java.sql.Time;

/**
 *
 * @author Roy van den Heuvel
 */
public class Event {
    long unitId;
    String port;
    boolean value;
    Date date;
    Time time;  

    public Event(long unitId, String port, boolean value, Date date, Time time) {
        this.unitId = unitId;
        this.port = port;
        this.value = value;
        this.date = date;
        this.time = time;
    }

    public Event() {
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

    public boolean isValue() {
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

    public Time getTime() {
        return time;
    }

    public void setTime(Time time) {
        this.time = time;
    }
    
    
}
