using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MedicalEducation.Controls
{
    public class CustomDropDown : ComboBox
    {
        private DDLStyles _cmbStyle = DDLStyles.NoStyle;

        public enum DDLStyles
        {
            NoStyle,
            infoUser,
            ingoOrg,
            InfoApp
        }

        //FONT-SIZE: 11px; FONT-FAMILY: Arial, Verdana, Helvetica
        public CustomDropDown()
        {
            float lpoints = 11 * 72 / 96;
            this.Font = new System.Drawing.Font(new FontFamily("Arial"), lpoints, System.Drawing.FontStyle.Bold);            
        }

        public DDLStyles CmbStyle
        {
            set {
                if (value == DDLStyles.infoUser)
                {
                    //.InfoUser {
                    //BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: #ffff66; 
                    //BORDER-BOTTOM-STYLE: none
                    this.BackColor = Color.Yellow;
                }
                else if(value == DDLStyles.ingoOrg )
                {
                    //BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; 
                    //BACKGROUND-COLOR: #f2f6fb; BORDER-BOTTOM-STYLE: none
                    this.BackColor = Color.LightBlue;
                }
                else if (value == DDLStyles.InfoApp)
                {
                    //BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; 
                    //BACKGROUND-COLOR: #f2f6fb; BORDER-BOTTOM-STYLE: none
                    this.BackColor = Color.LightBlue;
                }
                else if (value == DDLStyles.NoStyle)
                { }
                _cmbStyle = value;
            }

            get { return _cmbStyle; }
        }
    }
}
