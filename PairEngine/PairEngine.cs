using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairEngine
{
    public class PairEngine
    {
        private IList<Person> _participants;
        private int _retry;
        private IDictionary<Person, Person> _pairList = new Dictionary<Person, Person>();

        public PairEngine(IList<Person> participants)
        {
            _participants = participants;
        }

        public void PairUp()
        {
            _pairList.Clear();
            IList<Person> _toListAvailable = new List<Person>(_participants);

            Random ran = new Random(_retry);

            foreach (var fromPerson in _participants)
            {
                Person toPerson = null;
                ISet<Person> personTried = new HashSet<Person>();

                do
                {
                    if (toPerson != null) personTried.Add(toPerson);
                    var index = ran.Next(_toListAvailable.Count);
                    toPerson = _toListAvailable[index];
                    if (personTried.Count == _toListAvailable.Count)
                    {
                        PrintResult();
                        if (_retry >= 100)
                        {
                            throw new OperationCanceledException(string.Format("Unable to pair up after {0} retries.", _retry));
                        }
                        _retry++;
                        PairUp();
                        return;
                    }

                } while (toPerson == fromPerson || toPerson.IsCouple(fromPerson));

                _pairList.Add(fromPerson, toPerson);
                _toListAvailable.Remove(toPerson);
            }
        }

        public IDictionary<Person, Person> PairList
        {
            get { return _pairList; }
        }

        public void PrintResult()
        {
            Console.WriteLine("=========Attempt: {0}==========", _retry);
            foreach (var kv in _pairList)
            {
                Console.WriteLine(string.Format("{0} --> {1}", kv.Key, kv.Value));
            }
            Console.WriteLine("=========End==========");
        }
    }
}
