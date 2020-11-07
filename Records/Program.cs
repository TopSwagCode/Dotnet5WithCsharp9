using System;

namespace Dotnet5WithCsharp9
{
    class Program
    {
        static void Main(string[] args)
        {

            var personA = new PersonClass("a", "b", 1);
            var personB = new PersonClass("a", "b", 1);

            Console.WriteLine($"Is PersonA == PersonB??? {personA == personB}");

            personA.Age++;

            Console.WriteLine(personA.Age);


            #region Records
            var alice1 = new PersonRecord("Alice", "Anderson", 33);

            var alice2 = new PersonRecord("Alice", "Anderson", 33);

            Console.WriteLine($"Is Alice1 == Alice2??? {alice1 == alice2}");

            var studentAlice = new StudentRecrod("Alice", "Anderson", 33);

            Console.WriteLine($"Is Alice1 == StudentAlice??? {alice1 == alice2}");

            var teacherAlice = new Teacher("Alice", "Anderson", 33, 1337);

            Console.WriteLine($"Is Alice1 == TeacherAlice??? {alice1 == teacherAlice}");
            #endregion

        }
    }

    #region OldWay
    public class PersonClass
    {
        public PersonClass(string firstname, string lastname, int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
    #endregion

    #region 1
    public record PersonRecord(string firstname, string lastname, int age);
    #endregion



    #region 2
    public record StudentRecrod
    {
        public string firstname { get; }
        public string lastname { get; }
        public int age { get; set; }

        public StudentRecrod(string firstname, string lastname, int age) => (firstname, lastname, age) = (firstname, lastname, age);
    }
    #endregion



    #region 3
    public record Teacher(string firstname, string lastname, int age, int wage) : PersonRecord(firstname,lastname,age);
    #endregion



    #region 4
    public sealed record Pet(string name);

    //public record Dog(string name):Pet(name);
    #endregion

}
