using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    internal class SimpleList<T> where T : IComparable<T>
    {
        protected Element<T>? _start;
        protected Element<T>? _end;

        public int Count { get; protected set; }

        public SimpleList(params T[] arr)
        {
            foreach (var item in arr)
            {
                Add(item);
            }
        }

        public virtual void Add(T item)
        {
            Element<T> newElement = new Element<T>(item, null);
            if (_start == null)
            {
                _start = newElement;
                _end = _start;
            }
            else
            {
                _end!.LinkedTo = newElement;
                _end = newElement;
            }
            Count++;
        }

        public void AddRange(params T[] arr)
        {
            foreach (var item in arr)
            {
                Add(item);
            }
        }

        public void RemoveLast()
        {
            if (_start != null)
            {
                Element<T> current = _start;

                while (!current.LinkedTo!.Equals(_end))
                {
                    current = current.LinkedTo;
                }
                _end = current;
                current.LinkedTo = null;
                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (_start != null)
            {
                Element<T> current = _start;
                _start = current.LinkedTo!;
                Count--;
            }
        }

        public void RemoveAtIndex(int index)
        {
            if (index > Count || index < 0) throw new IndexOutOfRangeException("Der gesuchte Index befindet sich ausserhalb der Liste");
            else if (Count == index)
            {
                RemoveLast();
                return;
            }
            else if (index == 0)
            {
                RemoveFirst();
                return;
            }


            Element<T>? current = _start;
            int elementCounter = 1;             //Startet auf eins, da die Reffernz von current.Next überprüft wird, welcher aktueller Index + 1 ist. (Auf den Startindex 0 wurde zu beginn überprüft.)
            while (index != elementCounter)
            {
                current = current!.LinkedTo!;
                elementCounter++;
            }
            current!.LinkedTo = current.LinkedTo!.LinkedTo;
            Count--;
        }

        public void RemoveAllOf(T item)             
        {
            if (_start == null) return;
            Element<T>? current = _start;
            while (current != null && current!.LinkedTo != null)    //Da beim löschen verschoben wird, kann es passieren das current eher null wird als LinkedTo
            {
                if (current == _start && current.Value.Equals(item)) { _start = current.LinkedTo; Count--; }
                else if (current.LinkedTo!.Value.Equals(item))
                {
                    current.LinkedTo = current.LinkedTo!.LinkedTo;
                    Count--;
                }
                current = current.LinkedTo;
            }
        }

        public void RemoveOnce(T item)         //Löscht nur einen Eintrag des gesuchten Wertes.
        {
            if (_start == null) return;
            Element<T>? current = _start;
            while (current != null && current!.LinkedTo != null)    
            {
                if (current == _start && current.Value.Equals(item)) { _start = current.LinkedTo; Count--; return; }
                else if (current.LinkedTo!.Value.Equals(item))
                {
                    current.LinkedTo = current.LinkedTo!.LinkedTo;
                    Count--;
                    return;
                }
                current = current.LinkedTo;
            }
        }

        public void RemoveAllOfRange(params T[] itemArr)
        {
            foreach (var item in itemArr)
            {
                RemoveAllOf(item);
            }
        }

        public void RemoveRangeOnce(params T[] itemArr)
        {
            foreach (var item in itemArr)
            {
                RemoveOnce(item);
            }
        }

        public T[] ToArray()
        {
            Element<T>? current = _start;
            T[] arr = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                arr[i] = current!.Value;
                current = current.LinkedTo;
            }
            return arr;
        }

        public bool Contains(T item)
        {
            Element<T>? current = _start;
            while (current != null)
            {
                if (current.Value.Equals(item)) return true;
                current = current.LinkedTo;
            }
            return false;
        }
    }
}
