using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }

    public class PhoneData
    {
        public string Phone { get; set; }
    }

    public static class GenerateData
    {

        public static PersonData GetPersonData()
        {
            var person = Builder<PersonData>.CreateNew()
                .With(c => c.FirstName = Faker.Name.First())
                    .With(c => c.LastName = Faker.Name.Last())
                    .With(c => c.TelephoneNumber = Faker.Phone.Number())
                    .With(c => c.EmailAddress = Faker.Internet.Email())
                .Build();

            return person;
        }
    }
}