package inputprototype;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * @author Roy van den Heuvel
 */
public class InputPrototype {

    public static void main(String[] args) {

        String fileNameDefined = "..\\csv\\Positions.csv";

        File file = new File(fileNameDefined);

        try {

            Scanner inputStream = new Scanner(file);

            while (inputStream.hasNext()) {

                String data = inputStream.next();
                System.out.println(data);

            }
            inputStream.close();

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

    }

}
