using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HomeWebForm
{
    public class LampDraw : DeviceDraw
    {
        private string name;
        private IDictionary<string, Devices> deviceList;
        private Label labelName;
        private Label labelState;
        private Button buttonOnOff;
        private Button buttonDelete;
        private Image image;
        private Panel panelName;
        private Panel paneState;
        public LampDraw(string name, IDictionary<string, Devices> deviceList)
        {
            this.name = name;
            this.deviceList = deviceList;
            Ini();
        }
        public override void Ini()
        {
            CssClass = "_devices";
            image = new Image();
            image.CssClass = "_lampImage";
            panelName = new Panel();
            panelName.CssClass = "_panelName";
            labelName = new Label();
            labelName.Text = name;
            panelName.Controls.Add(labelName);
            paneState = new Panel();
            paneState.CssClass = "_paneState";
            labelState = new Label();
            paneState.Controls.Add(labelState);
            if (deviceList[name].State)
            {
                labelState.Text = "On";
                image.ImageUrl = "~/Picture/LampOn.jpg";
            }
            else
            {
                labelState.Text = "Off";
                image.ImageUrl = "~/Picture/LampOff.jpg";
            }
            buttonOnOff = new Button();
            buttonOnOff.Text = "OnOff";
            buttonOnOff.CssClass = "_lampButtonOnOff";
            buttonOnOff.Click += OnOff_Click;
            buttonDelete = new Button();
            buttonDelete.Text = "X";
            buttonDelete.CssClass = "_buttonDelete";
            buttonDelete.Click += Delete_Click;
            Controls.Add(panelName);
            Controls.Add(paneState);
            Controls.Add(buttonDelete);
            Controls.Add(image);
            Controls.Add(buttonOnOff);
        }
        protected void OnOff_Click(object sender, EventArgs e)
        {
            ((ISwitchbl)deviceList[name]).OnOff();
            if (deviceList[name].State)
            {
                labelState.Text = "On";
                image.ImageUrl = "~/Picture/LampOn.jpg";
            }
            else
            {
                labelState.Text = "Off";
                image.ImageUrl = "~/Picture/LampOff.jpg";
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            deviceList.Remove(name);
            Parent.Controls.Remove(this);
        }
    }
}