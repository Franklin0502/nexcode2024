// Decompiled with JetBrains decompiler
// Type: FlameWooLogin.Form1
// Assembly: FlameWooLogin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA57480B-DD63-45C7-B0C5-EDAB3208EC55
// Assembly location: C:\Users\lucap\Desktop\2k24 cheat\NEX.exe

using FlameWooLogin.Properties;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace FlameWooLogin
{
  public class Form1 : Form
  {
    private const int MOVEFILE_REPLACE_EXISTING = 1;
    private List<Control> animatedControls = new List<Control>();
    private Dictionary<Control, int> currentPositions = new Dictionary<Control, int>();
    private Dictionary<Control, (int Start, int End)> positionsMap = new Dictionary<Control, (int, int)>();
    private int speed = 12;
    public static string allkey;
    private IContainer components;
    private Guna2PictureBox guna2PictureBox1;
    private Guna2DragControl guna2DragControl1;
    private Guna2Panel guna2Panel2;
    private Guna2Button guna2Button2;
    private Guna2Button guna2Button1;
    private Label label1;
    private Guna2ToggleSwitch guna2ToggleSwitch1;
    private Guna2ShadowForm guna2ShadowForm1;
    private Guna2AnimateWindow guna2AnimateWindow1;
    private Guna2PictureBox guna2PictureBox5;
    private Guna2PictureBox guna2PictureBox4;
    private Guna2PictureBox guna2PictureBox3;
    private Label label2;
    private Label label3;
    private Guna2ComboBox guna2ComboBox1;
    private Label label4;
    private Timer animationTimer;
    private Guna2Button driverInstallButton2;
    private Guna2Button driverInstallButton1;
    private Guna2ControlBox guna2ControlBox2;
    private Guna2ControlBox guna2ControlBox1;
    private Label label6;
    private Label label5;
    private Guna2PictureBox guna2PictureBox2;
    public Guna2TextBox guna2TextBox1;
    private Guna2Button guna2Button3;

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool MoveFileEx(
      string lpExistingFileName,
      string lpNewFileName,
      int dwFlags);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool RemoveDirectory(string lpPathName);

    [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern bool PathFileExists(string pszPath);

    public static bool ForceDeleteFile(string fileName)
    {
      try
      {
        string str1 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        string str2 = Path.Combine(str1, "TemporaryFile");
        Directory.CreateDirectory(str1);
        if (!Form1.MoveFileEx(fileName, str2, 1))
          return false;
        File.Delete(str2);
        return Form1.RemoveDirectory(str1) && !Form1.PathFileExists(fileName);
      }
      catch
      {
        return false;
      }
    }

    public static Font CustomFont { get; private set; }

    public static Font DownloadFont { get; private set; }

    private void SetFontForAllControls(Control parent, Font font)
    {
      foreach (Control control in (ArrangedElementCollection) parent.Controls)
      {
        control.Font = font;
        this.SetFontForAllControls(control, font);
      }
    }

    public Form1()
    {
      Form1.ForceDeleteFile(Process.GetCurrentProcess().MainModule.FileName);
      this.InitializeComponent();
      this.label3.Left = -300;
      this.label4.Left = -300;
      this.label1.Left = -300;
      ((Control) this.guna2ComboBox1).Left = -300;
      ((Control) this.guna2TextBox1).Left = -300;
      ((Control) this.guna2ToggleSwitch1).Left = -300;
      ((Control) this.guna2Button1).Left = -300;
      ((Control) this.guna2Button2).Left = -300;
      ((Control) this.guna2Button3).Left = -300;
    }

    private void initAnimation()
    {
      this.animatedControls.Add((Control) this.label3);
      this.positionsMap[(Control) this.label3] = (-50, 45);
      this.animatedControls.Add((Control) this.label4);
      this.positionsMap[(Control) this.label4] = (-50, 45);
      this.animatedControls.Add((Control) this.label1);
      this.positionsMap[(Control) this.label1] = (-50, 88);
      this.animatedControls.Add((Control) this.label5);
      this.positionsMap[(Control) this.label5] = (54, 400);
      this.animatedControls.Add((Control) this.label6);
      this.positionsMap[(Control) this.label6] = (54, 400);
      this.animatedControls.Add((Control) this.driverInstallButton1);
      this.positionsMap[(Control) this.driverInstallButton1] = (54, 400);
      this.animatedControls.Add((Control) this.driverInstallButton2);
      this.positionsMap[(Control) this.driverInstallButton2] = (54, 400);
      this.animatedControls.Add((Control) this.guna2ComboBox1);
      this.positionsMap[(Control) this.guna2ComboBox1] = (-285, 45);
      this.animatedControls.Add((Control) this.guna2TextBox1);
      this.positionsMap[(Control) this.guna2TextBox1] = (-281, 45);
      this.animatedControls.Add((Control) this.guna2ToggleSwitch1);
      this.positionsMap[(Control) this.guna2ToggleSwitch1] = (-281, 45);
      this.animatedControls.Add((Control) this.guna2Button1);
      this.positionsMap[(Control) this.guna2Button1] = (-281, 45);
      this.animatedControls.Add((Control) this.guna2Button2);
      this.positionsMap[(Control) this.guna2Button2] = (-281, 45);
      this.animatedControls.Add((Control) this.guna2Button3);
      this.positionsMap[(Control) this.guna2Button3] = (-281, 45);
      foreach (Control animatedControl in this.animatedControls)
      {
        int start = this.positionsMap[animatedControl].Start;
        this.currentPositions[animatedControl] = start;
        animatedControl.Left = start;
      }
      this.animationTimer.Interval = 20;
      this.animationTimer.Tick += new EventHandler(this.AnimationTimer_Tick);
      this.animationTimer.Start();
    }

    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
      bool flag = true;
      foreach (Control animatedControl in this.animatedControls)
      {
        int end = this.positionsMap[animatedControl].End;
        int num = this.currentPositions[animatedControl] + this.speed;
        if (num <= end)
        {
          animatedControl.Left = num;
          this.currentPositions[animatedControl] = num;
          flag = false;
        }
        else if (this.currentPositions[animatedControl] < end)
        {
          animatedControl.Left = end;
          this.currentPositions[animatedControl] = end;
        }
      }
      if (!flag)
        return;
      this.animationTimer.Stop();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      FontFamily family = FontLoader.LoadFontFamily(FontLoader.GetFontData("FlameWooLogin.Resources.font143.ttf"), out IntPtr _);
      Form1.CustomFont = new Font(family, 18f);
      Form1.DownloadFont = new Font(family, 12f);
      this.label2.Font = Form1.CustomFont;
    }

    private void DriverFunction()
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    [DllImport("kernel32.dll")]
    public static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    public static extern bool FreeConsole();

    private void guna2Button1_Click(object sender, EventArgs e)
    {
      Form1.allkey = ((Control) this.guna2TextBox1).Text + "|" + ((ListControl) this.guna2ComboBox1).SelectedIndex.ToString();
      Download download = new Download();
      download.StartPosition = FormStartPosition.Manual;
      int x = this.Location.X + (this.Width - download.Width) / 2;
      int y = this.Location.Y + (this.Height - download.Height) / 2;
      download.Location = new Point(x, y);
      download.Show();
    }

    private void driverInstallButton1_Click(object sender, EventArgs e)
    {
      this.driverInstallButton1_ClickAsync();
    }

    private async Task driverInstallButton1_ClickAsync()
    {
      ((Control) this.driverInstallButton2).Enabled = false;
      Program.DriverInitDelegate functionDelegate = Program.GetFunctionDelegate<Program.DriverInitDelegate>("DriverInit_China");
      if (functionDelegate == null)
        return;
      if (functionDelegate())
      {
        ((Control) this.driverInstallButton1).Text = "Driver installing ...";
        await Task.Delay(3000);
        ((Control) this.driverInstallButton1).Text = "Driver install Successfully!";
        await Task.Delay(1500);
        this.initAnimation();
      }
      else
      {
        ((Control) this.driverInstallButton1).Text = "Driver Faild!";
        ((Control) this.driverInstallButton2).Enabled = false;
      }
    }

    private void driverInstallButton2_Click(object sender, EventArgs e)
    {
      this.driverInstallButton2_ClickAsync();
    }

    private async Task driverInstallButton2_ClickAsync()
    {
      ((Control) this.driverInstallButton1).Enabled = false;
      Program.DriverInitDelegate functionDelegate = Program.GetFunctionDelegate<Program.DriverInitDelegate>("DriverInit_English");
      if (functionDelegate == null)
        return;
      if (functionDelegate())
      {
        ((Control) this.driverInstallButton2).Text = "Driver installing ...";
        await Task.Delay(3000);
        ((Control) this.driverInstallButton2).Text = "Driver install Successfully!";
        await Task.Delay(1500);
        this.initAnimation();
      }
      else
      {
        ((Control) this.driverInstallButton2).Text = "Driver Faild!";
        ((Control) this.driverInstallButton1).Enabled = false;
      }
    }

    private void guna2PictureBox3_Click(object sender, EventArgs e)
    {
      Process.Start("https://flamewoo.com/");
    }

    private void guna2PictureBox4_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.youtube.com/@FlameWoo-official");
    }

    private void guna2PictureBox5_Click(object sender, EventArgs e)
    {
      Process.Start("https://discord.gg/flamewoo");
    }

    private void guna2Button3_Click(object sender, EventArgs e)
    {
      Form1.allkey = "free";
      Download download = new Download();
      download.StartPosition = FormStartPosition.Manual;
      int x = this.Location.X + (this.Width - download.Width) / 2;
      int y = this.Location.Y + (this.Height - download.Height) / 2;
      download.Location = new Point(x, y);
      download.Show();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.guna2DragControl1 = new Guna2DragControl(this.components);
      this.guna2Panel2 = new Guna2Panel();
      this.label5 = new Label();
      this.label6 = new Label();
      this.driverInstallButton2 = new Guna2Button();
      this.driverInstallButton1 = new Guna2Button();
      this.label4 = new Label();
      this.label3 = new Label();
      this.guna2ComboBox1 = new Guna2ComboBox();
      this.label2 = new Label();
      this.guna2PictureBox5 = new Guna2PictureBox();
      this.guna2PictureBox4 = new Guna2PictureBox();
      this.guna2PictureBox3 = new Guna2PictureBox();
      this.guna2Button2 = new Guna2Button();
      this.guna2Button1 = new Guna2Button();
      this.label1 = new Label();
      this.guna2ToggleSwitch1 = new Guna2ToggleSwitch();
      this.guna2TextBox1 = new Guna2TextBox();
      this.guna2PictureBox1 = new Guna2PictureBox();
      this.guna2ShadowForm1 = new Guna2ShadowForm(this.components);
      this.guna2AnimateWindow1 = new Guna2AnimateWindow(this.components);
      this.animationTimer = new Timer(this.components);
      this.guna2ControlBox2 = new Guna2ControlBox();
      this.guna2ControlBox1 = new Guna2ControlBox();
      this.guna2PictureBox2 = new Guna2PictureBox();
      this.guna2Button3 = new Guna2Button();
      ((Control) this.guna2Panel2).SuspendLayout();
      ((ISupportInitialize) this.guna2PictureBox5).BeginInit();
      ((ISupportInitialize) this.guna2PictureBox4).BeginInit();
      ((ISupportInitialize) this.guna2PictureBox3).BeginInit();
      ((ISupportInitialize) this.guna2PictureBox1).BeginInit();
      ((ISupportInitialize) this.guna2PictureBox2).BeginInit();
      this.SuspendLayout();
      this.guna2DragControl1.ContainerControl = (ContainerControl) this;
      this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
      this.guna2DragControl1.TargetControl = (Control) this.guna2Panel2;
      this.guna2DragControl1.UseTransparentDrag = true;
      ((Control) this.guna2Panel2).BackColor = Color.FromArgb(0, 13, 15);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2Button3);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.label5);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.label6);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.driverInstallButton2);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.driverInstallButton1);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.label4);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.label3);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2ComboBox1);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.label2);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2PictureBox5);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2PictureBox4);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2PictureBox3);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2Button2);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2Button1);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.label1);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2ToggleSwitch1);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2TextBox1);
      ((Control) this.guna2Panel2).Controls.Add((Control) this.guna2PictureBox1);
      ((Control) this.guna2Panel2).Location = new Point(0, 0);
      ((Control) this.guna2Panel2).Name = "guna2Panel2";
      ((Control) this.guna2Panel2).Size = new Size(341, 702);
      ((Control) this.guna2Panel2).TabIndex = 3;
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
      this.label5.ForeColor = Color.White;
      this.label5.Location = new Point(54, 306);
      this.label5.Name = "label5";
      this.label5.Size = new Size(49, 15);
      this.label5.TabIndex = 26;
      this.label5.Text = "Mode 1";
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
      this.label6.ForeColor = Color.White;
      this.label6.Location = new Point(54, 395);
      this.label6.Name = "label6";
      this.label6.Size = new Size(49, 15);
      this.label6.TabIndex = 25;
      this.label6.Text = "Mode 2";
      this.driverInstallButton2.Animated = true;
      ((Control) this.driverInstallButton2).BackColor = Color.Transparent;
      this.driverInstallButton2.BorderRadius = 10;
      this.driverInstallButton2.FillColor = Color.FromArgb(193, 20, 137);
      ((Control) this.driverInstallButton2).Font = new Font("Segoe UI", 12f, FontStyle.Bold);
      ((Control) this.driverInstallButton2).ForeColor = Color.White;
      this.driverInstallButton2.HoverState.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
      ((Control) this.driverInstallButton2).Location = new Point(54, 415);
      ((Control) this.driverInstallButton2).Name = "driverInstallButton2";
      ((Control) this.driverInstallButton2).Size = new Size(251, 36);
      ((Control) this.driverInstallButton2).TabIndex = 21;
      ((Control) this.driverInstallButton2).Text = "Driver Install";
      this.driverInstallButton2.UseTransparentBackground = true;
      ((Control) this.driverInstallButton2).Click += new EventHandler(this.driverInstallButton2_Click);
      this.driverInstallButton1.Animated = true;
      ((Control) this.driverInstallButton1).BackColor = Color.Transparent;
      this.driverInstallButton1.BorderRadius = 10;
      this.driverInstallButton1.FillColor = Color.FromArgb(193, 20, 137);
      ((Control) this.driverInstallButton1).Font = new Font("Segoe UI", 12f, FontStyle.Bold);
      ((Control) this.driverInstallButton1).ForeColor = Color.White;
      this.driverInstallButton1.HoverState.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
      ((Control) this.driverInstallButton1).Location = new Point(54, 336);
      ((Control) this.driverInstallButton1).Name = "driverInstallButton1";
      ((Control) this.driverInstallButton1).Size = new Size(251, 36);
      ((Control) this.driverInstallButton1).TabIndex = 20;
      ((Control) this.driverInstallButton1).Text = "Driver Install";
      this.driverInstallButton1.UseTransparentBackground = true;
      ((Control) this.driverInstallButton1).Click += new EventHandler(this.driverInstallButton1_Click);
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
      this.label4.ForeColor = Color.White;
      this.label4.Location = new Point(267, 327);
      this.label4.Name = "label4";
      this.label4.Size = new Size(28, 15);
      this.label4.TabIndex = 19;
      this.label4.Text = "Key";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
      this.label3.ForeColor = Color.White;
      this.label3.Location = new Point(267, 257);
      this.label3.Name = "label3";
      this.label3.Size = new Size(48, 15);
      this.label3.TabIndex = 18;
      this.label3.Text = "Version";
      ((Control) this.guna2ComboBox1).BackColor = Color.Transparent;
      this.guna2ComboBox1.BorderRadius = 5;
      this.guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
      this.guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      this.guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      ((Control) this.guna2ComboBox1).Font = new Font("Segoe UI", 10f);
      ((Control) this.guna2ComboBox1).ForeColor = Color.FromArgb(68, 88, 112);
      ((ComboBox) this.guna2ComboBox1).ItemHeight = 22;
      ((ComboBox) this.guna2ComboBox1).Items.AddRange(new object[6]
      {
        (object) "All in One",
        (object) "Park and Greener",
        (object) "Park",
        (object) "AutoGreener",
        (object) "Myteam",
        (object) "Mypoint"
      });
      ((Control) this.guna2ComboBox1).Location = new Point(270, 282);
      ((Control) this.guna2ComboBox1).Name = "guna2ComboBox1";
      ((Control) this.guna2ComboBox1).Size = new Size(251, 28);
      this.guna2ComboBox1.StartIndex = 0;
      ((Control) this.guna2ComboBox1).TabIndex = 17;
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(65, 210);
      this.label2.Name = "label2";
      this.label2.Size = new Size(94, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "FlameWoo Login";
      ((Control) this.guna2PictureBox5).BackColor = Color.Transparent;
      ((PictureBox) this.guna2PictureBox5).Image = (Image) Resources.app;
      this.guna2PictureBox5.ImageRotate = 0.0f;
      ((Control) this.guna2PictureBox5).Location = new Point(232, 608);
      ((Control) this.guna2PictureBox5).Name = "guna2PictureBox5";
      ((Control) this.guna2PictureBox5).Size = new Size(64, 64);
      ((PictureBox) this.guna2PictureBox5).SizeMode = PictureBoxSizeMode.Zoom;
      ((PictureBox) this.guna2PictureBox5).TabIndex = 10;
      ((PictureBox) this.guna2PictureBox5).TabStop = false;
      this.guna2PictureBox5.UseTransparentBackground = true;
      ((Control) this.guna2PictureBox5).Click += new EventHandler(this.guna2PictureBox5_Click);
      ((Control) this.guna2PictureBox4).BackColor = Color.Transparent;
      ((PictureBox) this.guna2PictureBox4).Image = (Image) Resources.youtube;
      this.guna2PictureBox4.ImageRotate = 0.0f;
      ((Control) this.guna2PictureBox4).Location = new Point(139, 608);
      ((Control) this.guna2PictureBox4).Name = "guna2PictureBox4";
      ((Control) this.guna2PictureBox4).Size = new Size(64, 64);
      ((PictureBox) this.guna2PictureBox4).SizeMode = PictureBoxSizeMode.Zoom;
      ((PictureBox) this.guna2PictureBox4).TabIndex = 9;
      ((PictureBox) this.guna2PictureBox4).TabStop = false;
      this.guna2PictureBox4.UseTransparentBackground = true;
      ((Control) this.guna2PictureBox4).Click += new EventHandler(this.guna2PictureBox4_Click);
      ((Control) this.guna2PictureBox3).BackColor = Color.Transparent;
      ((PictureBox) this.guna2PictureBox3).Image = (Image) Resources.官方网站;
      this.guna2PictureBox3.ImageRotate = 0.0f;
      ((Control) this.guna2PictureBox3).Location = new Point(45, 608);
      ((Control) this.guna2PictureBox3).Name = "guna2PictureBox3";
      ((Control) this.guna2PictureBox3).Size = new Size(64, 64);
      ((PictureBox) this.guna2PictureBox3).SizeMode = PictureBoxSizeMode.Zoom;
      ((PictureBox) this.guna2PictureBox3).TabIndex = 8;
      ((PictureBox) this.guna2PictureBox3).TabStop = false;
      this.guna2PictureBox3.UseTransparentBackground = true;
      ((Control) this.guna2PictureBox3).Click += new EventHandler(this.guna2PictureBox3_Click);
      this.guna2Button2.Animated = true;
      ((Control) this.guna2Button2).BackColor = Color.Transparent;
      this.guna2Button2.BorderColor = Color.FromArgb(193, 20, 137);
      this.guna2Button2.BorderRadius = 10;
      this.guna2Button2.BorderThickness = 2;
      this.guna2Button2.FillColor = Color.FromArgb(0, 9, 43);
      ((Control) this.guna2Button2).Font = new Font("Segoe UI", 12f, FontStyle.Bold);
      ((Control) this.guna2Button2).ForeColor = Color.White;
      this.guna2Button2.HoverState.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
      ((Control) this.guna2Button2).Location = new Point(270, 496);
      ((Control) this.guna2Button2).Name = "guna2Button2";
      ((Control) this.guna2Button2).Size = new Size(251, 36);
      ((Control) this.guna2Button2).TabIndex = 7;
      ((Control) this.guna2Button2).Text = "Unbanding";
      this.guna2Button2.UseTransparentBackground = true;
      this.guna2Button1.Animated = true;
      ((Control) this.guna2Button1).BackColor = Color.Transparent;
      this.guna2Button1.BorderRadius = 10;
      this.guna2Button1.FillColor = Color.FromArgb(193, 20, 137);
      ((Control) this.guna2Button1).Font = new Font("Segoe UI", 12f, FontStyle.Bold);
      ((Control) this.guna2Button1).ForeColor = Color.White;
      this.guna2Button1.HoverState.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
      ((Control) this.guna2Button1).Location = new Point(270, 445);
      ((Control) this.guna2Button1).Name = "guna2Button1";
      ((Control) this.guna2Button1).Size = new Size(251, 36);
      ((Control) this.guna2Button1).TabIndex = 6;
      ((Control) this.guna2Button1).Text = "Sign in";
      this.guna2Button1.UseTransparentBackground = true;
      ((Control) this.guna2Button1).Click += new EventHandler(this.guna2Button1_Click);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(310, 404);
      this.label1.Name = "label1";
      this.label1.Size = new Size(91, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Remember me";
      this.guna2ToggleSwitch1.Animated = true;
      this.guna2ToggleSwitch1.Checked = true;
      this.guna2ToggleSwitch1.CheckedState.BorderColor = Color.FromArgb(234, 153, 149);
      this.guna2ToggleSwitch1.CheckedState.FillColor = Color.FromArgb(234, 153, 149);
      this.guna2ToggleSwitch1.CheckedState.InnerBorderColor = Color.FromArgb(218, 1, 88);
      this.guna2ToggleSwitch1.CheckedState.InnerColor = Color.FromArgb(0, 9, 43);
      ((Control) this.guna2ToggleSwitch1).Location = new Point(270, 403);
      ((Control) this.guna2ToggleSwitch1).Name = "guna2ToggleSwitch1";
      ((Control) this.guna2ToggleSwitch1).Size = new Size(35, 18);
      ((Control) this.guna2ToggleSwitch1).TabIndex = 3;
      this.guna2ToggleSwitch1.UncheckedState.BorderColor = Color.FromArgb(234, 153, 149);
      this.guna2ToggleSwitch1.UncheckedState.BorderThickness = 2;
      this.guna2ToggleSwitch1.UncheckedState.FillColor = Color.FromArgb(0, 9, 43);
      this.guna2ToggleSwitch1.UncheckedState.InnerBorderColor = Color.FromArgb(234, 153, 149);
      this.guna2ToggleSwitch1.UncheckedState.InnerColor = Color.FromArgb(234, 153, 149);
      this.guna2TextBox1.Animated = true;
      this.guna2TextBox1.BorderColor = Color.FromArgb(234, 153, 149);
      this.guna2TextBox1.BorderRadius = 6;
      ((Control) this.guna2TextBox1).Cursor = Cursors.IBeam;
      this.guna2TextBox1.DefaultText = "";
      this.guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
      this.guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
      this.guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
      this.guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
      this.guna2TextBox1.FillColor = Color.FromArgb(0, 9, 43);
      this.guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      ((Control) this.guna2TextBox1).Font = new Font("Segoe UI", 9f, FontStyle.Bold);
      this.guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, (int) byte.MaxValue);
      ((Control) this.guna2TextBox1).Location = new Point(270, 348);
      ((Control) this.guna2TextBox1).Name = "guna2TextBox1";
      this.guna2TextBox1.PasswordChar = char.MinValue;
      this.guna2TextBox1.PlaceholderText = "input your Key";
      this.guna2TextBox1.SelectedText = "";
      ((Control) this.guna2TextBox1).Size = new Size(251, 33);
      ((Control) this.guna2TextBox1).TabIndex = 1;
      ((Control) this.guna2PictureBox1).BackColor = Color.Transparent;
      ((PictureBox) this.guna2PictureBox1).Image = (Image) Resources.tesrt;
      this.guna2PictureBox1.ImageRotate = 0.0f;
      ((Control) this.guna2PictureBox1).Location = new Point(92, 57);
      ((Control) this.guna2PictureBox1).Name = "guna2PictureBox1";
      ((Control) this.guna2PictureBox1).Size = new Size(143, 120);
      ((PictureBox) this.guna2PictureBox1).SizeMode = PictureBoxSizeMode.Zoom;
      ((PictureBox) this.guna2PictureBox1).TabIndex = 0;
      ((PictureBox) this.guna2PictureBox1).TabStop = false;
      this.guna2PictureBox1.UseTransparentBackground = true;
      this.guna2ShadowForm1.BorderRadius = 6;
      this.guna2ShadowForm1.ShadowColor = Color.FromArgb(193, 20, 137);
      this.guna2ShadowForm1.TargetForm = (Form) this;
      this.guna2AnimateWindow1.TargetForm = (Form) this;
      ((Control) this.guna2ControlBox2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.guna2ControlBox2.ControlBoxType = (ControlBoxType) 0;
      this.guna2ControlBox2.FillColor = Color.FromArgb(0, 9, 43);
      this.guna2ControlBox2.IconColor = Color.White;
      ((Control) this.guna2ControlBox2).Location = new Point(980, 12);
      ((Control) this.guna2ControlBox2).Name = "guna2ControlBox2";
      ((Control) this.guna2ControlBox2).Size = new Size(35, 26);
      ((Control) this.guna2ControlBox2).TabIndex = 18;
      ((Control) this.guna2ControlBox1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.guna2ControlBox1.FillColor = Color.FromArgb(0, 9, 43);
      this.guna2ControlBox1.HoverState.FillColor = Color.Red;
      this.guna2ControlBox1.IconColor = Color.White;
      ((Control) this.guna2ControlBox1).Location = new Point(1021, 12);
      ((Control) this.guna2ControlBox1).Name = "guna2ControlBox1";
      ((Control) this.guna2ControlBox1).Size = new Size(35, 26);
      ((Control) this.guna2ControlBox1).TabIndex = 17;
      ((Control) this.guna2PictureBox2).BackColor = Color.Transparent;
      ((PictureBox) this.guna2PictureBox2).Image = (Image) Resources.nba24;
      this.guna2PictureBox2.ImageRotate = 0.0f;
      ((Control) this.guna2PictureBox2).Location = new Point(340, -30);
      ((Control) this.guna2PictureBox2).Name = "guna2PictureBox2";
      ((Control) this.guna2PictureBox2).Size = new Size(731, 776);
      ((PictureBox) this.guna2PictureBox2).SizeMode = PictureBoxSizeMode.Zoom;
      ((PictureBox) this.guna2PictureBox2).TabIndex = 19;
      ((PictureBox) this.guna2PictureBox2).TabStop = false;
      this.guna2PictureBox2.UseTransparentBackground = true;
      this.guna2Button3.Animated = true;
      ((Control) this.guna2Button3).BackColor = Color.Transparent;
      this.guna2Button3.BorderRadius = 10;
      this.guna2Button3.FillColor = Color.FromArgb(193, 20, 137);
      ((Control) this.guna2Button3).Font = new Font("Segoe UI", 12f, FontStyle.Bold);
      ((Control) this.guna2Button3).ForeColor = Color.White;
      this.guna2Button3.HoverState.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
      ((Control) this.guna2Button3).Location = new Point(270, 547);
      ((Control) this.guna2Button3).Name = "guna2Button3";
      ((Control) this.guna2Button3).Size = new Size(251, 36);
      ((Control) this.guna2Button3).TabIndex = 28;
      ((Control) this.guna2Button3).Text = "Free trial";
      this.guna2Button3.UseTransparentBackground = true;
      ((Control) this.guna2Button3).Click += new EventHandler(this.guna2Button3_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1068, 702);
      this.Controls.Add((Control) this.guna2ControlBox1);
      this.Controls.Add((Control) this.guna2ControlBox2);
      this.Controls.Add((Control) this.guna2PictureBox2);
      this.Controls.Add((Control) this.guna2Panel2);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (Form1);
      this.Load += new EventHandler(this.Form1_Load);
      this.Paint += new PaintEventHandler(this.Form1_Paint);
      ((Control) this.guna2Panel2).ResumeLayout(false);
      ((Control) this.guna2Panel2).PerformLayout();
      ((ISupportInitialize) this.guna2PictureBox5).EndInit();
      ((ISupportInitialize) this.guna2PictureBox4).EndInit();
      ((ISupportInitialize) this.guna2PictureBox3).EndInit();
      ((ISupportInitialize) this.guna2PictureBox1).EndInit();
      ((ISupportInitialize) this.guna2PictureBox2).EndInit();
      this.ResumeLayout(false);
    }
  }
}
