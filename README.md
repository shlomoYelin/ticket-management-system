# מערכת ניהול פניות (Ticket Management System)

## סקירה כללית

מערכת לניהול פניות המאפשרת יצירה, צפייה וסגירה של פניות.

- **Backend**: API מבוסס .NET 8
- **Frontend**: אפליקציית Angular 21

## דרישות מערכת

- .NET 8.0 SDK
- Node.js (גרסה 18+)
- npm
- Docker (אופציונלי - להרצה עם Docker)

## הוראות התקנה והפעלה

### הרצה עם Docker (Backend)

להרצת ה-Backend עם Docker:

```bash
cd backend/TicketApi
docker build -t ticket-api .
docker run -d -p 7203:8080 --name ticket-api-container ticket-api
```

**פקודות שימושיות:**
- צפייה בלוגים: `docker logs ticket-api-container`
- עצירת הקונטיינר: `docker stop ticket-api-container`
- הפעלת הקונטיינר: `docker start ticket-api-container`
- הסרת הקונטיינר: `docker rm -f ticket-api-container`

**הערה:** בעת הרצה עם Docker, ה-API זמין ב-`http://localhost:7203` (HTTP בלבד).

### הרצה רגילה (ללא Docker)

#### Backend

```bash
cd backend/TicketApi/TicketApi
dotnet restore
dotnet run --launch-profile https
```
ה-API זמין ב:
- HTTP: `http://localhost:7203`
- Swagger: `http://localhost:7203/swagger`

#### Frontend

```bash
cd frontend/ticket-ui
npm install
ng serve
```

האפליקציה זמינה ב: `http://localhost:4200`


## API Endpoints

- `GET /tickets/GetAllTickets` - שליפת כל הפניות
- `POST /tickets/CreateTicket` - יצירת פנייה חדשה
- `POST /tickets/CloseTicket` - סגירת פנייה

לצפייה בתיעוד מלא: `https://localhost:7203/swagger`

## מבנה הפרויקט

```
ticket-management-system/
├── backend/
│   └── TicketApi/
│       ├── TicketApi/                    # API Layer
│       ├── TicketManagement.Domain/       # Domain Layer
│       ├── TicketManagement.Application/   # Application Layer
│       └── TicketManagement.Infrastructure/ # Infrastructure Layer
└── frontend/
    └── ticket-ui/                         # Angular Application
```

הפרויקט בנוי על פי **Clean Architecture** עם הפרדה לשכבות: Domain, Application, Infrastructure ו-API.

## טכנולוגיות

**Backend**: .NET 8, Entity Framework Core, InMemory Database, Swagger

**Frontend**: Angular 21, Angular Material, TypeScript, RxJS
