using WebApplication1.model;

namespace WebApplication1.repository.implementation
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        SampleContextFactory contextFactory = new SampleContextFactory();
        public Person? DeleteById(int id)
        {
            using(var db = contextFactory.CreateDbContext(null))
            {
                var person = FindById(id);
                if (person != null)
                {
                    //db.Persons.Remove(person);
                    person.Status = Status.DELETED;
                    db.Update(person);
                    db.SaveChanges();
                }
                return person;
            }
        }

        public List<Person> FindAll()
        {
            using (var db = contextFactory.CreateDbContext(null))
            {
                return db.Persons.Where(x => x.Status == Status.ACTIVE).ToList();
            }
        }

        public Person FindById(int id)
        {
            using (var db = contextFactory.CreateDbContext(null))
            {
                var person = db.Persons.FirstOrDefault(x => x.Id == id && x.Status == Status.ACTIVE);
                return person;
            }
        }

        public Person Save(Person entity)
        {
            using (var db = contextFactory.CreateDbContext(null))
            {
                db.Persons.Add(entity);
                db.SaveChanges();
                return entity;
            }
        }

        public Person? Update(int id, Person person)
        {
            using (var db = contextFactory.CreateDbContext(null))
            {
                var oldPerson = FindById(id);
                if (person != null)
                {
                    oldPerson.FullName = person.FullName;
                    oldPerson.BirthDate = person.BirthDate;
                    oldPerson.PhoneNumber = person.PhoneNumber;
                    db.Update(oldPerson);
                    db.SaveChanges();
                }
                return oldPerson;
            }
        }
    }
}
