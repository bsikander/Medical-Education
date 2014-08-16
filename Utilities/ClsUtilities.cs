using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OracleClient;
//using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Utilities
{
    public class ClsUtilities
    {
        // Read file into Byte Array from Filesystem
        public byte[] ConvertFileToByteArray(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] lFile = br.ReadBytes((int)fs.Length);

            br.Close();
            fs.Close();

            return lFile;
        }

        /// <summary>
        /// Convert the Upload File to small chunks to increase the upload speed
        /// </summary>
        //public OracleLob DivideTheFileToChunks(OracleConnection pCon,byte[] pFileContent)
        //{
        //    //OracleConnection connection = new OracleConnection("server=MyServer; integrated security=yes;");
        //    //connection.Open();
        //    //OracleTransaction transaction = connection.BeginTransaction();
        //    //OracleCommand command = connection.CreateCommand();
        //    //command.Transaction = transaction;
        //    //command.CommandText = "declare xx blob; begin dbms_lob.createtemporary(xx, false, 0); :tempblob := xx; end;";
        //    //command.Parameters.Add(new OracleParameter("tempblob", OracleType.Blob)).Direction = ParameterDirection.Output;
        //    //command.ExecuteNonQuery();

            
        //    //const int BUFFER_SIZE = 1024;
        //    //OracleLob blob = (OracleLob)command.Parameters[0].Value;
            
         
        //    //int startOffset = 0;           
        //    //int writeBytes = 0;
            
        //    //// now load the buffer in small chunks to Oracle            
        //    //blob.BeginWrite(BeginChunkWrite();
        //    //do
        //    //{
        //    //    writeBytes = startOffset + BUFFER_SIZE > pFileContent.Length ? pFileContent.Length - startOffset : BUFFER_SIZE;
        //    //    blob.Write(pFileContent, startOffset, writeBytes);
        //    //    startOffset += writeBytes;
        //    //} while (startOffset < pFileContent.Length);

        //    //blob.EndChunkWrite();

        //    //return blob;
         
        //    ////uploadParameter.Value = blob;
         
        //    ////command.Parameters.Add(uploadParameter);
        //    ////command.ExecuteNonQuery();
        //    ////transaction.Commit();
         
        //    ////Console.WriteLine("Fast upload took : " + new TimeSpan(DateTime.Now.Ticks - startTime.Ticks).TotalSeconds + " seconds");

        //}

        static void UploadBlob(OracleConnection myConnection)
        {
            //Open file on disk
            //FileStream fs = new FileStream("D:\\Tmp\\test.bmp", FileMode.Open, FileAccess.Read);
            //BinaryReader r = new BinaryReader(fs);
            //myConnection.Open();
            ////Create temporary BLOB
            //OracleLob myLob = new OracleLob(myConnection, OracleDbType.Blob);
            //int streamLength = (int)fs.Length;
            ////Transfer data to server
            //myLob.Write(r.ReadBytes(streamLength), 0, streamLength);
            ////Perform INSERT
            //OracleCommand myCommand = new OracleCommand(
            // "INSERT INTO Pictures (ID, PicName, Picture) VALUES(1,'pict1',:Pictures)", myConnection);
            //OracleParameter myParam = myCommand.Parameters.Add("Pictures", OracleDbType.Blob);
            //myParam.OracleValue = myLob;
            //try
            //{
            //    Console.WriteLine(myCommand.ExecuteNonQuery() + " rows affected.");
            //}
            //finally
            //{
            //    myConnection.Close();
            //    r.Close();
            //    fs.Close();
            //}
        }

        static void DownloadBlob(OracleConnection myConnection)
        {
            OracleCommand myCommand = new OracleCommand("SELECT * FROM Pictures", myConnection);
            myConnection.Open();
            OracleDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.Default);
            try
            {
                while (myReader.Read())
                {
                    //Obtain OracleLob directly from OracleDataReader
                    OracleLob myLob = myReader.GetOracleLob(myReader.GetOrdinal("Picture"));
                    if (!myLob.IsNull)
                    {
                        string FN = myReader.GetString(myReader.GetOrdinal("PicName"));
                        //Create file on disk
                        FileStream fs = new FileStream("D:\\Tmp\\" + FN + ".bmp", FileMode.Create);
                        //Use buffer to transfer data
                        byte[] b = new byte[myLob.Length];
                        //Read data from database
                        myLob.Read(b, 0, (int)myLob.Length);
                        //Write data to file
                        fs.Write(b, 0, (int)myLob.Length);
                        fs.Close();
                        Console.WriteLine(FN + " downloaded.");
                    }
                }
            }
            finally
            {
                myReader.Close();
                myConnection.Close();
            }
        }

        

    }
}
