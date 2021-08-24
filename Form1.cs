using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
  

namespace SqlToFtp
{
    public partial class Form1 : Form
    {
        public string Username;
        public string Filename;
        public string Fullname;
        public string Server;
        public string Password;
        public string path;
        public string localdest;
        public Boolean fail_check;
        public Boolean resend_check;
        public string fail_message;
        public int DBRows;

        String connectionString = @"Data Source=DESKTOP-ILDR03H\SQLEXPRESS; Initial Catalog=Student; User ID=sa;Password=sd2432id;";

        public Form1()
        {
            InitializeComponent();
            checkOFF.Checked = true;
            checkON.Enabled = false;
            tbTimer.Enabled = false;
        }

        
        private void btnKerko_Click(object sender, EventArgs e)
        {
            btnCloseDB_Click(sender, e);
                //times on or off function
                if (checkON.Checked == true)
                {
                    try
                    {
                    timerKerko.Enabled = true;
                    string setTimer = tbTimer.Text;
                    Char value = '.';
                    Boolean result = setTimer.Contains(value);
                    if (result == false)
                    {
                        int timerTime = int.Parse(setTimer);
                        timerKerko.Interval = timerTime * 60000;
                    }

                    else
                    {
                        timerKerko.Interval = (int)(float.Parse(setTimer) * 60000.0);
                    }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Input is not valid to meassure time");
                        timerKerko.Interval = 60000;
                    }
                }
            

            if (checkOFF.Checked == true) 
            {
                timerKerko.Enabled = false;
                
            }

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
             //searches info from database and uploades it
                //used for the text file name so they dont overlap
                string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
                string format = string.Format("{0:HH-mm-ss}", DateTime.Now);
                string smth = date + "_" + format;
                //uses the word in textbox to search the sql database
                string kerkoInfo = tbKerko.Text;
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Student].[dbo].[StudentTable] WHERE Name='" + kerkoInfo + "' ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                DBRows = dtbl.Rows.Count;
                
                if (dtbl != null && dtbl.Rows.Count > 0)
                {
                    conditionText.Text = "Your file was saved successfully";
                    conditionText.ForeColor = Color.Green;
                    WriteDataToFile(dtbl, "C:\\Users\\ernit\\Desktop\\ftp\\" + smth + ".csv");
                    dataVGrid.DataSource = dtbl;
                    //starts to upload the file in ftp

                    DirectoryInfo d = new DirectoryInfo(@"C:\Users\ernit\Desktop\ftp");
                    FileInfo[] fi = d.GetFiles("*.csv");

                    if (fi.Length == 0)
                    {
                        conditionText.Text = "Folder is empty";
                        conditionText.ForeColor = Color.Red;
                    }
                    else
                    {
                        resend_check = false;
                        Username = "dlpuser";
                        Password = "rNrKYTX9g7z3RgJRmxWuGHbeu";
                        Server = "ftp://ftp.dlptest.com/";
                        Filename = smth;
                        Fullname = "C:\\Users\\ernit\\Desktop\\ftp\\" + smth + ".csv";

                        backgroundWorker.RunWorkerAsync();
                    } 
                }
                else
                {
                    conditionText.Text = "Search value doesnt respond to the database";
                    conditionText.ForeColor = Color.Red;
                    dataVGrid.DataSource = null;
                }

