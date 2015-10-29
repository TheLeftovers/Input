package parserprototype;

/**
 * @author Roy van den Heuvel
 */
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ParserPrototype {

    ArrayList<Event> events = new ArrayList<Event>();
    ArrayList<Position> positions = new ArrayList<Position>();
    ArrayList<Connection> connections = new ArrayList<Connection>();
    ArrayList<Monitoring> monitoring = new ArrayList<Monitoring>();
    static BufferedReader br = null;
    static String line;
    static String csvSplitBy = ";";

    public static void main(String[] args) {
        ParserPrototype obj = new ParserPrototype();
        obj.runEventCsv();
        obj.runConnectionsCsv();
        obj.runPositionsCsv();
        obj.runMonitoringCsv();
    }
    
    public void runMonitoringCsv(){
        String csvFile = "..//csv//monitoring.csv";
        
        
    }

    public void runConnectionsCsv() {
        String csvFile = "..//csv//connections.csv";

        try {

            br = new BufferedReader(new FileReader(csvFile));
            br.readLine();
            while ((line = br.readLine()) != null) {
                String[] csvLineArray = line.split(csvSplitBy);
                String dateTime = csvLineArray[0];
                String[] dateTimeArray = dateTime.split(" ");
                String date = dateTimeArray[0];
                DateFormat format = new SimpleDateFormat("yyyy-MM-dd", Locale.ENGLISH);
                Date dateAsDate = null;
                try {
                    dateAsDate = format.parse(date);
                } catch (ParseException ex) {
                    Logger.getLogger(ParserPrototype.class.getName()).log(Level.SEVERE, null, ex);
                }
                String time = dateTimeArray[1];
                String unitId = csvLineArray[1];
                long longUnitId = Long.parseLong(unitId);
                String port = csvLineArray[2];
                String value = csvLineArray[3];
                short intValue = Short.parseShort(value);
                
                Connection connection = new Connection();
                
                connection.setDate(dateAsDate);
                connection.setTime(time);
                connection.setPort(port);
                connection.setUnitId(longUnitId);
                connection.setValue(intValue);
                
                connections.add(connection);
            }
            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Connections file and filling array. ___________________________");
            System.out.println("______________________________________________________________________________");
            System.out.println("Date: " + connections.get(connections.size() - 1).getDate());
            System.out.println("Time: " + connections.get(connections.size() - 1).getTime());
            System.out.println("Port: " + connections.get(connections.size() - 1).getPort());
            System.out.println("UnitId: " + connections.get(connections.size() - 1).getUnitId());
            System.out.println("Value: " + connections.get(connections.size() - 1).getValue());
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public void runEventCsv() {
        String csvFile = "..//csv//events.csv";

        try {

            br = new BufferedReader(new FileReader(csvFile));
            br.readLine();
            while ((line = br.readLine()) != null) {

                String[] csvLineArray = line.split(csvSplitBy);
                String dateTime = csvLineArray[0];
                String unitId = csvLineArray[1];
                long longUnitId = Long.parseLong(unitId);
                String port = csvLineArray[2];
                String value = csvLineArray[3];
                int intValue = Integer.parseInt(value);
                String[] dateTimeArray = dateTime.split(" ");
                String date = dateTimeArray[0];
                DateFormat format = new SimpleDateFormat("yyyy-MM-dd", Locale.ENGLISH);
                Date dateAsDate = null;
                try {
                    dateAsDate = format.parse(date);
                } catch (ParseException ex) {
                    Logger.getLogger(ParserPrototype.class.getName()).log(Level.SEVERE, null, ex);
                }
                String time = dateTimeArray[1];
                Event event = new Event();

                event.setDate(dateAsDate);
                event.setTime(time);
                event.setUnitId(longUnitId);
                event.setPort(port);
                event.setValue(intValue);
                events.add(event);
            }

            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Events file and filling array. Program will now start reading array.__");
            System.out.println("______________________________________________________________________________");
            System.out.println("Date: " + events.get(events.size() - 1).getDate());
            System.out.println("Time: " + events.get(events.size() - 1).getTime());
            System.out.println("Port: " + events.get(events.size() - 1).getPort());
            System.out.println("UnitId: " + events.get(events.size() - 1).getUnitId());
            System.out.println("Value: " + events.get(events.size() - 1).getValue());

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public void runPositionsCsv() {
        String csvFile = "..//csv//positions.csv";

        try {

            br = new BufferedReader(new FileReader(csvFile));
            br.readLine();
            while ((line = br.readLine()) != null) {

                String[] csvLineArray = line.split(csvSplitBy);
                String dateTime = csvLineArray[0];
                String[] dateTimeArray = dateTime.split(" ");
                String date = dateTimeArray[0];
                DateFormat format = new SimpleDateFormat("yyyy-MM-dd", Locale.ENGLISH);
                Date dateAsDate = null;
                try {
                    dateAsDate = format.parse(date);
                } catch (ParseException ex) {
                    Logger.getLogger(ParserPrototype.class.getName()).log(Level.SEVERE, null, ex);
                }
                String time = dateTimeArray[1];
                String unitId = csvLineArray[1];
                String rdx = csvLineArray[2];
                String rdy = csvLineArray[3];
                String speed = csvLineArray[4];
                String course = csvLineArray[5];
                String numSatallites = csvLineArray[6];
                String HDOP = csvLineArray[7];
                String quality = csvLineArray[8];

                long longUnitId = Long.parseLong(unitId);
                float floatRdx = Float.parseFloat(rdx);
                float floatRdy = Float.parseFloat(rdy);
                int intSpeed = Integer.parseInt(speed);
                int intCourse = Integer.parseInt(course);
                int intNumSatallites = Integer.parseInt(numSatallites);
                int intHDOP = Integer.parseInt(HDOP);

                Position position = new Position();
                position.setDate(dateAsDate);
                position.setTime(time);
                position.setUnitId(longUnitId);
                position.setRdx(floatRdx);
                position.setRdy(floatRdy);
                position.setSpeed(intSpeed);
                position.setCourse(intCourse);
                position.setNumSatallites(intNumSatallites);
                position.setHDOP(intHDOP);
                position.setQuality(quality);

                positions.add(position);
            }

            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Positions file and filling array. Program will now start reading array.__");
            System.out.println("______________________________________________________________________________");
            Position position = positions.get(positions.size() - 1);
            System.out.println("Date: " + position.getDate());
            System.out.println("Time: " + position.getTime());
            System.out.println("UnitId: " + position.getUnitId());
            System.out.println("Rdx: " + position.getRdx());
            System.out.println("Rdy: " + position.getRdy());
            System.out.println("Speed: " + position.getSpeed());
            System.out.println("Course: " + position.getCourse());
            System.out.println("NumSatallites: " + position.getNumSatallites());
            System.out.println("HDOP: " + position.getHDOP());
            System.out.println("Quality: " + position.getQuality());
            System.out.println("_____________________________________________");

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
