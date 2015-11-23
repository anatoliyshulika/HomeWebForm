using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public class FrigeDraw : DeviceDraw
    {
        private string name;
        private IDictionary<string, Devices> deviceList;
        private Label labelFrigeName;
        private Label labelFrigeState;
        private Label labelFrizingLavel;
        private Label labelLampState;
        private Button buttonFrigeOnOff;
        private Button buttonLampOnOff;
        private Button buttonLevelUp;
        private Button buttonLevelDown;
        private Button buttonDelete;
        private Image image;
        private Panel panelName;
        private Panel paneState;
        private Panel panelLampState;
        private Panel panelFrizingLevel;
        public FrigeDraw(string name, IDictionary<string, Devices> deviceList)
        {
            this.name = name;
            this.deviceList = deviceList;
            Ini();
        }
        public override void Ini()
        {
            CssClass = "_devices";
            panelName = new Panel();
            panelName.CssClass = "_panelName";
            labelFrigeName = new Label();
            labelFrigeName.Text = name;
            panelName.Controls.Add(labelFrigeName);
            paneState = new Panel();
            paneState.CssClass = "_paneState";
            labelFrigeState = new Label();
            paneState.Controls.Add(labelFrigeState);
            panelFrizingLevel = new Panel();
            panelFrizingLevel.CssClass = "_frigePanelFrizingLevel";
            labelFrizingLavel = new Label();
            panelFrizingLevel.Controls.Add(labelFrizingLavel);
            if(deviceList[name].State)
            {
                labelFrigeState.Text = "On";
                if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Low)
                {
                    labelFrizingLavel.Text = "Frizing level - Low";
                }
                if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Medium)
                {
                    labelFrizingLavel.Text = "Frizing level - Medium";
                }
                if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Height)
                {
                    labelFrizingLavel.Text = "Frizing level - Height";
                }
            }
            else
            {
                labelFrigeState.Text = "Off";
                labelFrizingLavel.Text = "Frizing level";
            }
            buttonDelete = new Button();
            buttonDelete.Text = "X";
            buttonDelete.CssClass = "_buttonDelete";
            buttonDelete.Click += Delete_Click;
            image = new Image();
            image.CssClass = "_frigeImage";
            image.ImageUrl = "~/Picture/Frige.jpg";
            buttonFrigeOnOff = new Button();
            buttonFrigeOnOff.Text = "OnOff";
            buttonFrigeOnOff.CssClass = "_frigeButtonOnOff";
            buttonFrigeOnOff.Click += FrigeOnOff_Click;
            buttonLevelUp = new Button();
            buttonLevelUp.Text = ">";
            buttonLevelUp.CssClass = "_frigeButtonFrizingLevel";
            buttonLevelUp.Click += LevelUp_Click;
            buttonLevelDown = new Button();
            buttonLevelDown.Text = "<";
            buttonLevelDown.CssClass = "_frigeButtonFrizingLevel";
            buttonLevelDown.Click += LevelDown_Click;
            panelLampState = new Panel();
            panelLampState.CssClass = "_frigePanelLampState";
            labelLampState = new Label();
            panelLampState.Controls.Add(labelLampState);
            if(((Frige)deviceList[name]).GetLampState())
            {
                labelLampState.Text = "Lamp On";
            }
            else
            {
                labelLampState.Text = "Lamp Off";
            }
            buttonLampOnOff = new Button();
            buttonLampOnOff.Text = "OnOff";
            buttonLampOnOff.CssClass = "_frigeButtonOnOff";
            buttonLampOnOff.Click += LampOnOff_Click;
            Controls.Add(panelName);
            Controls.Add(paneState);
            Controls.Add(buttonDelete);
            Controls.Add(image);
            Controls.Add(buttonFrigeOnOff);
            Controls.Add(panelLampState);
            Controls.Add(buttonLampOnOff);
            Controls.Add(buttonLevelDown);
            Controls.Add(buttonLevelUp);
            Controls.Add(panelFrizingLevel);
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            deviceList.Remove(name);
            Parent.Controls.Remove(this);
        }
        protected void FrigeOnOff_Click(object sender, EventArgs e)
        {
            ((ISwitchbl)deviceList[name]).OnOff();
            if (deviceList[name].State)
            {
                labelFrigeState.Text = "On";
                if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Low)
                {
                    labelFrizingLavel.Text = "Frizing level - Low";
                }
                if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Medium)
                {
                    labelFrizingLavel.Text = "Frizing level - Medium";
                }
                if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Height)
                {
                    labelFrizingLavel.Text = "Frizing level - Height";
                }
            }
            else
            {
                labelFrigeState.Text = "Off";
                labelFrizingLavel.Text = "Frizing level";
            }
        }
        protected void LampOnOff_Click(object sender, EventArgs e)
        {
            ((Frige)deviceList[name]).LampOnOff();
            if (((Frige)deviceList[name]).GetLampState())
            {
                labelLampState.Text = "Lamp On";
            }
            else
            {
                labelLampState.Text = "Lamp Off";
            }
        }
        protected void LevelUp_Click(object sender, EventArgs e)
        {
            ((ISetLevel)deviceList[name]).LevelUp();
            if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Low)
            {
                if (deviceList[name].State)
                {
                    labelFrizingLavel.Text = "Frizing level - Low";
                }
                else
                {
                    labelFrizingLavel.Text = "Frizing level";
                }
            }
            if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Medium)
            {
                if (deviceList[name].State)
                {
                    labelFrizingLavel.Text = "Frizing level - Medium";
                }
                else
                {
                    labelFrizingLavel.Text = "Frizing level";
                }
            }
            if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Height)
            {
                if (deviceList[name].State)
                {
                    labelFrizingLavel.Text = "Frizing level - Height";
                }
                else
                {
                    labelFrizingLavel.Text = "Frizing level";
                }
            }
        }
        protected void LevelDown_Click(object sender, EventArgs e)
        {
            ((ISetLevel)deviceList[name]).LevelDown();
            if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Low)
            {
                if (deviceList[name].State)
                {
                    labelFrizingLavel.Text = "Frizing level - Low";
                }
                else
                {
                    labelFrizingLavel.Text = "Frizing level";
                }
            }
            if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Medium)
            {
                if (deviceList[name].State)
                {
                    labelFrizingLavel.Text = "Frizing level - Medium";
                }
                else
                {
                    labelFrizingLavel.Text = "Frizing level";
                }
            }
            if (((Frige)deviceList[name]).FrigeLevel == SetLevel.Height)
            {
                if (deviceList[name].State)
                {
                    labelFrizingLavel.Text = "Frizing level - Height";
                }
                else
                {
                    labelFrizingLavel.Text = "Frizing level";
                }
            }
        }
    }
}