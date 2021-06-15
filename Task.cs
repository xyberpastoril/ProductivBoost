using System;
using System.Collections.Generic;
using System.Text;

namespace BeTimelyProject
{
    public class Task
    {
        private String ToStringDetails = "{0, -14}{1, -50}";
        public Duration Duration { get; set; }
        public string Name { get; set; }

        public Task(string name, Duration duration)
        {
            this.Name = name;
            this.Duration = duration;
        }

        public override string ToString()
        {
            return String.Format(ToStringDetails, this.Duration.ToString(), this.Name);
        }
    }
}
