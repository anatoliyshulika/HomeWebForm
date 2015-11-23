using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web;

namespace HomeWebForm
{
    public class BurnerDraw : DeviceDraw
    {
        private string name;
        private IDictionary<string, Devices> burnerList;
        private Label labelState;
        private Button buttonOnOff;
        private Button buttonLevelUp;
        private Button buttonLevelDown;
        private Image image;
        private Panel panelState;
        public BurnerDraw(string name, IDictionary<string, Devices> burnerList)
        {
            this.name = name;
            this.burnerList = burnerList;
            Ini();
        }
        public override void Ini()
        {
            CssClass = "_burners";
            image = new Image();
            image.CssClass = "_burnerImage";
            panelState = new Panel();
            panelState.CssClass = "_burnerPanelState";
            labelState = new Label();
            panelState.Controls.Add(labelState);
            if (burnerList[name].State)
            {
                labelState.Text = "On";
                image.ImageUrl = "~/Picture/BurnerLow.jpg";
            }
            else
            {
                labelState.Text = "Off";
                image.ImageUrl = "~/Picture/BurnerOff.jpg";
            }
            buttonOnOff = new Button();
            buttonOnOff.Text = "OnOff";
            buttonOnOff.CssClass = "_burnerButtonOnOff";
            buttonOnOff.Click += OnOff_Click;
            buttonLevelUp = new Button();
            buttonLevelUp.Text = ">";
            buttonLevelUp.CssClass = "_burnerButtonLevel";
            buttonLevelUp.Click += LevelUp_Click;
            buttonLevelDown = new Button();
            buttonLevelDown.Text = "<";
            buttonLevelDown.CssClass = "_burnerButtonLevel";
            buttonLevelDown.Click += LevelDown_Click;
            Controls.Add(panelState);
            Controls.Add(image);
            Controls.Add(buttonOnOff);
            Controls.Add(buttonLevelDown);
            Controls.Add(buttonLevelUp);
        }
        protected void OnOff_Click(object sender, EventArgs e)
        {
            ((ISwitchbl)burnerList[name]).OnOff();
            if (burnerList[name].State)
            {
                labelState.Text = "On";
                image.ImageUrl = "~/Picture/BurnerLow.jpg";
            }
            else
            {
                labelState.Text = "Off";
                image.ImageUrl = "~/Picture/BurnerOff.jpg";
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            burnerList.Remove(name);
            Parent.Controls.Remove(this);
        }
        protected void LevelUp_Click(object sender, EventArgs e)
        {
            ((ISetLevel)burnerList[name]).LevelUp();
            if (((Burner)burnerList[name]).BurnerLevel == SetLevel.Low && burnerList[name].State)
            {
                image.ImageUrl = "~/Picture/BurnerLow.jpg";
            }
            if (((Burner)burnerList[name]).BurnerLevel == SetLevel.Medium && burnerList[name].State)
            {
                image.ImageUrl = "~/Picture/BurnerMedium.jpg";
            }
            if (((Burner)burnerList[name]).BurnerLevel == SetLevel.Height && burnerList[name].State)
            {
                image.ImageUrl = "~/Picture/BurnerHeight.jpg";
            }
        }
        protected void LevelDown_Click(object sender, EventArgs e)
        {
            ((ISetLevel)burnerList[name]).LevelDown();
            if (((Burner)burnerList[name]).BurnerLevel == SetLevel.Low && burnerList[name].State)
            {
                image.ImageUrl = "~/Picture/BurnerLow.jpg";
            }
            if (((Burner)burnerList[name]).BurnerLevel == SetLevel.Medium && burnerList[name].State)
            {
                image.ImageUrl = "~/Picture/BurnerMedium.jpg";
            }
            if (((Burner)burnerList[name]).BurnerLevel == SetLevel.Height && burnerList[name].State)
            {
                image.ImageUrl = "~/Picture/BurnerHeight.jpg";
            }
        }
    }
}