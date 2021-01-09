using DatabaseExtended.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseExtended
{
    public class PersonDataBase
    {
        private List<Person> database;

        public PersonDataBase()
        {
            this.Database = new List<Person>();
        }

        public List<Person> Database
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }

        public void Add(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.UserName))
            {
                throw new ArgumentNullException("Invalid Username!");
            }

            if (person.Id < 0)
            {
                throw new ArgumentOutOfRangeException("Id should be non - negative!");
            }

            if (this.Database.Any(x => x.UserName == person.UserName))
            {
                throw new InvalidOperationException("Username already exist!");
            }

            if (this.Database.Any(x => x.Id == person.Id))
            {
                throw new InvalidOperationException("Id already exist!");
            }

            this.Database.Add(person);
        }

        public void RemoveById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Id!");
            }

            if (!this.Database.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("NonExistent Id!");
            }

            this.Database.RemoveAll(x => x.Id == id);
        }

        public void RemoveByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Invalid Username!");
            }

            if (!this.Database.Any(x => x.UserName == userName))
            {
                throw new InvalidOperationException("NonExistent Username!");
            }

            this.Database.RemoveAll(x => x.UserName == userName);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Id!");
            }

            if (!this.Database.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("NonExistent Id!");
            }

            Person currentPerson = this.Database.First(x => x.Id == id);

            return currentPerson;
        }

        public Person findByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Invalid Username!");
            }

            if (!this.Database.Any(x => x.UserName == userName))
            {
                throw new InvalidOperationException("NonExistent Username!");
            }

            Person currentPerson = this.Database.First(x => x.UserName == userName);

            return currentPerson;
        }
    }
}
