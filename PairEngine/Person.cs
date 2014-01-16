using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairEngine
{
    public class Person
    {
        private static int _id = 0;

        public Person()
            : this(null)
        { }

        public Person(string name)
        {
            Id = _id++;
            Name = name;
        }

        private Person _couple;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public void Link(Person couple)
        {
            Unlink(this);
            Unlink(couple);

            _couple = couple;
            couple._couple = this;
        }

        private void Unlink(Person thisPerson)
        {
            if (thisPerson._couple != null) thisPerson._couple._couple = null;
            thisPerson._couple = null;
        }

        public bool IsCouple(Person person)
        {
            return _couple == person;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Id, Name);
        }
    }
}
