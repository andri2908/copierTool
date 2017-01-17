using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace copierTool
{
    public partial class mainForm : Form
    {
        private string[] fileExtList = { "*.lic", "*.xml" };
        private string volumeLicensePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AlphaSoft\\";

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            string fileName = "";
            if (!Directory.Exists(volumeLicensePath))
                Directory.CreateDirectory(volumeLicensePath);

            for (int i = 0; i < fileExtList.Count(); i++)
            {
                string[] fileNameList = Directory.GetFiles(Application.StartupPath, fileExtList[i]);

                for (int j = 0; j < fileNameList.Count(); j++)
                {
                    fileName = fileNameList[j].Substring(fileNameList[j].LastIndexOf("\\") + 1);
                    Console.WriteLine(fileName);

                    File.Copy(fileName, volumeLicensePath + fileName, true);
                }
            }

            this.Close();
        }
    }
}
