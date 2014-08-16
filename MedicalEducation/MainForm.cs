using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL;
using Utilities;
using System.Collections.Generic;

namespace MedicalEducation
{
    public partial class MainForm : BaseWinForm
    {
        #region "Data Members"

        private bool mExisting = false;
        private string mApplicationId = string.Empty;

        #endregion

        #region "Form Events"

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(bool pExisting)
        {
            InitializeComponent();

            mExisting = pExisting;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateComboBoxes();

            if (mExisting)
            {
                //Load all the values in controls
            }
            else
            {
                //New application
                lblId.Text = GetNewApplicationId();
            }
        }

        #endregion

        #region "Private Functions"

        /// <summary>
        /// This function populates the combo boxes
        /// </summary>
        private void PopulateComboBoxes()
        {
            ClsGeneral lgeneral = new ClsGeneral();

            //Populate the ddlAssignedTo drop down
            ddlAssignedTo.DataSource = lgeneral.FetchControlData(ClsGeneral.ControlName.AssignedTo);
            ddlAssignedTo.DisplayMember = "FullName";
            ddlAssignedTo.ValueMember = "EMP_LANID";

            //Populate ddlOrgType dropdown
            ddlOrgType.DataSource = lgeneral.FetchControlData(ClsGeneral.ControlName.OrganizationType);
            ddlOrgType.DisplayMember = "LOOKUP_DESC";
            ddlOrgType.ValueMember = "LOOKUP_ID";

            //Populate cmbOrgProvince dropdown
            cmbOrgProvince.DataSource = lgeneral.FetchControlData(ClsGeneral.ControlName.OrganizationProvince);
            cmbOrgProvince.DisplayMember = "LOOKUP_DESC";
            cmbOrgProvince.ValueMember = "LOOKUP_ID";

            //Populate cmbPayProvince combobox
            cmbPayProvince.DataSource = lgeneral.FetchControlData(ClsGeneral.ControlName.PayableProvince);
            cmbPayProvince.DisplayMember = "LOOKUP_DESC";
            cmbPayProvince.ValueMember = "LOOKUP_ID";

            //Populate RequestTypeCombo combobox
            cmbRequestType.DataSource = lgeneral.FetchControlData(ClsGeneral.ControlName.RequestType);
            cmbRequestType.DisplayMember = "LOOKUP_DESC";
            cmbRequestType.ValueMember = "LOOKUP_ID";
        }

        /// <summary>
        /// This function gets a new application id
        /// </summary>
        /// <returns></returns>
        private string GetNewApplicationId()
        {
            ClsGeneral lgeneral = new ClsGeneral();
            string lAppId = lgeneral.GetApplicationId();
            lAppId = "I" + lAppId;
            
            mApplicationId = lAppId;

            return lAppId;
        }

