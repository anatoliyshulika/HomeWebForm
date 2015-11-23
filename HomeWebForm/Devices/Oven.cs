using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace HomeWebForm
{
    public class Oven : Devices, ISwitchbl, IDraw
    {
        private Lamp lamp;
        private OvenDraw drawPanel;
        public Oven() { }
        public Oven(string name, Lamp lamp) : base(name)
        {
            this.lamp = lamp;
        }
        public void LampOnOff()
        {
            lamp.OnOff();
        }
        public bool GetLampState()
        {
            return lamp.State;
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
        public DeviceDraw Draw(string name, IDictionary<string, Devices> bakeOvenList)
        {
            drawPanel = new OvenDraw(name, bakeOvenList);
            return ((DeviceDraw)drawPanel);
        }
    }
}
