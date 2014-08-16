using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MedicalEducation.Controls
{
    public class CustomButton : Button
    {
        private bool _RoundCorners =false;

        public CustomButton()
        {
            //FONT-SIZE: 11px; FONT-FAMILY: Arial, Verdana, Helvetica
            float lpoints = 11 * 72 / 96;
            this.Font = new System.Drawing.Font(new FontFamily("Arial"), lpoints, System.Drawing.FontStyle.Bold);                        
        }

        public bool RoundCorners
        {
            //.RoundButton {
	        //FONT-WEIGHT: bold; FONT-SIZE: smaller; COLOR: white; BACKGROUND-COLOR: #6893ed
            set
            {
                if(value == true)
                {
                    float lpoints = 11 * 72 / 96;
                    this.Font = new System.Drawing.Font(this.Font.FontFamily,lpoints);
                    this.BackColor = Color.SteelBlue;
                    this.ForeColor = Color.White;
                }
                _RoundCorners = value;
            }
            get { return _RoundCorners; }
        }
    }
}
