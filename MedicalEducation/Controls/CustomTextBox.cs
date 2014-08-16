using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MedicalEducation.Controls
{
    public class CustomTextBox : TextBox
    {
        private TextboxType _txtType = TextboxType.Default;
        public enum TextboxType
        {
            Default,
            InfoOrg,
            InfoApp,
            InfoUser
        }

        public CustomTextBox()
        { 
            //FONT-SIZE: 11px; FONT-FAMILY: Arial, Verdana, Helvetica
            float lpoints = 11 * 72 / 96;
            this.Font = new System.Drawing.Font(new FontFamily("Arial"), lpoints, System.Drawing.FontStyle.Bold);                        
        }

        public TextboxType txtStyle
        {
            get { return _txtType; }
            set
            {
                if (value == TextboxType.InfoOrg)
                {
                    //BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; 
                    //BACKGROUND-COLOR: #f2f6fb; BORDER-BOTTOM-STYLE: none
                    this.BackColor = Color.LightBlue;
                }
                else if (value == TextboxType.InfoApp)
                {
                    //BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; 
                    //BACKGROUND-COLOR: #f2f6fb; BORDER-BOTTOM-STYLE: none
                    this.BackColor = Color.LightBlue;
                }
                else if (value == TextboxType.InfoUser)
                {
                    //BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; 
                    //BACKGROUND-COLOR: #ffff66; BORDER-BOTTOM-STYLE: none
                    this.BackColor = Color.Yellow;
                }
                _txtType = value;
            }
        }
        

    }
}
