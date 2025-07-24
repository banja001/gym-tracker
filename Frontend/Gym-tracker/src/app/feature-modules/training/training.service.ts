import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { User } from "src/app/infrastructure/auth/model/user.model";
import { environment } from "src/env/environment";
import { Workout } from "./model/workout.model";
import { WeeklyWorkoutStats } from "./model/weekly-workout-stats";

@Injectable({
  providedIn: 'root'
})
export class TrainingService {
  user$ = new BehaviorSubject<User>({username: "", id: 0});

  constructor(private http: HttpClient,
    private router: Router) { }

  createWorkout(workout: Workout): Observable<any> {
    return this.http.post(`${environment.apiHost}workout`, workout);
  }
  getAllWorkouts(): Observable<Workout[] > {
    return this.http.get<Workout[]>(`${environment.apiHost}workout/byUserId`);
  }
  getWeeklyStats(year: number, month: number): Observable<WeeklyWorkoutStats[]> {
  return this.http.get<WeeklyWorkoutStats[]>(`${environment.apiHost}workout-statistics/weekly?year=${year}&month=${month}`);
  }

}
