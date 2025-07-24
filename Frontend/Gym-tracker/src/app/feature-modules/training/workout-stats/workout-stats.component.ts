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
  months = [
  { value: 1, label: 'January' },
  { value: 2, label: 'February' },
  { value: 3, label: 'March' },
  { value: 4, label: 'April' },
  { value: 5, label: 'May' },
  { value: 6, label: 'June' },
  { value: 7, label: 'July' },
  { value: 8, label: 'August' },
  { value: 9, label: 'September' },
  { value: 10, label: 'October' },
  { value: 11, label: 'November' },
  { value: 12, label: 'December' }
];


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
