/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parserprototype;

/**
 *
 * @author Roy van den Heuvel
 */
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class ParserPrototype {

    ArrayList<Event> events = new ArrayList<Event>();

    public static void main(String[] args) {

        ParserPrototype obj = new ParserPrototype();
        obj.run();

    }

    public void run() {

        String csvFile = "..//csv//events.csv";
        
        BufferedReader br = null;
        String line;
        String csvSplitBy = ";";

        try {

            br = new BufferedReader(new FileReader(csvFile));
            while ((line = br.readLine()) != null) {

                String[] csvLineArray = line.split(csvSplitBy);
                String dateTime = csvLineArray[0];
                String unitId = csvLineArray[1];
                String port = csvLineArray[2];
                String value = csvLineArray[3];
                Event event = new Event();
                event.setDateTime(dateTime);
                event.setUnitId(unitId);
                event.setPort(port);
                event.setValue(value);
                events.add(event);
            }

            System.out.println("______________________________________________________________________________");
            System.out.println("__Done reading file and filling array. Program will now start reading array.__");
            System.out.println("______________________________________________________________________________");
            for (Event event : events) {
                System.out.println(event.getDateTime());
                System.out.println(event.getUnitId());
                System.out.println(event.getPort());
                System.out.println(event.getValue());
                System.out.println("_____________________________________________");
            }

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
