/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parser;

import static java.nio.file.LinkOption.NOFOLLOW_LINKS;
import static java.nio.file.StandardWatchEventKinds.ENTRY_CREATE;
import static java.nio.file.StandardWatchEventKinds.OVERFLOW;
import static java.nio.file.StandardWatchEventKinds.ENTRY_DELETE;
import static java.nio.file.StandardWatchEventKinds.ENTRY_MODIFY;

import java.io.IOException;
import java.nio.file.FileSystem;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.WatchEvent;
import java.nio.file.WatchEvent.Kind;
import java.nio.file.WatchKey;
import java.nio.file.WatchService;
import static parser.Parser.readConnectionsCsv;
import static parser.Parser.readEventsCsv;
import static parser.Parser.readMonitoringCsv;
import static parser.Parser.readPositionsCsv;

/**
 *
 * @author Roy van den Heuvel
 */
public class FileWatcher {
    public static void watchDirectoryPath(Path path) {
        // Sanity check - Check if path is a folder
        try {
            Boolean isFolder = (Boolean) Files.getAttribute(path,
                    "basic:isDirectory", NOFOLLOW_LINKS);
            if (!isFolder) {
                throw new IllegalArgumentException("Path: " + path
                        + " is not a folder");
            }
        } catch (IOException ioe) {
            // Folder does not exists
            ioe.printStackTrace();
        }

        System.out.println("Watching path: " + path);

        // We obtain the file system of the Path
        FileSystem fs = path.getFileSystem();

        // We create the new WatchService using the new try() block
        try (WatchService service = fs.newWatchService()) {

            // We register the path to the service
            // We watch for creation events
            path.register(service, ENTRY_CREATE, ENTRY_MODIFY, ENTRY_DELETE); 

            // Start the infinite polling loop
            WatchKey key;
            while (true) {
                key = service.take();

                // Dequeueing events
                Kind<?> kind;
                for (WatchEvent<?> watchEvent : key.pollEvents()) {
                    // Get the type of the event
                    kind = watchEvent.kind();
                    if (OVERFLOW == kind) {
                        continue; // loop
                    } else if (ENTRY_CREATE == kind) {
                        // A new Path was created
                        Path newPath = ((WatchEvent<Path>) watchEvent)
                                .context();
                        // Output
                        checkPath(newPath.toString());
                        System.out.println("New path created: " + newPath);
                    } else if (ENTRY_MODIFY == kind) {
                        // modified
                        Path newPath = ((WatchEvent<Path>) watchEvent)
                                .context();
                        // Output
                        checkPath(newPath.toString());
                        System.out.println("New path modified: " + newPath);
                    }
                }

                if (!key.reset()) {
                    break; // loop
                }
            }

        } catch (IOException | InterruptedException ioe) {
            ioe.printStackTrace();
        }
    }
    
    public static void checkPath(String pathToCheck){
        if(pathToCheck.equals("monitoring.csv") || pathToCheck.equals("Monitoring.csv")){
            readMonitoringCsv();
        } else if(pathToCheck.equals("events.csv") || pathToCheck.equals("Events.csv")){
            readEventsCsv();
        } else if(pathToCheck.equals("connections.csv") || pathToCheck.equals("Connections.csv")){
            readConnectionsCsv();
        } else if(pathToCheck.equals("positions.csv") || pathToCheck.equals("Positions.csv" )){
            readPositionsCsv();
        } else {
            System.out.println("Csv type incorrect/not available.");
        }
    }
}
