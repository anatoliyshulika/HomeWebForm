using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public class BakeDraw : DeviceDraw
    {
        private string name;
        private IDictionary<string, Devices> burnerList;
        private IDictionary<string, Devices> bakeOvenList;
        private IDictionary<string, Devices> deviceList;
        private Label labelName;
        private Button buttonDelete;
        private Panel panelName;
        public BakeDraw(string name, IDictionary<string, Devices> deviceList)
        {
            this.name = name;
            this.deviceList = deviceList;
            Ini();
        }
        public override void Ini()
        {
            CssClass = "_devices";
            burnerList = new Dictionary<string, Devices>();
            burnerList = ((Bake)deviceList[name]).GetBurnerList();
            bakeOvenList = ((Bake)deviceList[name]).GetBakeOvenList();
            panelName = new Panel();
            panelName.CssClass = "_bakePanelName";
            labelName = new Label();
            labelName.Text = name;
            panelName.Controls.Add(labelName);
            buttonDelete = new Button();
            buttonDelete.Text = "X";
            buttonDelete.CssClass = "_buttonDelete";
            buttonDelete.Click += Delete_Click;
            Controls.Add(panelName);
            Controls.Add(buttonDelete);
            foreach (var burner in burnerList)
            {
                Controls.Add(((IDraw)burner.Value).Draw(burner.Key, burnerList));
            }
            foreach (var oven in bakeOvenList)
            {
                Controls.Add(((IDraw)oven.Value).Draw(oven.Key, bakeOvenList));
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            deviceList.Remove(name);
            Parent.Controls.Remove(this);
        }
    }
}