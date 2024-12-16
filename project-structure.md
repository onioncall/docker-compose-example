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
