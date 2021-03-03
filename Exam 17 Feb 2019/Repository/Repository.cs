namespace Repository
{
    using System.Collections.Generic;

    public class Repository
    {
        private Dictionary<int, Person> personData;
        private int id;
        public Repository()
        {
            personData = new Dictionary<int, Person>();
            id = 0;
        }


        public void Add(Person person)
        {
            personData.Add(id, person);

            id++;
        }

        public Person Get(int id)
        {
            return personData[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (personData.ContainsKey(id))
            {
                personData[id] = newPerson;
                return true;
            }

            return false;

        }
        public bool Delete(int id)
        {
            if (personData.ContainsKey(id))
            {
                personData.Remove(id);
                return true;
            }

            return false;

        }
        public int Count
        {
            get { return personData.Count; }
        }

    }
}
