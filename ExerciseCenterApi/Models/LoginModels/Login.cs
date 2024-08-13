using System.ComponentModel.DataAnnotations;

namespace ExerciseCenter_API.Models.LoginModels
{
    public class Login
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
