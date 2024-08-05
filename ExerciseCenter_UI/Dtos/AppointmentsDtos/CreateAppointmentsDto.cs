namespace ExerciseCenter_UI.Dtos.AppointmentsDtos
{
    public class CreateAppointmentsDto
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Time { get; set; }
    }
}
