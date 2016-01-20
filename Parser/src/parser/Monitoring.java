package parser;

import java.sql.Timestamp;

/**
 *
 * @author Roy van den Heuvel
 */
public class Monitoring {

    long unitId;
    String type;
    long min;
    long max;
    String  beginTime;
    String endTime;
    long sum;

    public Monitoring(long unitId, String type, long min, long max, String beginTime, String endTime, long sum) {
        this.unitId = unitId;
        this.type = type;
        this.min = min;
        this.max = max;
        this.beginTime = beginTime;
        this.endTime = endTime;
        this.sum = sum;
    }

    public Monitoring() {
    }
    
    

    public String getBeginTime() {
        return beginTime;
    }

    public void setBeginTime(String beginTime) {
        this.beginTime = beginTime;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
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
    
    
    
}
