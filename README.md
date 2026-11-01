# 🏥 Hospital Management System

A web-based hospital management system that digitizes day-to-day hospital operations: patient registration, doctor scheduling, appointments, medical records, lab tests, and billing, all in one place. It replaces paper registers with a single system that reception staff, doctors, lab staff, and administrators can use.

---

## 🎯 What the System Does

- Registers patients once and keeps their full history in one record
- Lets reception book and manage doctor appointments without schedule clashes
- Gives doctors a clear view of their patients, appointments, and past visits
- Tracks lab tests from request to result
- Produces bills and keeps track of payments
- Gives administrators a view of hospital activity and revenue

---

## 👥 User Roles

| Role | Responsibilities |
|------|------------------|
| **Admin** | Manage users, departments, doctors, and view reports |
| **Patient** |  book appointments, Manage Medical Records and generate bills |
| **Doctor** | View appointments, record diagnosis and prescriptions, request lab tests |


---

## ✨ Functionality

### 1. Authentication & Access Control
- Secure login and logout for all staff
- Role-based access: each role only sees the screens and actions it needs
- Admin can create, update, and deactivate user accounts

### 2. Patient Management
- Register new patients with name, age, gender, blood group, contact number, address, and emergency contact
- Unique patient ID for every patient
- Search patients by name, ID, or phone number
- Edit patient information
- View a patient's complete history: visits, diagnoses, prescriptions, lab reports, and bills

### 3. Doctor & Department Management
- Add and manage departments (for example Cardiology, Neurology, Pediatrics)
- Add doctors with specialization, qualification, department, and consultation fee
- Set each doctor's available days and time slots
- View a doctor's schedule and patient list

### 4. Appointment Management
- Book an appointment by choosing a patient, department, doctor, date, and time slot
- Only free slots are shown, so double booking is prevented
- Reschedule or cancel appointments
- Appointment statuses: **Scheduled**, **Completed**, **Cancelled**, **No-show**
- Daily appointment list for each doctor and for reception

### 5. Consultation & Medical Records
- Doctor records symptoms, diagnosis, and notes for each visit
- Write prescriptions: medicine name, dosage, frequency, and duration
- Doctor can request lab tests during a consultation
- All records are linked to the patient and available for later visits

### 6. Laboratory Management
- Lab test catalog with test names and prices
- Test requests from doctors appear in the lab queue
- Lab staff record results and mark tests as **Pending**, **In Progress**, or **Completed**
- Completed results are visible to the doctor and attached to the patient record

### 7. Billing & Payments
- Automatic bill generation from consultation fee, lab tests, and other charges
- Record payment amount and method
- Payment status: **Unpaid**, **Partially Paid**, **Paid**
- Printable bill or receipt

### 8. Dashboard & Reports
- Dashboard with total patients, doctors, today's appointments, and pending lab tests
- Revenue report by day and month
- Appointments per doctor and per department
- Patient registration trends

---

## 🔄 Typical Workflow

```
Patient arrives → Receptionist registers patient (or finds existing record)
    → Books appointment with a doctor → Doctor consults and writes prescription
    → Doctor requests lab test (if needed) → Lab uploads result
    → Receptionist generates bill → Patient pays → Visit recorded in history
```

---

## 📁 Project Structure

```
Hospital-Management-System/
├── WebApplicationDocLab/        # Main web application
├── packages/                    # NuGet packages
└── WebApplicationDocLab.sln     # Visual Studio solution
```

---

## 🛠️ Tech Stack

- **Platform:** ASP.NET web application (Visual Studio solution)
- **Language:** C#
- **Data access:** Relational database, configured through the connection string

---

## 🚀 Getting Started

1. Clone the repository
   ```bash
   git clone https://github.com/AZIZ-2022/Hospital-Management-System.git
   ```
2. Open `WebApplicationDocLab.sln` in Visual Studio.
3. Restore NuGet packages (right-click the solution, then **Restore NuGet Packages**).
4. Update the database connection string in the project's configuration file.
5. Create the database (run the migrations or the provided SQL script).
6. Press **F5** to run the project.

---

## 🗺️ Roadmap

- [ ] Patient portal for online appointment booking
- [ ] Pharmacy and medicine inventory
- [ ] In-patient admission and bed management
- [ ] SMS and email appointment reminders
- [ ] PDF export for prescriptions and reports

---

## 👤 Author

**AZIZ-2022** — [GitHub](https://github.com/AZIZ-2022)
