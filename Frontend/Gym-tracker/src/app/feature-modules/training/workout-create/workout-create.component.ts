import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { WorkoutType } from '../model/workout.model';
import { TrainingService } from '../training.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'xp-workout-create',
  templateUrl: './workout-create.component.html',
  styleUrls: ['./workout-create.component.css']
})
export class WorkoutCreateComponent {
  workoutForm: FormGroup;
  workoutTypes = [
  { value: WorkoutType.Cardio, label: 'Cardio' },
  { value: WorkoutType.Strength, label: 'Strength' },
  { value: WorkoutType.Flexibility, label: 'Flexibility' },
  { value: WorkoutType.Balance, label: 'Balance' },
  { value: WorkoutType.Mobility, label: 'Mobility' },
  { value: WorkoutType.Endurance, label: 'Endurance' },
  { value: WorkoutType.Other, label: 'Other' }
];

  constructor(
    private fb: FormBuilder,
    private trainingService: TrainingService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.workoutForm = this.fb.group({
      name: ['', Validators.required],
      duration: [0, [Validators.required, Validators.min(1)]],
      caloriesBurned: [0, [Validators.required, Validators.min(0)]],
      intensityLevel: [1, [Validators.required, Validators.min(1), Validators.max(10)]],
      fatigueLevel: [1, [Validators.required, Validators.min(1), Validators.max(10)]],
      notes: [''],
      date: new FormControl('', Validators.required),
      time: new FormControl('', Validators.required),
      type: [null, Validators.required]
    });
  }

  submit(): void {
    if (this.workoutForm.valid) {
      const workout = { ...this.workoutForm.value };

      const date: Date = workout.date;
      const time: string = workout.time;

      const [hours, minutes] = time.split(':').map(Number);
      date.setHours(hours, minutes);

      workout.time = date;
      delete workout.date;
      workout.id=0
      workout.userId=0;

      this.trainingService.createWorkout(workout).subscribe({
        next: () => {
          this.snackBar.open('Successfully created workout', 'Close', {
          duration: 3000, 
          panelClass: ['success-snackbar'],
          verticalPosition: 'bottom' 
          });
          this.router.navigate(['/']); 
        }
      });
    } else {
      this.workoutForm.markAllAsTouched();
    }
  }

}
