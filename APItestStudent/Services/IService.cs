using APItestStudent.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace APItestStudent.Services
{
    public interface IService<Entity>
    {
        public void Add(Entity value);
        public void Update(Entity value);
        public Entity GetById(Guid id);
        public bool Remove(Guid id);
        public IEnumerable<Entity> GetAll();
    }
    public class Service : IService<Student>
    {
        List<Student> _studentContest = new List<Student>();

        public void Add(Student value)
        {
            value.Id = Guid.NewGuid();
            _studentContest.Add(value);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentContest;
        }

        public Student GetById(Guid id)
        {
            return _studentContest.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Remove(Guid id)
        {
            _studentContest.Remove(_studentContest.Where(x => x.Id == id).FirstOrDefault());
                return true;
        }

        public void Update(Student value)
        {
            var obj = _studentContest.FirstOrDefault(x => x.Id == value.Id);
            if (obj != null) {
                obj.Name = value.Name;
                obj.Description = value.Description;
            }
            Console.WriteLine("no way");
        }
    }
}
