using System;

namespace BIA_Functions
{
    internal class FunctionNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public FunctionNameAttribute(string name)
        {
            Name = name;
        }
    }
}