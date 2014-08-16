using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Resources;
using System.Reflection;

namespace MedicalEducation.Controls
{
    public class CustomImageBox : PictureBox
    {
        private ImageType _pbImagetype = ImageType.Default;
        public enum ImageType
        {
            Default,
            Help,
            Calender
        }

        public CustomImageBox()
        {
        
        }

        public ImageType pbImageType
        {
            get { return _pbImagetype; }
            set {
                if (value == ImageType.Help)
                {
                    this.Width = 20;
                    this.Height = 20;                    

                    ResourceManager rm = new ResourceManager(
                    "MedicalEducation.Properties.Resources",
                    Assembly.GetExecutingAssembly());

                    this.Image = (Image)rm.GetObject("help");                    
                }
                else if (value == ImageType.Calender)
                {
                    this.Width = 20;
                    this.Height = 20;

                    ResourceManager rm = new ResourceManager(
                    "MedicalEducation.Properties.Resources",
                    Assembly.GetExecutingAssembly());

                    this.Image = (Image)rm.GetObject("Calendar");                 
                }
                _pbImagetype = value;
            }
        }

    }
}
