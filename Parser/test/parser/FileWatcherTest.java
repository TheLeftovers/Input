/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import java.nio.file.Path;
import java.nio.file.Paths;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Roy van den Heuvel
 */
public class FileWatcherTest {
    
    public FileWatcherTest() {
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
     * Test of watchDirectoryPath method, of class FileWatcher.
     */
    @Test
    public void testWatchDirectoryPath() {
        System.out.println("watchDirectoryPath");
        Path path = Paths.get("../csv/Monitoring.csv");
        FileWatcher.watchDirectoryPath(path);
        // TODO review the generated test code and remove the default call to fail.
        
    }

    /**
     * Test of checkPath method, of class FileWatcher.
     */
    @Test
    public void testCheckPath() {
        System.out.println("checkPath");
        String pathToCheck = "";
        FileWatcher.checkPath(pathToCheck);
        // TODO review the generated test code and remove the default call to fail.
        fail("The test case is a prototype.");
    }
    
}
