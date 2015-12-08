/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import java.sql.Date;
import java.sql.Time;
import java.util.ArrayList;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.Ignore;

/**
 *
 * @author Roy van den Heuvel
 */
public class ParserTest {
    
    public ParserTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of main method, of class Parser.
     */
    @Ignore
    @Test
    public void testMain() {
        System.out.println("main");
        String[] args = null;
        Parser.main(args);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertEventInDb method, of class Parser.
     */
    @Ignore
    @Test
    public void testInsertEventInDb() {
        System.out.println("insertEventInDb");
        ArrayList<Event> eventsArray = null;
        Parser.insertEventInDb(eventsArray);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of readEventsCsv method, of class Parser.
     */
    @Ignore
    @Test
    public void testReadEventsCsv() {
        System.out.println("readEventsCsv");
        Parser.readEventsCsv();
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertConnectionsInDb method, of class Parser.
     */
    @Ignore
    @Test
    public void testInsertConnectionsInDb() {
        System.out.println("insertConnectionsInDb");
        ArrayList<Connections> connectionArray = null;
        Parser.insertConnectionsInDb(connectionArray);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of readConnectionsCsv method, of class Parser.
     */
    @Ignore
    @Test
    public void testReadConnectionsCsv() {
        System.out.println("readConnectionsCsv");
        Parser.readConnectionsCsv();
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertMonitoringInDb method, of class Parser.
     */
    @Ignore
    @Test
    public void testInsertMonitoringInDb() {
        System.out.println("insertMonitoringInDb");
        ArrayList<Monitoring> monitoringArray = null;
        Parser.insertMonitoringInDb(monitoringArray);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of readMonitoringCsv method, of class Parser.
     */
    @Ignore
    @Test
    public void testReadMonitoringCsv() {
        System.out.println("readMonitoringCsv");
        Parser.readMonitoringCsv();
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }

    /**
     * Test of insertPositionsInDb method, of class Parser.
     */
    @Test
    public void testInsertPositionsInDb() {
        System.out.println("insertPositionsInDb");
        ArrayList<Position> Positions = new ArrayList<>();
        Date date = new Date(10,10,10);
        Time time = new Time(10,10,10);
        Position position = new Position(74834, 1.000, 2.000, 100, 100, 4, "Good", date, time, 1);
        
        Positions.add(position);
        Parser.insertPositionsInDb(Positions);
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }

    /**
     * Test of readPositionsCsv method, of class Parser.
     */
    @Ignore
    @Test
    public void testReadPositionsCsv() {
        System.out.println("readPositionsCsv");
        
        Parser.readPositionsCsv();
        // TODO review the generated test code and remove the default call to fail.
        //fail("The test case is a prototype.");
    }
    
}
