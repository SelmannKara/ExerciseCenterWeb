namespace ExerciseCenter_UI.Dtos.AppointmentsDtos
{
    public class UpdateAppointmentsDto
    {
        public int AppointmentID { get; set; }
        public bool Status { get; set; }     
        public string Time { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ServiceID { get; set; }
        public DateTime createdAt { get; set; }
    }
}
