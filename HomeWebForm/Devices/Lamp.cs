using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWebForm
{
    public class Lamp : Devices, IDraw, ISwitchbl
    {
        private LampDraw drawPanel;
        public Lamp() { }
        public Lamp(string name) : base(name)
        {
        }
        public void OnOff()
        {
            if(State)
            {
                state = false;
                return;
            }
            if(!State)
            {
                state = true;
                return;
            }
        }
        public DeviceDraw Draw(string name, IDictionary<string, Devices> deviceList)
        {
            drawPanel = new LampDraw(name, deviceList);
            return ((DeviceDraw)drawPanel);
        }
    }
}