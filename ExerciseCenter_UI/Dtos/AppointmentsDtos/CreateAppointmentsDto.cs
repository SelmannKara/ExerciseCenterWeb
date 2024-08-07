using System.ComponentModel.DataAnnotations;

namespace ExerciseCenter_UI.Dtos.AppointmentsDtos
{
    public class CreateAppointmentsDto
    {
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Time { get; set; }
    }
}
