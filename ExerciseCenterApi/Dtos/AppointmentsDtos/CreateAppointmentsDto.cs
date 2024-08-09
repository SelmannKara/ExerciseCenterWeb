using ExerciseCenter_API.Dtos.ServicesDtos;

namespace ExerciseCenter_API.Dtos.AppointmentsDtos
{
    public class CreateAppointmentsDto
    {
        public string Time { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AppointmentDate { get; set; }    
        public int ServiceID { get; set; }
      
    }
}
