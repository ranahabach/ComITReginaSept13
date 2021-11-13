using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Simple.MusicStore.Tools.Extensions;

namespace Simple.MusicStore.Tools.Extensions
{
    public static class StudentExtensions
    {
        public static string PrettyPrint(this Student student, Expression<Func<IEntity, IEntity, bool>> comparisonFunc = null)
        {
            return $"Student [ID:{student.Id}, Name:{student.Name}]";
        }
    }
}

namespace Simple.MusicStore.Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleList();
            Console.WriteLine("Hello World!");
        }

        static bool StudentComparison(IEntity first, IEntity second)
        {
            return first.Id == second.Id && 
                   ((Student)first).Name == ((Student)second).Name;
        }

        static void SampleList()
        {
            var carlos = new Student() { Id = 1, Name = "Carlos" };
            var carlos1 = new Student() { Id = 1, Name = "Carlos" };
            var carlos2 = carlos;

            Console.WriteLine(carlos.PrettyPrint());

            // var i = 1;
            //  =>
            var listOfStudents1 = new List<Student>();
            var listOfStudents = new MyList<Student>(
                (first, second) => first.Id == second.Id && 
                                   ((Student)first).Name == ((Student)second).Name);
            //
            // listOfStudents.Add(carlos);
            // listOfStudents.Add(carlos1);
            // listOfStudents.Add(carlos2);
            
            Console.ReadLine();
        }
        
        class MyList<T> where T:class, IEntity
        {
            private readonly Func<IEntity, IEntity, bool> _comparisonFunc;
            private ArrayList _list = new ArrayList();

            public MyList(Func<IEntity, IEntity, bool> comparisonFunc)
            {
                _comparisonFunc = comparisonFunc;
            }

            public void Add(T value)
            {
                var index = Find(value, _comparisonFunc);
                if (index >= 0)
                {
                     throw new InvalidOperationException("Entity already exist");
                }
                _list.Add(value);
            }

            public int Find(T value, Func<IEntity, IEntity, bool> comparison)
            {
                var index = -1;

                foreach (IEntity entity in _list)
                {
                    index++;
                    // if (entity.Id.Equals(value.Id))
                    if (comparison(value, entity))
                    {
                        return index;
                    }
                }

                return index;
            }

            public void Delete(T value)
            {
                var index = Find(value, _comparisonFunc);
                if (index == -1)
                {
                    throw new InvalidOperationException("Entity does not exist");
                }

                _list.Remove(value);
            }
        }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }

    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GetAge()
        {
            return 37;
        }
    }

    
}
