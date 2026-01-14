# מערכת ניהול פניות (Ticket Management System)

## סקירה כללית

מערכת לניהול פניות המאפשרת יצירה, צפייה וסגירה של פניות.

- **Backend**: API מבוסס .NET 8
- **Frontend**: אפליקציית Angular 21

## דרישות מערכת

- .NET 8.0 SDK
- Node.js (גרסה 18+)
- npm

## הוראות התקנה והפעלה

### Backend

```bash
cd backend/TicketApi/TicketApi
dotnet restore
dotnet run --launch-profile https```

ה-API זמין ב:
- HTTP: `http://localhost:5163`
- HTTPS: `https://localhost:7203`
- Swagger: `https://localhost:7203/swagger`

### Frontend

```bash
cd frontend/ticket-ui
npm install
ng serve
```

האפליקציה זמינה ב: `http://localhost:4200`

**הערה**: ודא שה-Backend רץ לפני הפעלת ה-Frontend.

## API Endpoints

- `GET /tickets/GetAllTickets` - קבלת כל הכרטיסים
- `POST /tickets/CreateTicket` - יצירת כרטיס חדש
- `POST /tickets/CloseTicket` - סגירת כרטיס

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
