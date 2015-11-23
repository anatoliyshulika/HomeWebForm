using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public abstract class DeviceDraw : Panel
    {
        private string name;
        private IDictionary<string, Devices> deviceList;
        public DeviceDraw() { }
        public DeviceDraw(string name, IDictionary<string, Devices> deviceList)
        {
            this.name = name;
            this.deviceList = deviceList;
            Ini();
        }
        public virtual void Ini()
        {

        }
    }
}