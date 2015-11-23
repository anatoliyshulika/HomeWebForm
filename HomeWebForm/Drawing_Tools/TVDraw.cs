using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public class TVDraw : DeviceDraw
    {
        private string name;
        private IDictionary<string, Devices> deviceList;
        private Label labelName;
        private Label labelState;
        private Button buttonDelete;
        private Image image;
        private Button buttonOnOff;
        private Button buttonChennelDown;
        private Button buttonChennelUp;
        private Label labelVolume;
        private Button buttonVolumeDown;
        private Button buttonVolumeUp;
        private Panel panelName;
        private Panel paneState;
        private Panel panelVolume;
         public TVDraw(string name, IDictionary<string, Devices> deviceList)
        {
            this.name = name;
            this.deviceList = deviceList;
            Ini();
        }
         public override void Ini()
         {
             EnableViewState = false;
             CssClass = "_devices";
             image = new Image();
             image.CssClass = "_tvImage";
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
             panelVolume.CssClass = "_tvPanelVolume";
             labelVolume = new Label();
             panelVolume.Controls.Add(labelVolume);
             if (deviceList[name].State)
             {
                 labelState.Text = "On";
                 switch (((TV)deviceList[name]).Chennel)
                 {
                     default:
                         break;
                     case 1:
                         image.ImageUrl = "~/Picture/1.gif";
                         break;
                     case 2:
                         image.ImageUrl = "~/Picture/2.gif";
                         break;
                     case 3:
                         image.ImageUrl = "~/Picture/3.gif";
                         break;
                     case 4:
                         image.ImageUrl = "~/Picture/4.gif";
                         break;
                     case 5:
                         image.ImageUrl = "~/Picture/5.gif";
                         break;
                     case 6:
                         image.ImageUrl = "~/Picture/6.gif";
                         break;
                     case 7:
                         image.ImageUrl = "~/Picture/7.gif";
                         break;
                     case 8:
                         image.ImageUrl = "~/Picture/8.gif";
                         break;
                     case 9:
                         image.ImageUrl = "~/Picture/9.gif";
                         break;
                     case 10:
                         image.ImageUrl = "~/Picture/10.gif";
                         break;
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Low";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Medium";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Height";
                 }
             }
             else
             {
                 labelState.Text = "Off";
                 labelVolume.Text = "Volume";
                 image.ImageUrl = "~/Picture/TVoff.jpg";
             }
             buttonDelete = new Button();
             buttonDelete.Text = "X";
             buttonDelete.CssClass = "_buttonDelete";
             buttonDelete.Click += Delete_Click;
             buttonOnOff = new Button();
             buttonOnOff.Text = "OnOff";
             buttonOnOff.CssClass = "_tvButtons";
             buttonOnOff.Click += OnOff_Click;
             buttonChennelDown = new Button();
             buttonChennelDown.Text = "Ch <";
             buttonChennelDown.CssClass = "_tvButtons";
             buttonChennelDown.Click += ChannelDown_Click;
             buttonChennelUp = new Button();
             buttonChennelUp.Text = "> Ch";
             buttonChennelUp.CssClass = "_tvButtons";
             buttonChennelUp.Click += ChannelUp_Click;
             buttonVolumeDown = new Button();
             buttonVolumeDown.Text = "V <";
             buttonVolumeDown.CssClass = "_tvButtonVolume";
             buttonVolumeDown.Click += VolumeDown_Click;
             buttonVolumeUp = new Button();
             buttonVolumeUp.Text = "> V";
             buttonVolumeUp.CssClass = "_tvButtonVolume";
             buttonVolumeUp.Click += VolumeUp_Click;
             Controls.Add(panelName);
             Controls.Add(paneState);
             Controls.Add(buttonDelete);
             Controls.Add(image);
             Controls.Add(buttonOnOff);
             Controls.Add(buttonChennelDown);
             Controls.Add(buttonChennelUp);
             Controls.Add(buttonVolumeDown);
             Controls.Add(buttonVolumeUp);
             Controls.Add(panelVolume);
         }
         protected void ChannelDown_Click(object sender, EventArgs e)
         {
             ((TV)deviceList[name]).ChannelDown();
             if (deviceList[name].State)
             {
                 switch (((TV)deviceList[name]).Chennel)
                 {
                     default:
                         break;
                     case 1:
                         image.ImageUrl = "~/Picture/1.gif";
                         break;
                     case 2:
                         image.ImageUrl = "~/Picture/2.gif";
                         break;
                     case 3:
                         image.ImageUrl = "~/Picture/3.gif";
                         break;
                     case 4:
                         image.ImageUrl = "~/Picture/4.gif";
                         break;
                     case 5:
                         image.ImageUrl = "~/Picture/5.gif";
                         break;
                     case 6:
                         image.ImageUrl = "~/Picture/6.gif";
                         break;
                     case 7:
                         image.ImageUrl = "~/Picture/7.gif";
                         break;
                     case 8:
                         image.ImageUrl = "~/Picture/8.gif";
                         break;
                     case 9:
                         image.ImageUrl = "~/Picture/9.gif";
                         break;
                     case 10:
                         image.ImageUrl = "~/Picture/10.gif";
                         break;
                 }
             }
         }
         protected void ChannelUp_Click(object sender, EventArgs e)
         {
             ((TV)deviceList[name]).ChannelUp();
             if (deviceList[name].State)
             {
                 switch (((TV)deviceList[name]).Chennel)
                 {
                     default:
                         break;
                     case 1:
                         image.ImageUrl = "~/Picture/1.gif";
                         break;
                     case 2:
                         image.ImageUrl = "~/Picture/2.gif";
                         break;
                     case 3:
                         image.ImageUrl = "~/Picture/3.gif";
                         break;
                     case 4:
                         image.ImageUrl = "~/Picture/4.gif";
                         break;
                     case 5:
                         image.ImageUrl = "~/Picture/5.gif";
                         break;
                     case 6:
                         image.ImageUrl = "~/Picture/6.gif";
                         break;
                     case 7:
                         image.ImageUrl = "~/Picture/7.gif";
                         break;
                     case 8:
                         image.ImageUrl = "~/Picture/8.gif";
                         break;
                     case 9:
                         image.ImageUrl = "~/Picture/9.gif";
                         break;
                     case 10:
                         image.ImageUrl = "~/Picture/10.gif";
                         break;
                 }
             }
         }
         protected void VolumeDown_Click(object sender, EventArgs e)
         {
             ((TV)deviceList[name]).VolumeDown();
             if(deviceList[name].State)
             {
                 if (((TV)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Low";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Medium";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Height";
                 }
             }
         }
         protected void VolumeUp_Click(object sender, EventArgs e)
         {
             ((TV)deviceList[name]).VolumeUp();
             if (deviceList[name].State)
             {
                 if (((TV)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Low";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Medium";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
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
                 switch (((TV)deviceList[name]).Chennel)
                 {
                     default:
                         break;
                     case 1:
                         image.ImageUrl = "~/Picture/1.gif";
                         break;
                     case 2:
                         image.ImageUrl = "~/Picture/2.gif";
                         break;
                     case 3:
                         image.ImageUrl = "~/Picture/3.gif";
                         break;
                     case 4:
                         image.ImageUrl = "~/Picture/4.gif";
                         break;
                     case 5:
                         image.ImageUrl = "~/Picture/5.gif";
                         break;
                     case 6:
                         image.ImageUrl = "~/Picture/6.gif";
                         break;
                     case 7:
                         image.ImageUrl = "~/Picture/7.gif";
                         break;
                     case 8:
                         image.ImageUrl = "~/Picture/8.gif";
                         break;
                     case 9:
                         image.ImageUrl = "~/Picture/9.gif";
                         break;
                     case 10:
                         image.ImageUrl = "~/Picture/10.gif";
                         break;
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Low && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Low";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Medium && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Medium";
                 }
                 if (((TV)deviceList[name]).Volume == SetLevel.Height && deviceList[name].State)
                 {
                     labelVolume.Text = "Volume - Height";
                 }
             }
             else
             {
                 labelVolume.Text = "Volume";
                 labelState.Text = "Off";
                 image.ImageUrl = "~/Picture/TVoff.jpg";
             }
         }
    }
}