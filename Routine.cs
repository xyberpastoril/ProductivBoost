using System;
using System.Collections.Generic;
using System.Text;

namespace BeTimelyProject
{
    [Serializable]
    public class Routine
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public Routine(string name)
        {
            this.Name = name;
            this.Tasks = new List<Task>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public Duration GetTotalDuration()
        {
            Duration d = new Duration(0, 0, 0);

            foreach (Task t in this.Tasks)
                d = Duration.Add(d, t.Duration);

            return d;
        }
    }
}
