using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWebForm 
{
    public class Bake : Devices, IDraw 
    {
        private IDictionary<string, Devices> burnerList;
        private IDictionary<string, Devices> bakeOvenList;
        private BakeDraw drawPanel;
        private Oven bakeOven;
        public Bake(string name, IDictionary<string, Devices> burnerList, Oven bakeOven) : base(name)
        {
            this.burnerList = burnerList;
            this.bakeOven = bakeOven;
        }
        public IDictionary<string, Devices> GetBurnerList()
        {
            return burnerList;
        }
        public IDictionary<string, Devices> GetBakeOvenList()
        {
            bakeOvenList = new Dictionary<string, Devices>();
            bakeOvenList.Add(bakeOven.Name, bakeOven);
            return bakeOvenList;
        }
        public DeviceDraw Draw(string name, IDictionary<string, Devices> deviceList)
        {
            drawPanel = new BakeDraw(name, deviceList);
            return ((DeviceDraw)drawPanel);
        }
    }
}