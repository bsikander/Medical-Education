using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MedicalEducation.Controls
{
    public class CustomGroupBox : GroupBox
    {
        private grpbxStyles _grpbxStyle = grpbxStyles.NoStyle;

        public enum grpbxStyles
        {
            NoStyle,
            Style2
        }

        public grpbxStyles grpbxStyle
        {
            set
            {
                if (value == grpbxStyles.Style2)
                {
                    //FONT-WEIGHT: bold; FONT-SIZE: medium
                    float lpoints = 15 * 72 / 96;
                    this.Font = new System.Drawing.Font(new FontFamily("Arial"), lpoints, System.Drawing.FontStyle.Bold);
                }
                else if (value == grpbxStyles.NoStyle)
                { }
                _grpbxStyle = value;
            }

            get { return _grpbxStyle; }
        }
    }
}
