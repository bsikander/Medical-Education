using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Collections;

namespace BL
{
    public class ClsGeneral
    {
        public enum ControlName
        {
            AssignedTo = 1,
            OrganizationType = 2,
            OrganizationProvince = 3,
            PayableProvince = 4,
            RequestType = 5,
            UploadOrganizationGovernance = 6,
            UploadOrganizationBackground = 7
        }

        /// <summary>
        /// This function fetches data for comboboxes based on the input parameter
        /// </summary>
        /// <param name="lCtrlName"></param>
        /// <returns></returns>
        public DataTable FetchControlData(ControlName lCtrlName)
        {
            string lQuery = string.Empty;
            OracleProvider lProvider = new OracleProvider();

            switch (lCtrlName)
            { 
                case ControlName.AssignedTo:
                    lQuery = "Select EMP_LANID, LAST_NAME||', '||FIRST_NAME AS FullName from T_USERS_ACCESS where ACCESS_GROUP='ADMIN' order by 2";
                    break;
                case ControlName.OrganizationType:
                    lQuery = "Select LOOKUP_ID, LOOKUP_DESC from T_LOOKUP where  LOOKUP_GROUP='ORG_TYPE' and DELETED is Null order by 2";
                    break;
                case ControlName.OrganizationProvince:
                    lQuery = "Select LOOKUP_ID, LOOKUP_DESC from T_LOOKUP where  LOOKUP_GROUP='PROV' and DELETED is Null order by 2";
                    break;
                case ControlName.PayableProvince:
                    lQuery = "Select LOOKUP_ID, LOOKUP_DESC from T_LOOKUP where  LOOKUP_GROUP='PROV' and DELETED is Null order by 2";
                    break;
                case ControlName.RequestType:
                    lQuery = "Select LOOKUP_ID, LOOKUP_DESC from T_LOOKUP where  LOOKUP_GROUP='REQTYPE' and DELETED is Null order by 2";
                    break;
            }
            
            return lProvider.FetchDataFromDB(lQuery);
        }

        /// <summary>
        /// This function takes somes inputs and uploads the file to database.
        /// </summary>
        /// <param name="pUserLandId">User windows id</param>
        /// <param name="pApp">application id</param>
        /// <param name="pFileName">file name that is going to be uploaded</param>
        /// <param name="pFileContent">binary content of file</param>
        public void InsertFileIntoDB(string pUserLandId, string pApp, string pFileName , byte[] pFileContent,ControlName pControlName)
        {
            string lQuery = string.Empty;
            OracleProvider lProvider = new OracleProvider();
            string lFileId = string.Empty;
            string lVersionId = string.Empty;
            OracleCommand lCommand = null;
            string lControl = string.Empty;

            try
            {
                if (pControlName == ControlName.UploadOrganizationGovernance)
                {
                    lControl = "Organization Governance";
                }
                else if(pControlName == ControlName.UploadOrganizationBackground)
                {
                    lControl = "Organization Background";
                }

                //Get File and Version Id
                lFileId = lProvider.FetchDataFromDBUsingExecuteScaler("Select SEQ_DOCUMENT_ID.Nextval from dual");
                lVersionId = lProvider.FetchDataFromDBUsingExecuteScaler("Select SEQ_VERSION_ID.Nextval from dual");

                //Begin Transaction
                lCommand = lProvider.OpenConnectionAndBeginTransaction();

                lQuery = "Insert into T_APPLICATION_DOCS (DOCUMENT_ID,APPLICATION_ID, DOC_TITLE,DOC_TYPE,DOC_ASSOCIATE,UPDATED_ON, UPDATED_BY) " +
                      "values (" + lFileId + ",'" + pApp + "','" + lControl + "','I','G'," +
                      "SYSDATE,'" + pUserLandId + "')";

                //Insert into Application Docs
                lProvider.FExecuteNonQuery(lCommand, lQuery, null);

                lQuery = "Insert into T_APPLICATION_DOCS_VERSIONS (DOCUMENT_ID,APPLICATION_ID,VERSION_ID,DOC_EXT,UPLOADED_ON, UPLOADED_BY) " +
                      "VALUES (" + lFileId + ",'" + pApp + "'," + lVersionId + ",'" + pFileName + "', SYSDATE,'" + pUserLandId + "')";

                //Insert into Application_docs_version
                lProvider.FExecuteNonQuery(lCommand, lQuery, null);

                lQuery = "declare xx blob; begin dbms_lob.createtemporary(xx, false, 0); :tempblob := xx; end;";
                
                OracleParameter lParam = new OracleParameter("tempblob", OracleType.Blob);
                lParam.Direction = ParameterDirection.Output;

                OracleParameterCollection lParamCollection = new OracleParameterCollection();
                lParamCollection.Add(lParam);

                lProvider.FExecuteNonQuery(lCommand, lQuery, lParamCollection);
                OracleLob tempLob = (OracleLob)lCommand.Parameters[0].Value;

                //Create temporary BLOB
                OracleLob lLob = (OracleLob)lCommand.Parameters[0].Value;
                int streamLength = pFileContent.Length;

                //Transfer data to server
                lLob.Write(pFileContent, 0, streamLength);

                lParam = new OracleParameter("data", OracleType.Blob);
                lParam.Value = lLob;

                //Create a parameter collection
                lParamCollection = new OracleParameterCollection();
                lParamCollection.Add(lParam);

                lQuery = "Update T_APPLICATION_DOCS_VERSIONS set DOC_CONTENT=:data where DOCUMENT_ID=" + lFileId;

                //Execue the update query
                lProvider.FExecuteNonQuery(lCommand, lQuery, lParamCollection);

                //Commit
                lProvider.CommitTransaction(lCommand);
            }
            catch (Exception ex)
            {
                if (lProvider != null && lCommand != null)
                {
                    lProvider.RollBackTransaction(lCommand);
                }
            }
            finally 
            {
                lProvider = null;
                lCommand = null;                
            }
        }

        /// <summary>
        /// This function return the application Id
        /// </summary>
        /// <returns></returns>
        public string GetApplicationId()
        {
            OracleProvider lProvider = new OracleProvider();
            return lProvider.FetchDataFromDBUsingExecuteScaler("Select SEQ_APPLICATION_ID.Nextval from dual");
        }

        /// <summary>
        /// This function returns all the application
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllApplications()
        {
            string lQuery = "select Application_ID As \"Application Id\",Org_name As \"Organization Name\",org_phone As \"Organization Phone\",created_date As \"Created Date\"  from T_Application Order by application_id";
            OracleProvider lProvider = new OracleProvider();
            return lProvider.FetchDataFromDB(lQuery);
        }

        public void InsertApplicationInDB(ArrayList pParameters)
        {
            string lQuery = "INSERT INTO T_APPLICATION ( ";

        }
    }
}
