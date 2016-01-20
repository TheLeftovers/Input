package parser;

import static java.nio.file.StandardWatchEventKinds.ENTRY_CREATE;
import static java.nio.file.StandardWatchEventKinds.OVERFLOW;

import java.io.IOException;
import java.nio.file.FileSystem;
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
        if (path != null) {

            System.out.println("Watching path: " + path);

            FileSystem fs = path.getFileSystem();

            try (WatchService service = fs.newWatchService()) {

                path.register(service, ENTRY_CREATE);

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
                            System.out.println("New path created/modified: " + newPath);
                            checkPath(newPath.toString());
                            
                        } 
                    }

                    if (!key.reset()) {
                        break; // resets the key so it continues to look for new creation events.
                    }
                }

            } catch (IOException | InterruptedException ioe) {
                System.out.println("The file watcher was interrupted.");
            }
        }
    }

    public static void checkPath(String pathToCheck) {
        String standardPath = "C:/Uploads/";
        if (pathToCheck.equals("monitoring.csv") || pathToCheck.equals("Monitoring.csv")) {
            readMonitoringCsv(standardPath + pathToCheck);
        } else if (pathToCheck.equals("events.csv") || pathToCheck.equals("Events.csv")) {
            readEventsCsv(standardPath + pathToCheck);
        } else if (pathToCheck.equals("connections.csv") || pathToCheck.equals("Connections.csv")) {
            readConnectionsCsv(standardPath + pathToCheck);
        } else if (pathToCheck.equals("positions.csv") || pathToCheck.equals("Positions.csv")) {
            readPositionsCsv(standardPath + pathToCheck);
        } else {
            System.out.println("Csv type incorrect/not available.");
        }
    }
}
