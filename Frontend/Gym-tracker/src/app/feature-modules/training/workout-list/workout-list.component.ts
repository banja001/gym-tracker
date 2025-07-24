import { Component, OnInit } from '@angular/core';
import { TrainingService } from '../training.service';
import { Workout, WorkoutType } from '../model/workout.model';

@Component({
  selector: 'xp-workout-list',
  templateUrl: './workout-list.component.html',
  styleUrls: ['./workout-list.component.css']
})
export class WorkoutListComponent implements OnInit {
  workouts: Workout[] = [];
  displayedColumns: string[] = ['name', 'duration', 'caloriesBurned', 'intensityLevel', 'fatigueLevel', 'time', 'type','notes'];
  workoutTypes = WorkoutType;
  constructor(private trainingService: TrainingService) {}

  ngOnInit(): void {
    this.trainingService.getAllWorkouts().subscribe({
      next: (data) => {
        this.workouts = data;
      },
      error: (err) => {
        console.error('Error loading workouts', err);
      }
    });
  }
}
