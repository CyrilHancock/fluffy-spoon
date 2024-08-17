
# fluffy-spoon

Welcome to my HTTP server project! 🚀 This project is a personal learning experience to understand how HTTP servers work behind the scenes. Please note that this is not an industry-standard project, but a learning tool. 🛠️

## Overview

This project is a basic implementation of an HTTP server in C#. It demonstrates how to set up a TCP server, handle HTTP requests, and send responses. The server listens on IP address `127.0.0.1` and port `4221`. It can handle `GET` and `POST` requests, process them, and return appropriate responses.

## Project Structure

1. **`Server.cs`** - Sets up the TCP server, listens for incoming connections, and handles data communication.
2. **`Request.cs`** - Contains logic for parsing HTTP requests, finding matching routes, and generating responses.
3. **`Routes.cs`** - Defines route handlers for different endpoints using custom attributes.

## Getting Started

### Prerequisites

- .NET SDK installed on your machine
- Basic understanding of C# and HTTP concepts

### How to Run

1. Clone the repository:

     
       git clone https://github.com/CyrilHancock/fluffy-spoon.git
       cd fluffy-spoon

   
2. Build and run the server:

    dotnet build
    dotnet run --project codecrafters-http-server.csproj

The server will start and listen on 127.0.0.1:4221. You can test it using tools like Postman or curl.

## Code Overview

**Server.cs**

 - Creates a socket to listen for incoming TCP connections.
 -  Accepts client connections and reads data. 
 - Processes requests and sends responses.

**Request.cs**

 - Parses incoming HTTP requests into a DTO (Data Transfer Object).
 - Finds and invokes methods based on request routes and types.
 - Handles errors and generates appropriate HTTP responses
 
**Routes.cs**
 - Defines routes and methods using custom attributes. 
 - Provides example implementations for handling requests.

**Contributing**
Feel free to fork the repository, make changes, and submit pull requests. Any feedback or improvements are welcome!

**License**
This project is licensed under the MIT License.

**Disclaimer**

> This project is created for learning purposes and is not intended for
> production use. Please do not judge the code quality too harshly; it’s
> a learning experiment. 🥲

**Contact**

 - [ ] If you have any questions or comments, feel free to reach out to
       me on LinkedIn or through my email: hancockcyril1910@gmail.com

Happy coding! 🌟
