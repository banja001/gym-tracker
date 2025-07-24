# 🏋️ Gym-tracker

**Gym-tracker** is a web application for tracking workouts and user progress.

## 📦 Technologies

- ASP.NET Core (.NET 8)
- Entity Framework Core with PostgreSQL
- PostgreSQL managed via pgAdmin
- AutoMapper, FluentValidation
- Modular architecture (e.g., `Members`, `Training`)
- Angular (frontend framework)
- Angular Material for UI components and theming


## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/banja001/gym-tracker.git
cd gym-tracker
```
### 2. Apply database migrations

#### TrainingContext

```powershell
Add-Migration -Name Init -Context TrainingContext -Project Training.Infrastructure -StartupProject Gym-tracker
Update-Database -Context TrainingContext -Project Training.Infrastructure -StartupProject Gym-tracker
```
#### MembersContext

```powershell
Add-Migration -Name Init -Context MembersContext -Project Members.Infrastructure -StartupProject Gym-tracker
Update-Database -Context MembersContext -Project Members.Infrastructure -StartupProject Gym-tracker
```
