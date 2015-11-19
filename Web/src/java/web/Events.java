/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package web;

import java.sql.Time;
import java.util.Date;

/**
 *
 * @author Johan Bos
 */
public class Events {
    private long unitId;
    private String port;
    private boolean value;
    private Date date;
    private Time time;

    public Events() {
    }

    public Events(long unitId, String port, boolean value, Date date, Time time) {
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

    @Override
    public String toString() {
        return "Events{" + "unitId=" + unitId + ", port=" + port + ", value=" + value + ", date=" + date + ", time=" + time + '}';
    }
    
    
           
}
