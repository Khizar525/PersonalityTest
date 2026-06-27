# Personality Test — ASP.NET Core Web Application

> Cloud Computing Lab | Semester 6 | Spring 2026

## Project Overview

A cloud-native web application that analyzes personality based on the first image a user sees. Built with ASP.NET Core 9.0, this application demonstrates modern web development practices, containerization, and deployment to cloud platforms using CI/CD pipelines.

## Academic Context

This project was developed as part of the Cloud Computing Lab course during the sixth semester. The primary objective was to apply cloud computing concepts including source control management, continuous deployment, and cloud infrastructure setup in a practical web application.

## Problem Statement

Understanding personality traits is valuable for personal development, team building, and self-awareness. Traditional personality assessment methods can be time-consuming and require professional guidance.

This project addresses the need for:
- A quick, engaging way to explore personality traits
- An interactive web-based personality assessment tool
- Demonstration of cloud-native application development
- Implementation of CI/CD best practices for web applications

## Features Implemented

### Core Application Features
- **Personality Analysis**: Web-based personality test based on image selection
- **6 Unique Images**: Mountain, Ocean, Forest, Desert, Stars, Rainbow
- **Personality Results**: Detailed personality type with traits and descriptions
- **Responsive Design**: Mobile-friendly interface using Bootstrap 5
- **Interactive UI**: Smooth hover effects and card animations

### Cloud & DevOps Features
- **Docker Containerization**: Consistent development and production environments
- **GitHub Actions CI/CD**: Automated build, test, and deployment
- **Azure App Service**: Cloud deployment with continuous deployment
- **Source Control**: Git workflow with branching and version management
- **Static Asset Management**: Optimized CSS and JavaScript bundling

## Technology Stack

| Component | Technology |
|-----------|------------|
| Backend | ASP.NET Core 9.0 |
| Frontend | Razor Views, Bootstrap 5, CSS3 |
| Language | C# 12 |
| IDE | Visual Studio 2022 |
| Containerization | Docker |
| CI/CD | GitHub Actions |
| Cloud Platform | Azure App Service |
| Version Control | Git, GitHub |

## Project Structure

```
PersonalityTest/
├── README.md                          # This file
├── .gitignore                          # Git ignore rules
├── .github/                           # GitHub workflows
│   └── workflows/
│       └── ci-cd.yml                  # CI/CD pipeline
├── Dockerfile                         # Docker image definition
├── docker-compose.yml                 # Docker compose for local dev
├── Program.cs                         # Application entry point
├── PersonalityTest.csproj             # Project file
├── appsettings.json                   # Application configuration
├── appsettings.Development.json       # Development configuration
├── Controllers/                       # MVC Controllers
│   └── HomeController.cs             # Main controller with personality logic
├── Models/                            # Data Models
│   ├── PersonalityModel.cs           # Personality image and result models
│   └── ErrorViewModel.cs            # Error model
├── Views/                             # Razor Views
│   ├── Home/
│   │   ├── Index.cshtml              # Main test page
│   │   ├── Analyze.cshtml            # Results page
│   │   └── Privacy.cshtml            # Privacy page
│   └── Shared/                       # Shared layouts
├── wwwroot/                           # Static Files
│   ├── css/
│   │   └── site.css                  # Custom styles
│   ├── js/
│   │   └── site.js                   # Custom JavaScript
│   └── images/                       # SVG images for test
│       ├── mountain.svg
│       ├── ocean.svg
│       ├── forest.svg
│       ├── desert.svg
│       ├── stars.svg
│       └── rainbow.svg
├── docs/                              # Documentation
│   ├── architecture.md               # System architecture
│   └── deployment.md                 # Deployment guide
└── Properties/
    └── launchSettings.json           # Launch profiles
```

## How to Run

### Prerequisites
- .NET 9.0 SDK or later
- Docker (optional, for containerized development)
- Git (for version control)

### Local Development

1. **Clone the repository**
   ```bash
   git clone https://github.com/Khizar525/PersonalityTest.git
   cd PersonalityTest
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access the application**
   - Local: `https://localhost:5001` or `http://localhost:5000`

### Docker Development

1. **Build and run with Docker Compose**
   ```bash
   docker-compose up --build
   ```

2. **Access the application**
   - Docker: `https://localhost:5001` or `http://localhost:5000`

### Cloud Deployment

1. **Push to GitHub**
   ```bash
   git add .
   git commit -m "Update application"
   git push origin main
   ```

2. **Automatic Deployment**
   - Azure App Service automatically deploys from GitHub main branch
   - CI/CD pipeline builds and tests on every push
   - Deployment status visible in GitHub Actions tab

## Key Concepts Learned

### Cloud Computing
- **CI/CD Pipelines**: Automated build, test, and deployment processes
- **Containerization**: Using Docker for consistent environments across development and production
- **Cloud Deployment**: Deploying web applications to Azure App Service
- **Infrastructure as Code**: Declarative configuration for cloud resources

### Web Development
- **ASP.NET Core MVC**: Model-View-Controller architecture pattern
- **Razor Views**: Server-side HTML rendering with C# syntax
- **Responsive Design**: Mobile-first design using Bootstrap 5
- **Static Asset Management**: CSS and JavaScript optimization

### DevOps Practices
- **Version Control**: Git workflow with feature branches and pull requests
- **Continuous Integration**: Automated testing on every commit
- **Continuous Deployment**: Automatic deployment to cloud on merge to main
- **Monitoring**: Application logging and error tracking

### Software Architecture
- **MVC Pattern**: Separation of concerns in web applications
- **RESTful Design**: Stateless HTTP communication
- **Error Handling**: Graceful error management and user feedback
- **Security Best Practices**: Input validation and HTTPS enforcement

## Future Improvements

### Short-term Enhancements
- [ ] Add more personality categories and questions
- [ ] Implement user authentication and result saving
- [ ] Add social sharing functionality
- [ ] Create mobile-responsive design improvements
- [ ] Add unit tests for personality analysis logic

### Medium-term Features
- [ ] Implement Azure SQL Database for result storage
- [ ] Add API endpoints for third-party integration
- [ ] Create admin panel for managing test content
- [ ] Add analytics dashboard for usage tracking
- [ ] Implement multi-language support

### Long-term Vision
- [ ] Add machine learning for advanced personality analysis
- [ ] Implement real-time collaboration features
- [ ] Create a React/Blazor frontend
- [ ] Add integration with social media platforms
- [ ] Implement advanced analytics and reporting

## Course Information

**Course**: Cloud Computing Lab  
**Semester**: 6  
**Institution**: Bahria University Karachi  
**Academic Year**: Spring 2026

## Author

**M. Khizar Akram**  
BSE-6(B)  
Enrollment: 02-131232-064

## License

This project was developed for academic purposes as part of the Cloud Computing Lab course. It is intended for educational use and learning demonstration.

---

**Note**: This project demonstrates cloud computing concepts and is designed to showcase practical application of course material. It represents a sixth-semester learning experience in cloud-native web application development.
