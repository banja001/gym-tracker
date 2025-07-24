export interface Workout {
  id: number;
  name: string;
  duration: number;
  caloriesBurned: number;
  intensityLevel: number;
  fatigueLevel: number;
  notes: string;
  time: Date; 
  type: WorkoutType;
  userId: number;
}

export enum WorkoutType {
  Cardio = 0,
  Strength = 1,
  Flexibility = 2,
  Balance = 3,
  Mobility = 4,
  Endurance = 5,
  Other = 6
}
