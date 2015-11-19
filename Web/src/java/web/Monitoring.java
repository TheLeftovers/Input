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
public class Monitoring {
    private long unitId;
    private String type;
    private long min;
    private long max;
    private Time begin_time;
    private Time end_time;
    private long sum;

    public Monitoring() {
    }

    public Monitoring(long unitId, String type, long min, long max, Time begin_time, Time end_time, long sum) {
        this.unitId = unitId;
        this.type = type;
        this.min = min;
        this.max = max;
        this.begin_time = begin_time;
        this.end_time = end_time;
        this.sum = sum;
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

    public Time getBegin_time() {
        return begin_time;
    }

    public void setBegin_time(Time begin_time) {
        this.begin_time = begin_time;
    }

    public Time getEnd_time() {
        return end_time;
    }

    public void setEnd_time(Time end_time) {
        this.end_time = end_time;
    }

    public long getSum() {
        return sum;
    }

    public void setSum(long sum) {
        this.sum = sum;
    }

    @Override
    public String toString() {
        return "Monitoring{" + "unitId=" + unitId + ", type=" + type + ", min=" + min + ", max=" + max + ", begin_time=" + begin_time + ", end_time=" + end_time + ", sum=" + sum + '}';
    }
    
    
}
