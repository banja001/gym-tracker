import { NgModule } from "@angular/core";
import { WorkoutCreateComponent } from "./workout-create/workout-create.component";
import { CommonModule } from "@angular/common";
import { MaterialModule } from "src/app/infrastructure/material/material.module";
import { RouterModule } from "@angular/router";
import { MatCardModule } from "@angular/material/card";
import { ReactiveFormsModule } from "@angular/forms";
import { MatNativeDateModule, MatOptionModule } from "@angular/material/core";
import { WorkoutListComponent } from './workout-list/workout-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { WorkoutStatsComponent } from './workout-stats/workout-stats.component';

@NgModule({
  declarations: [
    WorkoutCreateComponent,
    WorkoutListComponent,
    WorkoutStatsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    MatCardModule,
    ReactiveFormsModule,
    MatOptionModule,
    MatNativeDateModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule 
  ],
  exports: [
    WorkoutCreateComponent
  ]
})
export class TrainingModule { }
