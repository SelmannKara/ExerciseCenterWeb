﻿namespace ExerciseCenter_API.Dtos.LoginDtos
{
    public class CreateLoginDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}