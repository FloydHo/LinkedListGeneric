using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGeneric
{
    internal class SimpleSet<T> : SimpleList<T> where T : IComparable<T> 
    {            

        public SimpleSet(params T[] arr) 
        { 
            foreach (var item in arr)
            {
                Add(item);
            }
        }

        public override void Add(T item)
        {
            if (!Contains(item))
            {
                base.Add(item);
            }
        }

        public SimpleSet<T> MergeWith(SimpleSet<T> toMergeSet)
        {
            SimpleSet<T> mergedSet = new SimpleSet<T>();
            AddAllElementsTo(ref mergedSet);
            toMergeSet.AddAllElementsTo(ref mergedSet);
            return mergedSet;
        }

        private void AddAllElementsTo(ref SimpleSet<T> newSet)
        {
            Element<T>? current = _start;

            while (current != null)
            {
                newSet.Add(current.Value);
                current = current.LinkedTo!;
            }
        }
        public SimpleSet<T> IntersectionWith(SimpleSet<T> toCheckSet)
        {
            Element<T>? current = _start;
            SimpleSet<T> intersectionSet = new SimpleSet<T>();

            while (current != null)
            {
                if (toCheckSet.Contains(current.Value))
                {
                    intersectionSet.Add(current.Value);
                }
                current = current.LinkedTo!;
            }
            return intersectionSet;
        }

        public SimpleSet<T> ExclusiveWith(SimpleSet<T> toCheckSet)
        {
            SimpleSet<T> exclusiveSet = new SimpleSet<T>();
            SimpleSet<T> merged = MergeWith(toCheckSet);
            T[] intersection = IntersectionWith(toCheckSet).ToArray();

            foreach (var t in intersection)
            {
                if (!merged.Contains(t))
                {
                    exclusiveSet.Add(t);
                }
            }
            return exclusiveSet;
        }
    }
}
