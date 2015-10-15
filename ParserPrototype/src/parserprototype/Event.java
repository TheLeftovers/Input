/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parserprototype;

/**
 * @author Roy van den Heuvel
 */
public class Event {
    private String dateTime;
    private String unitId;
    private String port;
    private String value;
    public Event(){
        
    }

    public String getDateTime() {
        return dateTime;
    }

    public String getUnitId() {
        return unitId;
    }

    public String getPort() {
        return port;
    }

    public String getValue() {
        return value;
    }

    public void setDateTime(String dateTime) {
        this.dateTime = dateTime;
    }

    public void setUnitId(String unitId) {
        this.unitId = unitId;
    }

    public void setPort(String port) {
        this.port = port;
    }

    public void setValue(String value) {
        this.value = value;
    }
}
