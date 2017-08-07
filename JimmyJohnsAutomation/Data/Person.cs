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

    public class GenerateData
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
                    .With(c => c.Password = Faker.Beer.Name() + "1")
                .Build();

            return person;
        }


        public static IList<PersonData> GetListOfPersonData()
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

            var person = Builder<PersonData>.CreateListOfSize(200)
                .All()
                    .With(c => c.FirstName = Faker.Name.First())
                    .With(c => c.LastName = Faker.Name.Last())
                    .With(c => c.MiddleName = Faker.Name.FullName())
                    .With(c => c.TelephoneNumber = phone)
                    .With(c => c.EmailAddress = Faker.Internet.Email())
                    .With(c => c.Password = Faker.Beer.Name())
                .TheLast(50)
                    .With(c => c.EmailAddress = "specialemail@email.com")
                .Build();            

            return person;
        }


        public static IList<PersonData> GetListOfPersistedPersonData()
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
            
            //need to setup Datalayer for persisting data to a datalayer
            //BuilderSetup.SetCreatePersistenceMethod<IList<PersonData>>(
                //personRepository.CreateAll);

            var person = Builder<PersonData>.CreateListOfSize(200)
                .TheFirst(150)
                    .With(c => c.FirstName = Faker.Name.First())
                    .With(c => c.LastName = Faker.Name.Last())
                    .With(c => c.TelephoneNumber = phone)
                    .With(c => c.EmailAddress = Faker.Internet.Email())
                    .With(c => c.Password = Faker.Beer.Name())
                 .TheLast(50)
                    .With(c => c.EmailAddress = "specialemail@email.com")
                    //Persist the data object.

                    .Persist();

            return person;
        }

    }
}