namespace ExerciseCenter_API.Dtos.AppointmentsDtos
{
    public class UpdateAppointmentsDto
    {
        public bool Status { get; set; }
        public string Time { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AppointmentDate { get; set; }
        public int ServiceID { get; set; }
    }
}