        private void MakeParameterList()
        {
            //System.Collections.ArrayList lAr = new System.Collections.ArrayList();
            //lAr.Add(mApplicationId); //Application_Id
            //lAr.Add("");  //Email_Id
            //lAr.Add(ddlAssignedTo.ValueMember);  //ASSIGNED_TO
            ////lAr.Add("");  //Prefix
            //lAr.Add(txtOrgName.Text);  //ORG_NAME
            //lAr.Add(txtOrgAddress.Text);  //ORG_ADDRESS_1
            ////lAr.Add("");  //ORG_ADDRESS_2
            //lAr.Add(txtOrgCity.Text);  //ORG_CITY
            //lAr.Add(cmbOrgProvince.ValueMember);  //ORG_PROVINCE
            //lAr.Add(txtOrgPostal.Text);  //ORG_POSTAL_CODE
            ////lAr.Add("");  //ORG_PHONE
            ////lAr.Add("");  //ORG_FAX
            ////lAr.Add("");  //ORG_EXTENSION
            //lAr.Add(txtOrgURL.Text);  //ORG_URL
            //lAr.Add(ddlOrgType.ValueMember);  //ORG_TYPE_ID
            //lAr.Add(txtOrgType.Text);  //ORG_TYPE_DESC
            ////lAr.Add("");  //ORG_POSITION
            //lAr.Add(txtOrgGov.Text);  //ORG_GOVERNANCE
            //lAr.Add(txtOrgBack.Text);  //ORG_BACKGROUND            
            //lAr.Add(txtPayable.Text);  //PAYABLE_NAME
            //lAr.Add(txtTax.Text);  //TAX_NUMBER
            //lAr.Add(cmbRequestType.ValueMember);  //REQUEST_TYPE
            //lAr.Add(txtActDesc.Text);  //ACTIVITY_DESC
            //lAr.Add(txtActVenue.Text);  //ACTIVITY_VENUE
            //lAr.Add(txtActCity.Text);  //ACTIVITY_CITY
            //lAr.Add(cmbActProvince.ValueMember);  //ACTIVITY_PROVINCE
            //lAr.Add(txtActDate.Text);  //ACTIVITY_START_DATE
            ////lAr.Add("");  //ACTIVITY_END_DATE
            //lAr.Add(txtActPurpose.Text);  //ACTIVITY_PURPOSE
            //lAr.Add(txtAttendees.Text);  //ATTENDEES
            //if (chkActivityAcc.Checked)
            //{
            //    lAr.Add("1");    //ACTIVITY_ACCREDITED
            //}
            //else
            //{
            //    lAr.Add("0");
            //}
            ////lAr.Add("");    //TARGET_AUDIENCE	
            //lAr.Add(cmbActCountry.ValueMember);    //ACTIVITY_COUNTRY
            //lAr.Add(txtSponsors.Text);    //SPONSORS	
            ////lAr.Add("");    //FUNDING_REQUESTED
            ////lAr.Add("");    //BOOTH_COST
            //lAr.Add(cmbTherArea.ValueMember);    //THER_AREA_ID
            ////lAr.Add("");    //UPDATED_ON	
            //lAr.Add(cmbBrand.ValueMember);    //BRAND_ID	
            //lAr.Add(cmbStatus.ValueMember);    //STATUS_ID	
            //lAr.Add(txtRelease.Text);    //RELEASE_DATE
            ////lAr.Add("");    //RELEASED_BY	
            ////lAr.Add("");    //NEXT_STEP_ID
            //lAr.Add(txtApproved.Text);    //AMOUNT_APPROVED	
            ////lAr.Add("");    //UPDATED_BY	
            //lAr.Add(txtCR.Text);    //CR_NUM	
            ////lAr.Add("");    //REQUEST_DATE
            //lAr.Add(txtComments.Text);    //COMMENTS	
            ////lAr.Add("");    //CREATED_DATE
            ////lAr.Add("");    //REOPEN_DATE	
            ////lAr.Add("");    //REOPENED_BY	
            ////lAr.Add("");    //REOPEN_RATIONALE
            //lAr.Add(txtPaySuite.Text);    //PAYABLE_SUITE	
            //lAr.Add(txtPayAddress.Text);    //PAYABLE_ADDRESS	
            //lAr.Add(txtPayCity.Text);    //PAYABLE_CITY	
            //lAr.Add(cmbPayProvince.ValueMember);    //PAYABLE_PROVINCE	
            //lAr.Add(txtPayPostal.Text);    //PAYABLE_POSTAL_CODE


            
        }

        #endregion

        #region "Control Events"

        private void ckbCopyAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCopyAddress.Checked)
            {
                txtPayAddress.Text = txtOrgAddress.Text.Trim();
                txtPayCity.Text = txtOrgCity.Text;
                cmbPayProvince.SelectedValue = cmbOrgProvince.SelectedValue;
                txtPayPostal.Text = txtOrgPostal.Text;
            }
        }

        private void btnUOrgGov_Click(object sender, EventArgs e)
        {
            ClsGeneral lgeneral = new ClsGeneral();
            ClsUtilities lUtilities = new ClsUtilities();

            if (fileDgOrgGovernance.FileName != "")
            {
                byte[] lFileContent = lUtilities.ConvertFileToByteArray(fileDgOrgGovernance.FileName);
                //TODO: Replace these hardcode values
                lgeneral.InsertFileIntoDB("Behroz", "TestApp", fileDgOrgGovernance.FileName, lFileContent, ClsGeneral.ControlName.UploadOrganizationGovernance);
            }
        }

        private void FileOrgGov_Click(object sender, EventArgs e)
        {
            if (fileDgOrgGovernance.ShowDialog() == DialogResult.OK)
            {
                lblFileDgGovernance.Text = fileDgOrgGovernance.FileName;
            }
        }

        #endregion

        private void btnSave1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
