﻿namespace EngineeringProjectApp.Model
{
    public class ResultModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string Level { get; set; }
        public int Returning { get; set; }
        public int AmountOfButterflies { get; set; }
        public int AmountOfBirds { get; set; }
        public string Time { get; set; }
        


        public override string ToString()
        {
            return FirstName+" "+LastName+" "+ Date + " " + Level + " " + Returning + " " + AmountOfButterflies + " " + AmountOfBirds + " " + Time;
        }
    }
}
