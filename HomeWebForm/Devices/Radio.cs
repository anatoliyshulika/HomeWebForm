using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebForm
{
    public class Radio : Devices, IDraw, ISwitchbl, ISetVolume
    {
        private RadioDraw drawPanel;
        private SetLevel volume = SetLevel.Low;
        public Radio() { }
        public Radio(string name) : base(name)
        {
        }
        public SetLevel Volume
        {
            get
            {
                return volume;
            }
        }
        public void OnOff()
        {
            if (State)
            {
                state = false;
                volume = SetLevel.Low;
                return;
            }
            if (!State)
            {
                state = true;
                return;
            }
        }
        public void VolumeUp()
        {
            if (volume == SetLevel.Medium && state)
            {
                volume = SetLevel.Height;
                return;
            }
            else if (volume == SetLevel.Low && state)
            {
                volume = SetLevel.Medium;
                return;
            }
        }
        public void VolumeDown()
        {
            if (volume == SetLevel.Medium && state)
            {
                volume = SetLevel.Low;
                return;
            }
            else if (volume == SetLevel.Height && state)
            {
                volume = SetLevel.Medium;
                return;
            }
        }
        public DeviceDraw Draw(string name, IDictionary<string, Devices> deviceList)
        {
            drawPanel = new RadioDraw(name, deviceList);
            return ((DeviceDraw)drawPanel);
        }
    }
}