using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public class OvenDraw : DeviceDraw 
    {
        private string name;
        private Label labelOvenState;
        private Label labelLampState;
        private Button buttonOvenOnOff;
        private Button buttonLampOnOff;
        private IDictionary<string, Devices> bakeOvenList;
        private Panel panelOvenState;
        private Panel panelLampState;
        public OvenDraw(string name, IDictionary<string, Devices> bakeOvenList)
        {
            this.name = name;
            this.bakeOvenList = bakeOvenList;
            Ini();
        }
        public override void Ini()
        {
            CssClass = "_oven";
            panelOvenState = new Panel();
            panelOvenState.CssClass = "_panelOvenState";
            labelOvenState = new Label();
            panelOvenState.Controls.Add(labelOvenState);
            if(bakeOvenList[name].State)
            {
                labelOvenState.Text = "Oven On";
            }
            else
            {
                labelOvenState.Text = "Oven Off";
            }
            buttonOvenOnOff = new Button();
            buttonOvenOnOff.Text = "OnOff";
            buttonOvenOnOff.CssClass = "_ovenButtonOnOff";
            buttonOvenOnOff.Click += OvenOnOff_Click;
            panelLampState = new Panel();
            panelLampState.CssClass = "_panelOvenState";
            labelLampState = new Label();
            panelLampState.Controls.Add(labelLampState);
            if (((Oven)bakeOvenList[name]).GetLampState())
            {
                labelLampState.Text = "Lamp On";
            }
            else
            {
                labelLampState.Text = "Lamp Off";
            }
            buttonLampOnOff = new Button();
            buttonLampOnOff.Text = "OnOff";
            buttonLampOnOff.CssClass = "_ovenButtonOnOff";
            buttonLampOnOff.Click += LampOnOff_Click;
            Controls.Add(panelOvenState);
            Controls.Add(panelLampState);
            Controls.Add(buttonOvenOnOff);
            Controls.Add(buttonLampOnOff);
        }
        protected void OvenOnOff_Click(object sender, EventArgs e)
        {
            ((ISwitchbl)bakeOvenList[name]).OnOff();
            if (bakeOvenList[name].State)
            {
                labelOvenState.Text = "Oven On";
            }
            else
            {
                labelOvenState.Text = "Oven Off";
            }
        }
        protected void LampOnOff_Click(object sender, EventArgs e)
        {
            ((Oven)bakeOvenList[name]).LampOnOff();
            if (((Oven)bakeOvenList[name]).GetLampState())
            {
                labelLampState.Text = "Lamp On";
            }
            else
            {
                labelLampState.Text = "Lamp Off";
            }
        }
    }
}