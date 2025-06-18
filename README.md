# ServEase 🛠️📅  
A Smart Desktop Appointment System for Service Facilities

**ServEase** is a C# Windows Forms application that streamlines service appointment booking, messaging, and analytics for both clients and service providers. Designed with simplicity and productivity in mind, ServEase helps manage bookings, enable real-time communication, and visualize service data in a smart and intuitive way.

---

## 🧩 Key Features

### 👤 For Clients:
- Browse service facilities by category (Health, Beauty, Education, Repair, etc.)
- View facility details: hours, ratings, services, tags, and pricing
- Book, cancel, and manage appointments
- Chat directly with service providers
- Receive real-time in-app notifications

### 🏢 For Facilities:
- Accept or decline appointments
- Manage service offerings and time slots
- Communicate with clients via in-app messenger
- Access visual analytics on bookings and customer behavior

### 🧠 Admin Capabilities:
- Approve or suspend facility accounts
- Monitor appointment activity and feedback
- Review client-facility interactions

---

## 📊 Analytics Dashboard
Built using **OxyPlot**, the system provides:
- 📈 Most popular time slots
- 🔧 Most booked services
- 📅 Appointment counts by status (Pending, Confirmed, Completed, No Show, Cancelled)
- 📊 Client or facility growth over time

---

## 🔔 Notification System
- Custom toast/snackbar-style UI
- Instant alerts for:
  - Appointment booking & changes
  - Messaging events
  - Admin actions

---

## 💬 Real-Time Messenger
- Client ↔ Facility chat window
- Distinguishes message sender roles
- Stores message history and timestamps
- Supports notification triggers upon send

---

## 📅 Calendar Integration
- Google Calendar API support (via `Google.Apis.Calendar.v3`)
- Selectable dates and time slots with exception days
- Facility schedules visualized using a grid layout

---

## 🛠 Tech Stack

| Layer         | Technology                         |
|---------------|-------------------------------------|
| Language      | C# (.NET Framework)                 |
| UI Framework  | Windows Forms (WinForms)            |
| Database      | Microsoft Access (`.accdb`)         |
| Charting      | OxyPlot (`OxyPlot.WindowsForms`)    |
| Calendar API  | Google Calendar (OAuth-based)       |
| Notifications | Custom WinForms UI elements         |

---

## 🗂 Database Structure (Highlights)
- `Service Facilities`: Facility profiles and categories  
- `Facility Services`: Services offered and pricing  
- `Appointments`: Booking information and statuses  
- `Messenger`: Client ↔ Facility messages  
- `Notifications`: In-app system alerts  

---

## 📦 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ServEase.git
