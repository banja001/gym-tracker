import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TrainingService } from '../training.service';
import { WeeklyWorkoutStats } from '../model/weekly-workout-stats';

@Component({
  selector: 'xp-workout-stats',
  templateUrl: './workout-stats.component.html',
  styleUrls: ['./workout-stats.component.css']
})
export class WorkoutStatsComponent {
  statsForm: FormGroup;
  weeklyStats: WeeklyWorkoutStats[] = [];

  constructor(private fb: FormBuilder, private trainingService: TrainingService) {
    this.statsForm = this.fb.group({
      year: [new Date().getFullYear(), Validators.required],
      month: [new Date().getMonth() + 1, Validators.required] // JS months 0–11
    });
  }

  loadStats(): void {
    if (this.statsForm.valid) {
      const { year, month } = this.statsForm.value;

      this.trainingService.getWeeklyStats(year, month).subscribe({
        next: (data) => (this.weeklyStats = data)
      });
    } else {
      this.statsForm.markAllAsTouched();
    }
  }
}
