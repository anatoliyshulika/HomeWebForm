using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeWebForm
{
    interface IDraw
    {
        DeviceDraw Draw(string name, IDictionary<string, Devices> deviceList);
    }
}