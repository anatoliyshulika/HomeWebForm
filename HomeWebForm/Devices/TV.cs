using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebForm
{
    public class TV : Devices, IDraw, ISwitchbl, ISetChannel, ISetVolume
    {
        private TVDraw drawPanel;
        private byte channel = 1;
        private SetLevel volume = SetLevel.Low;
        public TV() { }
        public TV(string name) : base(name)
        {
        }
        public SetLevel Volume
        {
            get
            {
                return volume;
            }
        }
        public byte Chennel
        {
            get
            {
                return channel;
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
        public void ChannelUp()
        {
            if(10 > channel)
            {
                channel++;
            }
            if(10 == channel)
            {
                channel = 1;
            }
        }
        public void ChannelDown()
        {
            if (1 < channel)
            {
                channel--;
            }
            if (1 == channel)
            {
                channel = 10;
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
            drawPanel = new TVDraw(name, deviceList);
            return ((DeviceDraw)drawPanel);
        }
    }
}