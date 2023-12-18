using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static PersonModel ReadPerson()
        {
            PersonModel p1 = new PersonModel();
            Console.Write("Enter id: ");
            Console.Write("Enter id123: ");
            p1.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            p1.Pname = Console.ReadLine();
            Console.Write("Enter Gender: ");
            p1.Gender = Console.ReadLine();
            Console.Write("Enter Age: ");
            p1.Age = Convert.ToInt32(Console.ReadLine());
            return p1;
        }
        static void MainMenu()
        {
            PersonBO context = new PersonBO();
            List<PersonModel> people;
            PersonModel p1;
            int ch = 0,id;
            do
            {
                Console.Write("Menu\n1.Display All\n2.Add\n3.Edit\n4.Delete\n5.Search\n\n6.Exit\n");
                Console.Write("Enter Choice: ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                         people = context.GetAll();
                        foreach (PersonModel p in people)
                            Console.WriteLine($"{p.Id} {p.Pname} {p.Gender} {p.Age}");
                        break;
                    case 2:
                        p1 = ReadPerson();
                        context.AddPerson(p1);
                        break;
                    case 3:
                        Console.Write("Enter Person Id to edit: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new person details to edit");
                        people = context.GetAll();
                        p1 = ReadPerson();
                        for ( int i = 0; i < people.Count; i++)
                        {
                            if (people[i].Id == id)
                            {
                                people[i] = p1;
                                break;
                            }
                        }
                        break;
                    case 4:
                        Console.Write("Enter person id to delete: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        people = context.GetAll();
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (people[i].Id == id)
                            {
                                people.RemoveAt(i);
                                break;
                            }
                        }
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("invalid choice...");
                        break;
                }
            } while (ch != 6);
        }
        static void Main()
        {

            MainMenu();
        }
    }
}





