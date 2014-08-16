using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalEducation.Controls
{    
    public class CustomLabel: System.Windows.Forms.Label
    {
        private HeadingType _HeadingType;        

        public enum HeadingType
        {
            H1,
            H2,
            H3        
        };        

        public CustomLabel()
        {            
            
        }

        public HeadingType Heading
        {
            set
            {
                if (value == HeadingType.H1)
                {
                    //FONT-WEIGHT: bold; FONT-SIZE: 13px; TEXT-ALIGN: center
                    float lpoints = 13 * 72 / 96;
                    this.Font = new System.Drawing.Font(this.Font.FontFamily, lpoints,System.Drawing.FontStyle.Bold);
                    this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                }
                else if (value == HeadingType.H2)
                {
                    //FONT-WEIGHT: bold; FONT-SIZE: 11px
                    float lpoints = 11 * 72 / 96;
                    this.Font = new System.Drawing.Font(this.Font.FontFamily, lpoints,System.Drawing.FontStyle.Bold);
                }
                else if (value == HeadingType.H3)
                {
                    //FONT-WEIGHT: bold; FONT-SIZE: 11px; MARGIN: 10px 0px 0px
                    float lpoints = 11 * 72 / 96;
                    this.Font = new System.Drawing.Font(this.Font.FontFamily, lpoints, System.Drawing.FontStyle.Bold);
                    this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
                }
                _HeadingType = value;

            }
            get
            {
                return _HeadingType;
            }
        }

        
    }
}
