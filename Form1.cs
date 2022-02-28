using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess
{
    public partial class Form1 : Form
    {
        int largeN, smallN, ansN, guessN;

        private void getStart()
        {
            largeN = 99;
            smallN = 10;
            Random rnd = new Random();
            ansN = rnd.Next(11, 99);
            lblLarge.Text = largeN.ToString();
            lblSmall.Text = smallN.ToString();
            clsGuess();
        }

        private void clsGuess()
        {
            txtGuess.Clear();
            txtGuess.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            getStart();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.txtGuess, "請輸入一個二位數數值！");
            getStart();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                guessN = int.Parse(txtGuess.Text);
            }
            catch
            {
                MessageBox.Show("請輸入一個二位數數值！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                clsGuess();
                return;
            }

            if (guessN == ansN)
            {
                MessageBox.Show("恭喜你答對！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (guessN > largeN || guessN < smallN)
                {
                    string msg = "請輸入介於 " + smallN + " 與 " + largeN + " 之間的數值";
                    MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guessN > ansN)
                {
                    MessageBox.Show("輸入小一點的數", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    largeN = guessN;
                    lblLarge.Text = largeN.ToString();
                }
                else if (guessN < ansN)
                {
                    MessageBox.Show("輸入大一點的數", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    smallN = guessN;
                    lblSmall.Text = smallN.ToString();
                }
                clsGuess();
            }
        }
    }
}
