import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/feature-modules/layout/home/home.component';
import { LoginComponent } from '../auth/login/login.component';
import { AuthGuard } from '../auth/auth.guard';
import { RegistrationComponent } from '../auth/registration/registration.component';
import { WorkoutCreateComponent } from 'src/app/feature-modules/training/workout-create/workout-create.component';
import { WorkoutListComponent } from 'src/app/feature-modules/training/workout-list/workout-list.component';
import { WorkoutStatsComponent } from 'src/app/feature-modules/training/workout-stats/workout-stats.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegistrationComponent},
  {path: 'workout-create', component: WorkoutCreateComponent},
  {path: 'workouts', component: WorkoutListComponent},
  {path: 'workout-stats', component: WorkoutStatsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