                //
            }
        }

        //turns the data table into string and saves them in files everytime u search
        public static void WriteDataToFile(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();  
        }

        //timer tick
        private void timerKerko_Tick(object sender, EventArgs e)
        {
            btnKerko_Click(sender, e);
        }

        //clean button cleanes the file
        private void btnPastro_Click(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\ernit\\Desktop\\ftp");

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                
                di.Delete();
            }
            conditionText.Text = "Folder got cleaned";
            conditionText.ForeColor = Color.Black;
        }

        //conects the file you are uploading with the ftp server
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Server, Filename)));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(Username, Password);
              
                Stream ftpstream = request.GetRequestStream();
                FileStream fs = File.OpenRead(Fullname);
                byte[] buffer = new byte[1024];
                double total = (double)fs.Length;
                int byteRead = 0;
                double read = 0;
                do
                {
                    byteRead = fs.Read(buffer, 0, 1024);
                    ftpstream.Write(buffer, 0, byteRead);
                    read += (double)byteRead;
                    double percentage = read / total * 100;
                    backgroundWorker.ReportProgress((int)percentage);
                }
                while (byteRead != 0);
                fs.Close();
                ftpstream.Close();
                fail_check = false;
            }
            catch (Exception ex)
            {   
                fail_check = true;
                fail_message = ex.Message;
            }
        }

        //the proccess of uploading the file in the ftp server
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressLabel.Text = e.ProgressPercentage+"%";
            ProgressLabel.Update();
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        //end result of the connection(fail or success)
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (resend_check == false)
            {
                if (fail_check == false)
                {
                    ProgressLabel.Text = "100%";
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                        string format = string.Format("{0:HH-mm-sstt}", DateTime.Now);
                        string smth = date + "_" + format;
                        SqlDataAdapter sqlDa = new SqlDataAdapter("INSERT INTO [Student].[dbo].[UploadedFiles] (FileName, UploadDate, FileStatus, StatusMessage) VALUES ('" + Filename + "', '" + smth + "','Succede', NULL);", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                    }
                    MessageBox.Show("Upload Complete!");
                }
                else
                {
                    ProgressLabel.Text = "0%";
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                        string format = string.Format("{0:HH-mm-sstt}", DateTime.Now);
                        string smth = date + "_" + format;
                        SqlDataAdapter sqlDa = new SqlDataAdapter("INSERT INTO [Student].[dbo].[UploadedFiles] ( FileName, UploadDate, FileStatus, StatusMessage) VALUES ('" + Filename + "', '" + smth + "','Failed', '" + fail_message + "');", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                    }
                    MessageBox.Show(fail_message);
                }
            }
            else {
                if (fail_check == false)
                {
                    ProgressLabel.Text = "100%";
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");
                        string format = string.Format("{0:HH-mm-sstt}", DateTime.Now);
                        string smth = date + "_" + format;
                        SqlDataAdapter sqlDa = new SqlDataAdapter("UPDATE [Student].[dbo].[UploadedFiles] SET FileStatus = 'Succede', StatusMessage= NULL,UploadDate='"+smth+"' WHERE FileName = '"+Filename+"';", sqlCon);
                        DataTable dtbl = new DataTable();
                        sqlDa.Fill(dtbl);
                    }
                    
                    MessageBox.Show("Upload Complete!");
                }
                else
                {
                    ProgressLabel.Text = "0%";
                    
                    MessageBox.Show(fail_message);
                }
                
            }
        }

        //button that shows all the file taht uploaded or tried to upload in ftp
        private void btnTTest_Click(object sender, EventArgs e)
        {
            btnRefresh.Visible = true;
            btnCloseDB.Visible = true;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                btnPastro.Enabled = false;
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Student].[dbo].[UploadedFiles] ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataVGrid.DataSource = dtbl;
                DBRows = dtbl.Rows.Count;
                resendButton.Visible = true;
                taskTest.Visible = true;
                
                for (int i = 0; i < DBRows; i++)
                {
                    if (String.Equals(dataVGrid.Rows[i].Cells[5].Value, "Succede"))
                    {
                        dataVGrid[0, i].Value = true;
                        
                    }
                    else
                    {
                        dataVGrid[0, i].Value = false;
                        dataVGrid[1, i].Value = "Resend";
                    }
                }
                
            }
            
        }

        //check that sets the timer off
        private void checkOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkOFF.Checked == false)
            {
                checkON.Enabled = true;
                checkON.Checked = true;
                checkOFF.Enabled = false;
                tbTimer.Enabled = true;
                tbTimer.Text = "1";
            }
        }

        //check that sets the timer on
        private void checkON_CheckedChanged(object sender, EventArgs e)
        {
            if (checkON.Checked == false)
            {
                checkOFF.Enabled = true;
                checkOFF.Checked = true;
                checkON.Enabled = false;
                tbTimer.Enabled = false;
                tbTimer.Text = "";
            }
        }

        //load function for the background worker
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker.WorkerReportsProgress = true;
        }

        //fuunction for the resend button in case of fail
      

        private void btnCloseDB_Click(object sender, EventArgs e)
        {
            dataVGrid.DataSource = null;
            dataVGrid.Refresh();
            resendButton.Visible = false;
            taskTest.Visible = false;
            btnCloseDB.Visible = false;
            btnPastro.Enabled = true;
            btnRefresh.Visible = false;
        }

        private void dataVGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (String.Equals(dataVGrid.Rows[e.RowIndex].Cells[1].Value, "Resend") && e.ColumnIndex==1)
                {

                    Boolean checkFile = false;
                    DirectoryInfo d = new DirectoryInfo(@"C:\Users\ernit\Desktop\ftp");
                    FileInfo[] fi = d.GetFiles("*.csv");
                    string resendFile = dataVGrid[3, e.RowIndex].Value.ToString();
                    foreach (FileInfo file in fi)
                    {
                        if (String.Equals(resendFile+".csv",file.Name))
                        {
                            checkFile = true;
                        }
                    }
                    if (checkFile == true)
                    {
                        resend_check = true;
                        Username = "dlpuser";
                        Password = "rNrKYTX9g7z3RgJRmxWuGHbeu";
                        Server = "ftp://ftp.dlptest.com/";
                        Filename = resendFile;
                        Fullname = "C:\\Users\\ernit\\Desktop\\ftp\\" + resendFile + ".csv";

                        backgroundWorker.RunWorkerAsync();
                        dataVGrid.Refresh();
                    }
                    else
                    {
                        conditionText.Text = "This file doesn't exist anymore in the folder";
                        conditionText.ForeColor = Color.Red;
                        /*
                        using (SqlConnection sqlCon = new SqlConnection(connectionString))
                        {
                            int deleteRow = e.RowIndex;
                            int final = deleteRow + 2;
                            SqlDataAdapter sqlDa = new SqlDataAdapter("DELETE FROM [Student].[dbo].[UploadedFiles] WHERE FileID="+final+";", sqlCon);
                            DataTable dtbl = new DataTable();
                            sqlDa.Fill(dtbl);
                        }*/
                    }
                }
                
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataVGrid.Refresh();
            dataVGrid.Update();
        }
    }
}