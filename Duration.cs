using System;
using System.Collections.Generic;
using System.Text;

namespace BeTimelyProject
{
    public class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public bool TimeUp { get; set; }
        public Duration(int hrs, int min, int sec)
        {
            this.TimeUp = false;
            this.Hours = hrs;
            this.Minutes = min;
            this.Seconds = sec;
        }

        public void Tick()
        {
            this.Seconds--;
            if(this.Seconds == -1)
            {
                this.Minutes--;
                this.Seconds = 59;
            }
            if(this.Minutes == -1)
            {
                this.Hours--;
                this.Minutes = 59;
            }
            if(this.Hours == -1)
            {
                this.Hours = 0;
                this.Minutes = 0;
                this.Seconds = 0;
                this.TimeUp = true;
            }
        }

        public override string ToString()
        {
            return (this.Hours < 10 ? "0" + this.Hours.ToString() : this.Hours.ToString()) + ":" +
                (this.Minutes < 10 ? "0" + this.Minutes.ToString() : this.Minutes.ToString()) + ":" +
                (this.Seconds < 10 ? "0" + this.Seconds.ToString() : this.Seconds.ToString());
        }

        public static Duration Add(Duration total, Duration addend)
        {
            total.Seconds += addend.Seconds;
            if (total.Seconds > 59)
            {
                total.Seconds -= 60;
                total.Minutes++;
            }

            total.Minutes += addend.Minutes;
            if (total.Minutes > 59)
            {
                total.Minutes -= 60;
                total.Hours++;
            }

            total.Hours += addend.Hours;

            return total;
        }
    }
}
