using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        public string TypeName { get; set; }
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
            this.TypeName = GetType().FullName;
        }

        public override string ToString()
        {
            return $"{this.TypeName} : {this.Value}";
        }
    }
}
