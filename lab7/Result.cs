using System;
using System.Collections.Generic;
using System.Text;

namespace lab7
{
    class Result
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public Result(string name, string time)
        {
            Name = name;
            Time = time;
        }
    }
}
