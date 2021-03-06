package parserprototype;

/**
 * @author Roy van den Heuvel
 */
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.sql.Time;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class ParserPrototype {

    static BufferedReader br = null;
    static String line;
    static String csvSplitBy = ";";

    public static void main(String[] args) {
        
        new Thread(){
            public void run(){
                runEventCsv();
            }
        }.run();
        
        new Thread(){
            public void run(){
                runConnectionsCsv();
            }
        }.run();
        
        new Thread(){
            public void run(){
                runMonitoringCsv();
            }
        }.run();
        
        new Thread(){
            public void run(){
                runPositionsCsv();
            }
        }.run();
        
    }

    public static void runMonitoringCsv() {
        String csvFile = "..//csv//monitoring.csv";

        try {

            br = new BufferedReader(new FileReader(csvFile));
            br.readLine();
            while ((line = br.readLine()) != null) {
                String[] csvLineArray = line.split(csvSplitBy);

                String unitId = csvLineArray[0];
                long longUnitId = Long.parseLong(unitId);

                String beginTimeA = csvLineArray[1];

                String endTimeA = csvLineArray[2];

                DateFormat format = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.ENGLISH);
                Date beginTime = null;
                Date endTime = null;
                try {
                    beginTime = format.parse(beginTimeA);
                    endTime = format.parse(endTimeA);
                } catch (ParseException ex) {
                    Logger.getLogger(ParserPrototype.class.getName()).log(Level.SEVERE, null, ex);
                }

                String type = csvLineArray[3];

                String min = csvLineArray[4];
                long longMin = Double.valueOf(min).longValue();

                String max = csvLineArray[5];
                long longMax = Double.valueOf(max).longValue();

                String sum = csvLineArray[6];
                long longSum = Double.valueOf(sum).longValue();

                MonitoringPK monitoringPK = new MonitoringPK();
                monitoringPK.setBeginTime(beginTime);
                monitoringPK.setEndTime(endTime);
                monitoringPK.setType(type);
                monitoringPK.setUnitId(longUnitId);

                Monitoring monitoring = new Monitoring();
                monitoring.setMonitoringPK(monitoringPK);
                monitoring.setMax(longMax);
                monitoring.setMin(longMin);
                monitoring.setSum(longSum);
                try {
                    persist(monitoring);
                } catch (Exception e) {
                    System.out.println("Duplicate entry found.");
                }

            }
            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Monitoring file and filling database. _________________________");
            System.out.println("______________________________________________________________________________");

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

    public static void runConnectionsCsv() {
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

                Time timeDate = Time.valueOf(time);

                boolean boolValue = convertToBoolean(value);

                Connections connection = new Connections();

                connection.setDate(dateAsDate);
                connection.setTime(timeDate);
                connection.setUnitId(longUnitId);
                connection.setPort(port);
                connection.setValue(boolValue);

                persist(connection);
            }
            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Connections file and filling array. ___________________________");
            System.out.println("______________________________________________________________________________");

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

    public static void runEventCsv() {
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
                boolean boolValue = convertToBoolean(value);
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
                Time timeDate = Time.valueOf(time);

                Events event = new Events();

                event.setDate(dateAsDate);
                event.setTime(timeDate);
                event.setUnitId(longUnitId);
                event.setPort(port);
                event.setValue(boolValue);

                persist(event);

            }

            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Events file and filling array._________________________________");
            System.out.println("______________________________________________________________________________");

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

    public static void runPositionsCsv() {
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

                Time timeDate = Time.valueOf(time);

                long longUnitId = Long.parseLong(unitId);
                double floatRdx = Double.parseDouble(rdx);
                double floatRdy = Double.parseDouble(rdy);
                int intSpeed = Integer.parseInt(speed);
                int intCourse = Integer.parseInt(course);
                int intNumSatallites = Integer.parseInt(numSatallites);
                int intHDOP = Integer.parseInt(HDOP);

                Positions position = new Positions();
                PositionsPK positionPK = new PositionsPK();

                positionPK.setDate(dateAsDate);
                positionPK.setTime(timeDate);
                positionPK.setUnitId(longUnitId);

                position.setCourse(intCourse);
                position.setHdop(intHDOP);
                position.setNumSatellites(intNumSatallites);
                position.setPositionsPK(positionPK);
                position.setQuality(quality);
                position.setRdX(floatRdx);
                position.setRdY(floatRdy);
                position.setSpeed(intSpeed);

                persist(position);
            }

            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading Positions file and filling database.___________________________");
            System.out.println("______________________________________________________________________________");

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

    private static boolean convertToBoolean(String value) {
        boolean returnValue = false;
        if ("1".equalsIgnoreCase(value)) {
            returnValue = true;
        }
        return returnValue;
    }

    public static void persist(Object object) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("ParserPrototypePU");
        EntityManager em = emf.createEntityManager();
        em.getTransaction().begin();
        try {
            em.persist(object);
            em.getTransaction().commit();

        } catch (Exception e) {
            e.printStackTrace();
            em.getTransaction().rollback();
        } finally {
            em.close();
        }
    }
}
