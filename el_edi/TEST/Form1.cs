using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TEST
{
    public class data_x
    {
        public string innerx = "inner one haha2";
    }
    
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data_x x = new data_x();
            string string_val = "";
            // MessageBox.Show(super_string);

            Type calcType = x.GetType();
            string numberPropertyInfo = calcType.GetField("innerx").GetValue(x).ToString();

            // string_val = x.innerx;
            // string_val = (string)GetType().GetField("x.innerx").GetValue(this).ToString();

            // string_val = (string)x.GetType().GetField("innerx").GetValue(x).ToString();

            MessageBox.Show(CreateMD5("TEST"));
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
