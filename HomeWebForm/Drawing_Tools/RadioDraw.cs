using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public class RadioDraw : DeviceDraw
    {
        private string name;
        private IDictionary<string, Devices> deviceList;
        private Label labelName;
        private Label labelState;
        private Button buttonDelete;
        private Image image;
        private Button buttonOnOff;
        private Label labelVolume;
        private Button buttonVolumeDown;
        private Button buttonVolumeUp;
        private Panel panelName;
        private Panel paneState;
        private Panel panelVolume;
        public RadioDraw(string name, IDictionary<string, Devices> deviceList)
        {
            this.name = name;
            this.deviceList = deviceList;
            Ini();
        }
        public override void Ini()
        {
            CssClass = "_devices";
            image = new Image();
            image.CssClass = "_radioImage";
            panelName = new Panel();
            panelName.CssClass = "_panelName";
            labelName = new Label();
            labelName.Text = name;
            panelName.Controls.Add(labelName);
            paneState = new Panel();
            paneState.CssClass = "_paneState";
            labelState = new Label();
            paneState.Controls.Add(labelState);
            panelVolume = new Panel();
            panelVolume.CssClass = "_radioPanelVolume";
            labelVolume = new Label();
            panelVolume.Controls.Add(labelVolume);
            if (deviceList[name].State)
            {
                labelState.Text = "On";
                image.ImageUrl = "~/Picture/Radio.gif";
                if (((Radio)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Low";
                }
                if (((Radio)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Medium";
                }
                if (((Radio)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Height";
                }
            }
            else
            {
                labelState.Text = "Off";
                image.ImageUrl = "~/Picture/RadioOff.jpg";
                labelVolume.Text = "Volume";
            }
            buttonDelete = new Button();
            buttonDelete.Text = "X";
            buttonDelete.CssClass = "_buttonDelete";
            buttonDelete.Click += Delete_Click;
            buttonOnOff = new Button();
            buttonOnOff.Text = "OnOff";
            buttonOnOff.CssClass = "_radioButtonOnOff";
            buttonOnOff.Click += OnOff_Click;
            buttonVolumeDown = new Button();
            buttonVolumeDown.Text = "V <";
            buttonVolumeDown.CssClass = "_radioButtonVolume";
            buttonVolumeDown.Click += VolumeDown_Click;
            buttonVolumeUp = new Button();
            buttonVolumeUp.Text = "> V";
            buttonVolumeUp.CssClass = "_radioButtonVolume";
            buttonVolumeUp.Click += VolumeUp_Click;
            Controls.Add(panelName);
            Controls.Add(paneState);
            Controls.Add(buttonDelete);
            Controls.Add(image);
            Controls.Add(buttonOnOff);
            Controls.Add(buttonVolumeDown);
            Controls.Add(buttonVolumeUp);
            Controls.Add(panelVolume);
        }
        protected void VolumeDown_Click(object sender, EventArgs e)
        {
            ((Radio)deviceList[name]).VolumeDown();
            if (deviceList[name].State)
            {
                if (((Radio)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Low";
                }
                if (((Radio)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Medium";
                }
                if (((Radio)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Height";
                }
            }
        }
        protected void VolumeUp_Click(object sender, EventArgs e)
        {
            ((Radio)deviceList[name]).VolumeUp();
            if (deviceList[name].State)
            {
                if (((Radio)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Low";
                }
                if (((Radio)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Medium";
                }
                if (((Radio)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                {
                    labelVolume.Text = "Volume - Height";
                }
            }
        }
         protected void Delete_Click(object sender, EventArgs e)
         {
             deviceList.Remove(name);
             Parent.Controls.Remove(this);
         }
         protected void OnOff_Click(object sender, EventArgs e)
         {
             ((ISwitchbl)deviceList[name]).OnOff();
             if (deviceList[name].State)
             {
                 labelState.Text = "On";
                 image.ImageUrl = "~/Picture/Radio.gif";
                 if (((Radio)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Low";
                 }
                 if (((Radio)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Medium";
                 }
                 if (((Radio)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Height";
                 }
             }
             else
             {
                 labelState.Text = "Off";
                 labelVolume.Text = "Volume";
                 image.ImageUrl = "~/Picture/RadioOff.jpg";
             }
         }
    }
}