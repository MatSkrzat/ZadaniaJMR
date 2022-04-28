using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1.DemoSource;
using Zadanie1.DemoTarget;

namespace ZadaniaTests
{
    [TestClass]
    public class Zadanie1Test
    {
        [TestMethod]
        public void Flatten_checkIfArrayIsEmpty()
        {
            var mockPeople = new List<Person>();
            var flattenCollection = ToDo.Flatten(mockPeople).ToList();
            Assert.AreEqual(flattenCollection.Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Flatten_checkIfArrayIsNull()
        {
            List<Person> mockPeople = null;
            var flattenCollection = ToDo.Flatten(mockPeople).ToList();
        }

        [TestMethod]
        public void Flatten_checkIfCorrectOutputCount()
        {
            List<Person> mockPeople = new List<Person>()
            {
                new Person()
                {
                    Id = "1",
                    Name = "Adam",
                    Emails = new List<EmailAddress>()
                    {
                        new EmailAddress()
                        {
                            Email = "adam@one.pl",
                            EmailType = "work"
                        },
                        new EmailAddress()
                        {
                            Email = "adam@two.pl",
                            EmailType = "home"
                        },
                    }
                },
                new Person()
                {
                    Id = "2a",
                    Name = "Tomek3",
                    Emails = new List<EmailAddress>()
                    {
                        new EmailAddress()
                        {
                            Email = "tomek@one.pl",
                            EmailType = "work"
                        },
                        new EmailAddress()
                        {
                            Email = "tomek@two.pl",
                            EmailType = "home"
                        },
                    }
                },
            };
            var flattenCollection = ToDo.Flatten(mockPeople).ToList();

            var expected = new List<PersonWithEmail>() {
                new PersonWithEmail()
                {
                    SanitizedNameWithId = "Adam1",
                    FormattedEmail = "adam@one.plwork"
                },
                new PersonWithEmail()
                {
                    SanitizedNameWithId = "Adam1",
                    FormattedEmail = "adam@two.plhome"
                },
                new PersonWithEmail()
                {
                    SanitizedNameWithId = "Tomek2",
                    FormattedEmail = "tomek@one.plwork"
                },
                new PersonWithEmail()
                {
                    SanitizedNameWithId = "Tomek2",
                    FormattedEmail = "tomek@two.plhome"
                }
            };
            Assert.AreEqual(flattenCollection.Count(), expected.Count());
        }
    }
}
