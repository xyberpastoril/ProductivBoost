using System;
using System.Collections.Generic;
using System.Text;

namespace BeTimelyProject
{
    [Serializable]
    public class Setting
    {
        public bool SwitchToFront { get; private set; }
        public bool PositionOnFront { get; private set; }

        public Setting()
        {
            this.SwitchToFront = false;
            this.PositionOnFront = false;
        }

        public Setting(bool s, bool p)
        {
            this.SwitchToFront = s;
            this.PositionOnFront = p;
        }
    }
}
