/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import java.sql.Date;
import java.sql.Time;

/**
 *
 * @author Roy van den Heuvel
 */
public class Connections {
    Time time;
    Date date;
    boolean value;
    long unitId;
    String port;

    public Connections(Time time, Date date, boolean value, long unitId, String port) {
        this.time = time;
        this.date = date;
        this.value = value;
        this.unitId = unitId;
        this.port = port;
    }

    public Connections() {
    }

    public Time getTime() {
        return time;
    }

    public void setTime(Time time) {
        this.time = time;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    public boolean getValue() {
        return value;
    }

    public void setValue(boolean value) {
        this.value = value;
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
    
    
}
