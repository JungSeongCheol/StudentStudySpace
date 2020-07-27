using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmApp.Helpers;

namespace WpfMvvmApp.Models
{
    public class Person
    {
        public string FirstName { get; set; }   // Table상 필드
        public string LastName { get; set; }    // Table상 필드

        string email;   // Table 상 필드
        public string Email
        {
            get => email;
            set
            {
                if (Commons.IsValidEmail(value))
                    email = value; //get set 바로 안쓰는이유 : get을 체크한다음 넣기위해(Email 형식을 set에서 체크한다.)
                else
                    throw new Exception("Invalid Email");
            }
        }

        DateTime date; // Table 상 필드
        public DateTime Date
        {
            get { return date; }
            set 
            {
                var result = Commons.CalcAge(value); //나이
                if (result > 135 || result < 0)
                    throw new Exception("Invalid date");
                else
                    date = value;
            }
        }

        public Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }

        public bool IsBirthDay // 추가 속성
        {
            get
            {
                return DateTime.Now.Month == Date.Month &&
                    DateTime.Now.Day == Date.Day;
            }
        }

        public bool IsAdult // 추가 속성
        {
            get
            {
                return Commons.CalcAge(date) > 18;
            }
        }

        public string ChnZodiac
        {
            get
            {
                return Commons.GetChineseZodiac(Date);
            }
        }

        public string Zodiac
        {
            get
            {
                return Commons.GetZodiac(Date);
            }
        } 
    }

}
