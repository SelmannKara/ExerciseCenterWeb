﻿namespace ExerciseCenter_API.Models.AppointmentsModels
{
    public class Appointments
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}