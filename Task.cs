using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BeTimelyProject
{
    public class Task
    {
        private String ToStringDetails = "{0, -12}{1, -80}";
        public Duration Duration { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        public Task(string name, Duration duration, Color color)
        {
            this.Name = name;
            this.Duration = duration;
            this.Color = color;
        }

        public override string ToString()
        {
            return String.Format(ToStringDetails, this.Duration.ToString(), this.Name + " " + this.Color.ToString().Substring(6));
        }
    }
}
