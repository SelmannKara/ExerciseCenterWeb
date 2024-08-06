namespace ExerciseCenter_API.Dtos.AppointmentsDtos
{
    public class ResultAppointmentsDto
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime  CreatedAt { get; set; }
        public bool Status { get; set; }    
        public string Time { get; set; }    
    }
}
