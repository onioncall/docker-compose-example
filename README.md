# Docker
---

What is Docker?
- Docker is a platform for developing, shipping, and running applications in containers.

What are Containers? 
- A running instance of a docker image. 

What are Images?
- Blueprints/Build instructions for containers. In Object Oriented terms, you can think of Images as a Class and a container as an instance of that class. 

------------------------------------

# Why Containerize?
---
Here are the key benefits of containerization:

1. Consistency and Reproducibility
- Ensures applications run the same way across different environments 
    - (particularly useful if you develop on one operating system, like Windows and deploy to another, like Linux)
- Eliminates "it works on my machine" problems
- Makes development, testing, and production environments consistent

2. Isolation and Resource Efficiency
- Applications run in isolated environments with their own dependencies

3. Scalability and Management
- Easy to scale applications horizontally
- Quick start-up and shutdown times

4. Version Control and Rollback
- Container images are versioned
- Easy to roll back to previous versions
- Simple to maintain different versions of applications

------------------------------------

# Docker Compose 
---

What is Docker Compose?
- In the same way that a dockerfile is basically config file for you containers blueprints/build instructions, a compose.yaml file is just a config file for your docker commands. 

When running docker commands in the command line, they can quickly become exhausting.

- Building an image
docker build -t myapp:1.0 -f Dockerfile.dev .

this command is building a docker image, then "tagging" (-t) that image with the name of tha application, then specifying the docker file location of the application you are running. 

- Running an container
docker run -d -e DATABASE_URL=postgres://localhost:5432 -p 8080:80 -v ./volume myapp:1.0

this command is starting and running a container from that image in detatch mode (-d), setting environment variables (-e), specifying ports you want the container to run on (-p) and specifying a volume that persists data from across different instances of the container (-v).

These aren't all needed, and are many more commands I don't know or use. But they highlight the different commands that might be needed to optimize testing in your workflow. The Docker compose allows a built in way to configure all these settings so you don't need to use them in the command line when ever you spin up the application. Which brings us to the next benefit of the docker compose, it allows you to spin up multiple containers/applications from one command. 


------------------------------------

# Demo Project Structure
---

docker-compose-demo/
├── server/
│   ├── AuthService/
│   │   ├── Api
│   │   ├── Domain
│   │   ├── Persistence
│   │   └── Dockerfile
│   │
│   ├── ProductService/
│   │   ├── Api
│   │   ├── Domain
│   │   ├── Persistence
│   │   └── Dockerfile
│   │
│   └── EmailService/
│       ├── Api
│       ├── Domain
│       ├── Persistence
│       └── Dockerfile
│
│   
├── client/
│   ├── Login Page
│   ├── Product Page
│   └── Dockerfile
│
├── database/
│   └── test_site_core
│       ├── auth
│       └── email
│
└── compose.yaml


# TODO
---

- Build out emails in db.
