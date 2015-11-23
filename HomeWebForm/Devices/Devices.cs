using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWebForm
{
    public abstract class Devices
    {
        private string name = string.Empty;
        protected bool state = false;
        public Devices() { }
        public Devices(string name)
        {
            this.name = name;
        }
        public bool State 
        { 
            get
            {
                return state;
            }
        }
        public string Name 
        {
            get
            {
                return name;
            }
        }
    }
}