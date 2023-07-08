using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using Point = System.Drawing.Point;

namespace SistemaRRHH_EF
{
    public partial class frmMenu : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildFrm;

        //Constructor
        public frmMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new System.Drawing.Size(7, 43);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(248, 186, 87);
            public static Color color2 = Color.FromArgb(209, 123, 96);
            public static Color color3 = Color.FromArgb(95, 108, 90);
            public static Color color4 = Color.FromArgb(193, 107, 131);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 166, 166);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildFrm.IconChar = currentBtn.IconChar;
                iconCurrentChildFrm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(3, 131, 135);
                currentBtn.ForeColor = Color.PaleTurquoise;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.PaleTurquoise;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildFrm != null)
            {
                currentChildFrm.Close();
            }
            currentChildFrm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildFrm.Text = childForm.Text;
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildFrm.IconChar = IconChar.Home;
            iconCurrentChildFrm.IconColor = Color.PaleTurquoise;
            lblTitleChildFrm.Text = "Home";
        }


        //Events
        //Reset
        private void btnHome_Click(object senderBtn, EventArgs e)
        {
            if (currentChildFrm != null)
            {
                currentChildFrm.Close();
            }
            Reset();
        }

        //Menu Button_Clicks
        private void btnPerfiles_Click(object senderBtn, EventArgs e)
        {
            ActivateButton(senderBtn, RGBColors.color1);
            OpenChildForm(new frmPerfiles());
        }

        private void btnOfertasLaborales_Click(object senderBtn, EventArgs e)
        {
            ActivateButton(senderBtn, RGBColors.color2);
            OpenChildForm(new frmOfertasLaborales());
        }

        private void btnPostulantes_Click(object senderBtn, EventArgs e)
        {
            ActivateButton(senderBtn, RGBColors.color3);
            OpenChildForm(new frmPostulantes());
        }

        private void btnTurnos_Click(object senderBtn, EventArgs e)
        {
            ActivateButton(senderBtn, RGBColors.color4);
            OpenChildForm(new frmTurnos());
        }

        private void btnMenu_Click(object senderBtn, EventArgs e)
        {
            Reset();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void barraDeTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        //Close-Maximize-Minimize
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {

            }
        }
    }
}

