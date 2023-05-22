using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class Person
    {
        public string IdOstan { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Tell { get; set; }
        public string Adress { get; set; }
        public string NameOstan { get; set; }
    }

    public class Ostan
    {
        public string Id { get; set; }
        public string FullName { get; set; }
    }


    public class ApiController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOstan()
        {
            List<Ostan> ostanList = new List<Ostan>();

            Ostan ostan1 = new Ostan()
            {
                Id = "01",
                FullName = "آذربایجان شرقی"
            };
            ostanList.Add(ostan1);

            Ostan ostan2 = new Ostan()
            {
                Id = "02",
                FullName = "آذربایجان غربی"
            };
            ostanList.Add(ostan2);

            Ostan ostan3 = new Ostan()
            {
                Id = "03",
                FullName = "شیراز"
            };
            ostanList.Add(ostan3);


            Ostan ostan4 = new Ostan()
            {
                Id = "04",
                FullName = "بوشهر"
            };
            ostanList.Add(ostan4);



            return Ok(ostanList);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListPerson()
        {
            List<Person> personList = new List<Person>();
            Person person1 = new Person()
            {
                Id = "1",
                FullName = "John Doe",
                Tell = "1234567890",
                Adress = "123 Main St",
                IdOstan = "04",
                NameOstan = "بوشهر"
            };
            personList.Add(person1);

            Person person2 = new Person()
            {
                Id = "2",
                FullName = "Jane Smith",
                Tell = "9876543210",
                Adress = "456 Elm St",
                IdOstan = "01",
                NameOstan = "آذربایجان شرقی"
            };
            personList.Add(person2);

            Person person3 = new Person()
            {
                Id = "3",
                FullName = "Alex Johnson",
                Tell = "5551234567",
                Adress = "789 Oak St",
                IdOstan = "01",
                NameOstan = "آذربایجان شرقی"
            };
            personList.Add(person3);
 
            return Ok(personList);
        }
    }
}
