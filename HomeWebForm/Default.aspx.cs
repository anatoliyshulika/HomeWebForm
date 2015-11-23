using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        private IDictionary<string, Devices> deviceList;
        private IDictionary<string, Devices> burnerList;
        private Lamp lamp;
        private Oven bakeOven;
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                deviceList = new Dictionary<string, Devices>();
                deviceList.Add("Lamp1", new Lamp("Lamp1"));
                deviceList.Add("Bake1", new Bake("Bake1", new Dictionary<string, Devices>{ {"Bake1" + "burner1", new Burner()}, {"Bake1" + "burner2", new Burner()} }, new Oven("Bake1" + "bakeOven", new Lamp("Bake1" + "bakeOven" + "lampOven"))));
                deviceList.Add("Frige1", new Frige("Frige1", new Lamp("Frige1" + "Lamp")));
                deviceList.Add("TV1", new TV("TV1"));
                deviceList.Add("Radio1", new Radio("Radio1"));
                Session["Device"] = deviceList;
            }
            else
            {
                deviceList = (Dictionary<string, Devices>)Session["Device"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(var dev in deviceList)
            {
                Device.Controls.Add(((IDraw)dev.Value).Draw(dev.Key, deviceList));
            }
        }
        protected void addDevice_Click(object sender, EventArgs e)
        {
            string name = TextBoxNameOfDevice.Text;
            if(name == string.Empty)
            {
                return;
            }
            foreach(var key in deviceList)
            {
                if(name == key.Key)
                {
                    TextBoxNameOfDevice.Text = null;
                    return;
                }
            }
            switch(selectDevice.Value.ToString())
            {
                default:
                    break;
                case "Lamp":
                    deviceList.Add(name, new Lamp(name));
                    break;
                case "TV":
                    deviceList.Add(name, new TV(name));
                    break;
                case "Bake":
                    lamp = new Lamp(name + "bakeOven" + "lampOven");
                    bakeOven = new Oven(name + "bakeOven", lamp);
                    burnerList = new Dictionary<string, Devices> { { name + "burner1", new Burner() }, { name + "burner2", new Burner() } };
                    deviceList.Add(name, new Bake(name, burnerList, bakeOven));
                    break;
                case "Frige":
                    lamp = new Lamp(name + "lampFrige");
                    deviceList.Add(name, new Frige(name, lamp));
                    break;
                case "Radio":
                    deviceList.Add(name, new Radio(name));
                    break;
            }
            TextBoxNameOfDevice.Text = null;
            Session["Device"] = deviceList;
            Device.Controls.Add(((IDraw)deviceList[name]).Draw(name, deviceList));
        }
    }
}