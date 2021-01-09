using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    public class ListIterator
    {
        private List<string> elements;

        private int index = 0;

        public ListIterator(List<string> inputElements)
        {
            this.Elements = new List<string>(inputElements);
        }

        private List<string> Elements
        {
            get
            {
                return elements;
            }
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentNullException("Invalid Operation!");
                }
                elements = value;
            }
        }

        public bool Move()
        {
            if (!HasNext())
            {
                return false;
            }

            this.index++;
            return true;
        }

        public bool HasNext()
        {
            if (this.index >= this.Elements.Count - 1)
            {
                return false;
            }

            return true;
        }

        public string PrintElement()
        {
            return this.Elements[this.index];
        }
    }
}
