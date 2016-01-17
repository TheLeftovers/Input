/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.sql.BatchUpdateException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.Time;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.sql.Array;
import static parser.FileWatcher.watchDirectoryPath;

/**
 *
 * @author Roy van den Heuvel
 */
public class Parser {

    /**
     * @param args the command line arguments
     */
    static BufferedReader br = null;
    static String line;
    static String csvSplitBy = ";";
    static String url = "jdbc:postgresql://localhost:5432/project56";
    static Connection conn = null;
    static int arraySizeMax = 10000;

    public static void main(String[] args) {
        try {
            conn = DriverManager.getConnection(url, "postgres", "root");
        } catch (Exception e) {
            e.printStackTrace();
        }

        Path path = Paths.get("C:/Uploads/");
        
        watchDirectoryPath(path);
    }
    
    public static void insertEventInDb(ArrayList<Event> eventsArray) {
        try {
            PreparedStatement ps = conn.prepareStatement("INSERT INTO events VALUES(?, ?, ?, ?, ?);");

            for (Event event : eventsArray) {
                ps.setLong(1, event.getUnitId());
                ps.setString(2, event.getPort());
                ps.setBoolean(3, event.isValue());
                ps.setDate(4, event.getDate());
                ps.setTime(5, event.getTime());

                ps.addBatch();
            }

            ps.executeBatch();
            ps.close();
        } catch (BatchUpdateException e) {
            e.getNextException().printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void readEventsCsv(String csvFile){
        ArrayList eventsArray = new ArrayList<Event>();

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
                boolean boolValue = convertToBoolean(value);
                String[] dateTimeArray = dateTime.split(" ");
                String date = dateTimeArray[0];
                DateFormat format = new SimpleDateFormat("yyyy-MM-dd", Locale.ENGLISH);
                Date dateAsDate = null;
                java.sql.Date sqlDate = null;
                try {
                    dateAsDate = format.parse(date);
                    sqlDate = new java.sql.Date(dateAsDate.getTime());
                } catch (ParseException ex) {
                    Logger.getLogger(Parser.class.getName()).log(Level.SEVERE, null, ex);
                }
                String time = dateTimeArray[1];
                Time timeDate = Time.valueOf(time);

                Event event = new Event();

                event.setDate(sqlDate);
                event.setTime(timeDate);
                event.setUnitId(longUnitId);
                event.setPort(port);
                event.setValue(boolValue);
                
                eventsArray.add(event);
                if (eventsArray.size() >= arraySizeMax) {
                    insertEventInDb(eventsArray);
                    eventsArray.removeAll(eventsArray);
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    if (eventsArray.size() < arraySizeMax) {
                        insertEventInDb(eventsArray);
                        eventsArray.removeAll(eventsArray);
                    }
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }
    
    public static void insertConnectionsInDb(ArrayList<Connections> connectionArray) {
        try {
            PreparedStatement ps = conn.prepareStatement("INSERT INTO connections VALUES(?, ?, ?, ?, ?);");

            for (Connections con : connectionArray) {
                ps.setLong(1, con.getUnitId());
                ps.setString(2, con.getPort());
                ps.setBoolean(3, con.getValue());
                ps.setDate(4, con.getDate());
                ps.setTime(5, con.getTime());

                ps.addBatch();
            }

            ps.executeBatch();
            ps.close();
        } catch (BatchUpdateException e) {
            e.getNextException().printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void readConnectionsCsv(String csvFile) {
        
        ArrayList conArray = new ArrayList<Connections>();

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
                java.sql.Date sqlDate = null;
                try {
                    dateAsDate = format.parse(date);
                    sqlDate = new java.sql.Date(dateAsDate.getTime());
                } catch (ParseException ex) {
                    Logger.getLogger(Parser.class.getName()).log(Level.SEVERE, null, ex);

                }
                String time = dateTimeArray[1];
                String unitId = csvLineArray[1];
                long longUnitId = Long.parseLong(unitId);
                String port = csvLineArray[2];
                String value = csvLineArray[3];

                Time timeDate = Time.valueOf(time);

                boolean boolValue = convertToBoolean(value);

                Connections connection = new Connections();

                connection.setDate(sqlDate);
                connection.setTime(timeDate);
                connection.setUnitId(longUnitId);
                connection.setPort(port);
                connection.setValue(boolValue);

                conArray.add(connection);
                if (conArray.size() >= arraySizeMax) {
                    insertConnectionsInDb(conArray);
                    conArray.removeAll(conArray);
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    if (conArray.size() < arraySizeMax) {
                        insertConnectionsInDb(conArray);
                        conArray.removeAll(conArray);
                    }
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public static void insertMonitoringInDb(ArrayList<Monitoring> monitoringArray) {
        try {
            PreparedStatement ps = conn.prepareStatement("INSERT INTO monitoring VALUES(?, ?, ?, ?, ?, ?, ?);");

            for (Monitoring mon : monitoringArray) {
                ps.setLong(1, mon.getUnitId());
                ps.setString(2, mon.getType());
                ps.setLong(3, mon.getMin());
                ps.setLong(4, mon.getMax());
                ps.setLong(5, mon.getSum());
                ps.setString(6, mon.getBeginTime());
                ps.setTimestamp(7, mon.getEndTime());

                ps.addBatch();
            }

            ps.executeBatch();
            ps.close();

        } catch (BatchUpdateException e) {
            e.getNextException().printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void readMonitoringCsv(String csvFile) {
        
        ArrayList monArray = new ArrayList<Monitoring>();

        try {

            br = new BufferedReader(new FileReader(csvFile));
            br.readLine();
            while ((line = br.readLine()) != null) {

                String[] csvLineArray = line.split(csvSplitBy);

                String unitId = csvLineArray[0];
                long longUnitId = Long.parseLong(unitId);

                String beginTimeA = csvLineArray[1];
                String StringBegin = String.valueOf(beginTimeA);

                String endTimeA = csvLineArray[2];

                DateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.ENGLISH);
                java.util.Date beginTime = null;
                java.util.Date endTime = null;
                java.sql.Timestamp sqlEndTime = null;
                try {
                    beginTime = format.parse(beginTimeA);
                    endTime = format.parse(endTimeA);
                    sqlEndTime = new java.sql.Timestamp(endTime.getTime());
                } catch (ParseException ex) {
                    Logger.getLogger(Parser.class.getName()).log(Level.SEVERE, null, ex);
                }

                String type = csvLineArray[3];

                String min = csvLineArray[4];
                long longMin = Double.valueOf(min).longValue();

                String max = csvLineArray[5];
                long longMax = Double.valueOf(max).longValue();

                String sum = csvLineArray[6];
                long longSum = Double.valueOf(sum).longValue();

                Monitoring mon = new Monitoring();
                mon.setBeginTime(StringBegin);
                mon.setEndTime(sqlEndTime);
                mon.setMax(longMax);
                mon.setMin(longMin);
                mon.setSum(longSum);
                mon.setType(type);
                mon.setUnitId(longUnitId);

                monArray.add(mon);

                if (monArray.size() >= arraySizeMax) {
                    insertMonitoringInDb(monArray);
                    monArray.removeAll(monArray);
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    if (monArray.size() < arraySizeMax) {
                        insertMonitoringInDb(monArray);
                        monArray.removeAll(monArray);
                    }
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public static void insertPositionsInDb(ArrayList<Position> positions) {
        try {
            PreparedStatement ps = conn.prepareStatement("INSERT INTO positions VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);");

            for (Position position : positions) {

                ps.setLong(1, position.getUnitId());
                ps.setDouble(2, position.getRdx());
                ps.setDouble(3, position.getRdy());
                ps.setInt(4, position.getSpeed());
                ps.setInt(5, position.getCourse());
                ps.setInt(6, position.getNumSatellites());
                ps.setInt(7, position.getHDOP());
                ps.setString(8, position.getQuality());
                ps.setDate(9, position.getDate());
                ps.setTime(10, position.getTime());

                ps.addBatch();
            }

            ps.executeBatch();
            ps.close();

        } catch (BatchUpdateException e) {
            e.getNextException().printStackTrace();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void readPositionsCsv(String csvFile) {
        
        ArrayList positions = new ArrayList<Position>();

        try {

            br = new BufferedReader(new FileReader(csvFile));
            br.readLine();
            while ((line = br.readLine()) != null) {

                String[] csvLineArray = line.split(csvSplitBy);
                String dateTime = csvLineArray[0];
                String[] dateTimeArray = dateTime.split(" ");
                String date = dateTimeArray[0];
                java.sql.Date sqlDate = new java.sql.Date(0000, 00, 00);
                try {
                    SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
                    Date parsed = format.parse(date);
                    sqlDate = new java.sql.Date(parsed.getTime());
                } catch (ParseException ex) {
                    Logger.getLogger(Parser.class.getName()).log(Level.SEVERE, null, ex);
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

                Time timeDate = Time.valueOf(time);

                long longUnitId = Long.parseLong(unitId);
                double doubleRdx = Double.parseDouble(rdx);
                double doubleRdy = Double.parseDouble(rdy);
                double[] coordinateArray = convertToLonLat(doubleRdx, doubleRdy);
                double lat = coordinateArray[0];
                double lon = coordinateArray[1];
                
                int intSpeed = Integer.parseInt(speed);
                int intCourse = Integer.parseInt(course);
                int intNumSatallites = Integer.parseInt(numSatallites);
                int intHDOP = Integer.parseInt(HDOP);

                Position position = new Position();
                position.setCourse(intCourse);
                position.setDate(sqlDate);
                position.setHDOP(intHDOP);
                position.setNumSatellites(intNumSatallites);
                position.setQuality(quality);
                position.setRdx(lat);
                position.setRdy(lon);
                position.setSpeed(intSpeed);
                position.setTime(timeDate);
                position.setUnitId(longUnitId);

                positions.add(position);
                if (positions.size() >= arraySizeMax) {
                    insertPositionsInDb(positions);
                    positions.removeAll(positions);
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (br != null) {
                try {
                    if (positions.size() < arraySizeMax) {
                        insertPositionsInDb(positions);
                        positions.removeAll(positions);
                    }
                    br.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    private static boolean convertToBoolean(String value) {
        boolean returnValue = false;
        if ("1".equalsIgnoreCase(value)) {
            returnValue = true;
        }
        return returnValue;
    }
    
    private static double[] convertToLonLat(double rdx, double rdy){
        int referenceRdX = 155000;
        int referenceRdY = 463000;
        
        double dX = (double)(rdx - referenceRdX) * (double)(Math.pow(10,-5));
        double dY = (double)(rdy - referenceRdY) * (double)(Math.pow(10,-5));

        double sumN = 
            (3235.65389 * dY) + 
            (-32.58297 * Math.pow(dX, 2)) + 
            (-0.2475 * Math.pow(dY, 2)) + 
            (-0.84978 * Math.pow(dX, 2) * dY) + 
            (-0.0655 * Math.pow(dY, 3)) + 
            (-0.01709 * Math.pow(dX, 2) * Math.pow(dY, 2)) + 
            (-0.00738 * dX) + 
            (0.0053 * Math.pow(dX, 4)) + 
            (-0.00039 * Math.pow(dX, 2) * Math.pow(dY, 3)) + 
            (0.00033 * Math.pow(dX, 4) * dY) + 
            (-0.00012 * dX * dY);
        double sumE = 
            (5260.52916 * dX) + 
            (105.94684 * dX * dY) + 
            (2.45656 * dX * Math.pow(dY, 2)) + 
            (-0.81885 * Math.pow(dX, 3)) + 
            (0.05594 * dX * Math.pow(dY, 3)) + 
            (-0.05607 * Math.pow(dX, 3) * dY) + 
            (0.01199 * dY) + 
            (-0.00256 * Math.pow(dX, 3) * Math.pow(dY, 2)) + 
            (0.00128 * dX * Math.pow(dY, 4)) + 
            (0.00022 * Math.pow(dY, 2)) + 
            (-0.00022 * Math.pow(dX, 2)) + 
            (0.00026 * Math.pow(dX, 5));
                // The city "Amsterfoort" is used as reference "WGS84" coordinate.
            double referenceWgs84X = 52.15517;
            double referenceWgs84Y = 5.387206;

            double latitude = referenceWgs84X + (sumN / 3600);
            double longitude = referenceWgs84Y + (sumE / 3600);

            // Input
            // x = 122202
            // y = 487250
            //
            // Result
            // "52.372143838117, 4.90559760435224"
            double[] result = new double[2];
            result[0] = latitude;
            result[1] = longitude;
            
            return result;
    }
}
