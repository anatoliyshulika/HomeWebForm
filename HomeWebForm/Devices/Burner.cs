using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebForm
{
    public class Burner : Devices, ISwitchbl, ISetLevel, IDraw
    {
        private BurnerDraw drawPanel;
        private SetLevel burnLevel;
        public SetLevel BurnerLevel
        {
            get
            {
                return burnLevel;
            }
        }
        public void OnOff()
        {
            if (State)
            {
                state = false;
                return;
            }
            if (!State)
            {
                state = true;
                return;
            }
        }
        public void LevelUp()
        {
            if (burnLevel == SetLevel.Medium && state)
            {
                burnLevel = SetLevel.Height;
                return;
            }
            else if (burnLevel == SetLevel.Low && state)
            {
                burnLevel = SetLevel.Medium;
                return;
            }
        }
        public void LevelDown()
        {
            if (burnLevel == SetLevel.Medium && state)
            {
                burnLevel = SetLevel.Low;
                return;
            }
            else if (burnLevel == SetLevel.Height && state)
            {
                burnLevel = SetLevel.Medium;
                return;
            }
        }
        public DeviceDraw Draw(string name, IDictionary<string, Devices> burnerList)
        {
            drawPanel = new BurnerDraw(name, burnerList);
            return ((DeviceDraw)drawPanel);
        }
    }
}