using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services
{
    public interface IPersonServices
    {

        Person Create(Person person);
        Person FindById (long id);
        Person Update (Person person);
        List<Person> FindAll();

        void Delete (long id);
    }
}
