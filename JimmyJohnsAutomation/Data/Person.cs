using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Dsl;

namespace JimmyJohnsAutomation.Data
{
    public class PersonData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }

        public string Password { get; set; }

    }

    public class PhoneData
    {
        public string Phone { get; set; }
    }

    public static class GenerateData
    {

        public static PersonData GetPersonData()
        {
            string phone = Phone.Number();
            if (phone.Substring(0, 2).Equals("1-"))
            {
                phone = phone.Substring(2, phone.Length - 2);
            }
            if (phone.Contains("x"))
            {
                int index = phone.IndexOf("x");
                phone = phone.Remove(index - 1);
            }
            phone = phone.Replace(".", "");
            phone = phone.Replace("-", "");
            phone = phone.Replace("(", "");
            phone = phone.Replace(")", "");
            phone = phone.Replace(" ", "");

            //NBuilder stuff

            var person = Builder<PersonData>.CreateNew()
                    .With(c => c.FirstName = Faker.Name.First())
                    .With(c => c.LastName = Faker.Name.Last())
                    .With(c => c.TelephoneNumber = phone)
                    .With(c => c.EmailAddress = Faker.Internet.Email())
                    .With(c => c.Password = Faker.Beer.Name() + Faker.RandomNumber.Next(0000,9999))
                .Build();

            return person;
        }
    }
}