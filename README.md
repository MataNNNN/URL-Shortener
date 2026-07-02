# 📌 URL Shortener

---

## 🚀 Features

- Saves all the URLs inside of a DB 
- A nicely designed UI to see all of the urls and create new ones
- Unit tests for Base62 encoding


---

## 🏗️ Tech Stack

- ASP.NET Core
- Razor Pages
- C#
- Base62 encoding

---

## ⚙️ Setup

```bash
# Clone the repository
git clone <repo-url>

# Go into project folder
cd <project-folder>

# Restore dependencies
dotnet restore
```

## 📌 API Endpoints

- GET /api/getAll - returns all of the short urls with their original url and short code
- POST /api/shorten - the endpoint to which you send the original url
- GET /{shortcode} - the shortlink itslef

