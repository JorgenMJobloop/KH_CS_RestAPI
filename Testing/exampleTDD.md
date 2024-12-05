```cs
using Nunit;

public class MyUnitTest 
{
    [Test]
    public static void Main(string[] args) 
    {
        Console.WriteLine("Hello, Nunit class!");
        Should_Return_True(); // run a test!
    }

    // Our tests should look something like this:
    [Fact]
    public bool Should_Return_True() 
    {
        bool[] samplePool = [false, true, false, true, true, false];
        bool expected = true;
        foreach(bool samples in samplePool) 
        {
            Assert.True(MyMethod(samples) == expected);
        }
        Assert.True(MyMethod(false) != expected); // if MyMethod returns true, we can assume the test wont fail!
    }
}

public class TestMe 
{
    public bool MyMethod(bool value) 
    {
        return value;
    }
}

```

```java
import static org.junit.jupiter.api.Assertions.assertEquals;
import java.io.IOException;
import java.net.UnknownHostException;
import ConsoleServer;
/*
    * Implement a Test that test a written Websocket connection in Java 21
    * Should work: - Accept a new client connection
    *              - Recieve a response from the server websocket if the connection is successful
    *              - Should fail if more than one client attempt to connect to the socket at the same time! 
*/

public class TestConsoleServer {
    @Test
    public void testResponse() throws UnknownHostException, IOException {
        CustomClient customClient = new CustomClient(); // assume this class exists in the package
        customClient.startConnection("127.0.0.1", 8888);
        String expected = customClient.sendMessage("ping");
        assertEquals("pong!", expected); // the actual test!
    }
}




public class ConsoleServer {
    private ServerSocket serverSocket;
    private Socket clientSocket;
    private BufferedReader reader;
    private PrintWriter writer;


    public void start(int port) throws IOException {
        serverSocket = new ServerSocket(port);
        
        while(true) {
            clientSocket = ServerSocket.accept();
            writer = new PrintWriter(clientSocket.getOutputStream(), true);
            reader = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));

            // our actual premise for testing
            String serverResponse = reader.readline();
            if("ping".equals(serverResponse)) {
                writer.println("pong!");
            }
            else {
                writer.println("Unrecognized input!");
            }
            // support more than one client at the time in our websocket(switch to a different port if two clients attempts to connect to the same port, by utilizing threads)
            String inputLine;
            while((inputLine = reader.readline() != null)) {
                if(".".equals(inputLine)) {
                    writer.println("Goodbye client!");
                    break;
                }
                writer.println(inputLine);
            }
        }
    }

    public void stop() throws IOException {
    writer.close();
    reader.close();
    clientSocket.close();
    serverSocket.close();
    }

    public static void main(String[] args) throws IOException {
        ConsoleServer server = new ConsoleServer();
        server.start(8888); // start the server on port 8888
    }
}
```