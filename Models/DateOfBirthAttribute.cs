using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Backend_Dev_Eindwerk.Models
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public DateOfBirthAttribute()
        {
            
        }

        public string GetErrorMessage() => $"Invalid date of birth";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Dictionary<string,int> Months = new Dictionary<string, int>()
            {
                {"1",31},
                {"2",28},
                {"3",31},
                {"4",30},
                {"5",31},
                {"6",30},
                {"7",31},
                {"8",31},
                {"9",30},
                {"10",31},
                {"11",30},
                {"12",31},
            };
            var dateOfBirth = (Player)validationContext.ObjectInstance;
            string dateOfBirthStr = Convert.ToString(dateOfBirth.DateOfBirth);
            string[] dateParts = dateOfBirthStr.Split("/");

            if(Months.ContainsKey(dateParts[0]))
            {
                int days = Months[dateParts[0]];
                if(Convert.ToInt32(dateParts[1]) <= days)
                {
                    int currentYear = DateTime.Now.Year;
                    int age = currentYear - Convert.ToInt32(dateParts[2]);
                    if(age >= 17 && age < 100 )
                    {
                        return ValidationResult.Success;
                    }
                    else if(age < 17)
                    {
                        return new ValidationResult("This player is too young to be on a team");
                    }
                }
                else
                {
                    return new ValidationResult("Something is wrong about the day of birth");
                }
            }
            else
            {

                return new ValidationResult("Something is wrong about the month of birth");
            }

            return ValidationResult.Success;

        }
    }
}
