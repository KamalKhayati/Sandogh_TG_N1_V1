﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using nucs.JsonSettings;
using nucs.JsonSettings.Fluent;

namespace Sandogh_TG
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        //SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().WithEncryption("asdjklasjdkajsd654654").LoadNow();
        SettingsBag Settings { get; } = JsonSettings.Construct<SettingsBag>(AppVariable.fileName + @"\config.json").EnableAutosave().LoadNow();
        public FrmLogin()
        {
            InitializeComponent();
            // فراخوانی پوسته برنامه از مسیر دایرکتوری %appdata%
            try
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Settings[AppVariable.SkinName].ToString() ?? "DevExpress Style");

            }
            catch (Exception)
            {

            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.Karbarans.FirstOrDefault(f => f.Shenase == txtShenase.Text && f.Password == txtPassword.Text);
                    if (q != null)
                    {
                        this.Close();
                        //var q1 = db.RmsUserhaBmsAccessLevelMenuhas.Where(s => s.MsUserId == q.MsUserId).ToList();
                        //if (q1.Count==0)
                        //{
                        //    XtraMessageBox.Show("برای این کاربر هیچگونه سطح دسترسی تعیین نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        //{
                        //    Application.OpenForms[i].Close();
                        //}
                        //return;
                        //}
                        FrmMain fm = new FrmMain();
                        fm.txtUserId.Caption = q.Id.ToString();
                        fm.txtUserName.Caption = q.Name.ToString();
                        fm.txtDateTimeNow.Caption = DateTime.Now.ToString().Substring(0, 10);
                        fm.Show();

                    }
                    else
                    {
                        XtraMessageBox.Show("رمز عبور اشتباه است",
                                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblSystemDate.Text = DateTime.Now.ToString().Substring(0, 10);

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtShenase.Text))
                    {
                        string _Shenase = txtShenase.Text;
                        var q = db.Karbarans.FirstOrDefault(f => f.Shenase == _Shenase);
                        if (q != null)
                        {
                            lblName.Visible = true;
                            lblName.Text = q.Name;
                        }
                        else
                        {
                            XtraMessageBox.Show("شناسه کاربری اشتباه است",
                                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtShenase.Text = "";
                            txtShenase.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}