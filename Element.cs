using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedListGeneric
{   
    internal class Element<T>
    {
        public T Value { get; set; }
        public Element<T>? LinkedTo { get; set; }

        public Element(T data, Element<T>? linkedTo = null)
        {
            Value = data;
            LinkedTo = linkedTo;
        }
    }
}
