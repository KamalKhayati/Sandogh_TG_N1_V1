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
using System.Data.Entity;

namespace Sandogh_PG
{
    public partial class FrmVamPardakhti : DevExpress.XtraEditors.XtraForm
    {
        public FrmListVamhayePardakhti Fm;
        public FrmVamPardakhti(FrmListVamhayePardakhti fm)
        {
            InitializeComponent();
            Fm = fm;
        }

        public EnumCED En;
        public int EditRowIndex = 0;
        public int _IDSandogh = 0;
        public bool IsEditRizAghsat = true;
        //public bool ListTasviyeNashode = true;
        public void FillcmbDaryaftkonande()
        {
            using (var db = new MyContext())
            {
                try
                {
                    if (Fm.ListTasviyeNashode)
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.IsActive == true).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            allHesabTafzilisBindingSource.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
                    else
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            allHesabTafzilisBindingSource.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbHesabMoin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q1 = db.CodeMoins.OrderBy(s => s.Code).ToList();
                    if (q1.Count > 0)
                        codeMoinsBindingSource.DataSource = q1;

                    else
                        codeMoinsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillcmbHesabTafzili()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                    var q = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId);

                    if (q != null)
                    {
                        switch (q.Code)
                        {
                            case 1001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "NameHesab";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "NameHesab";
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 2001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "NameVFamil";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "NameVFamil";
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else 
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 3).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 3001:
                                {
                                    goto case 2001;
                                }
                            case 4001:
                                {
                                    goto case 2001;
                                }
                            case 5001:
                                {
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 6).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 6001:
                                {
                                    goto case 2001;
                                }
                            case 6002:
                                {
                                    goto case 2001;
                                }
                            case 6003:
                                {
                                    goto case 2001;
                                }
                            case 7001:
                                {
                                    goto case 2001;
                                }
                            case 8001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "HesabName";
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 4).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
                            case 9001:
                                {
                                    //allHesabTafzilisBindingSource.DisplayMember = "HesabName";
                                    //allHesabTafzilisBindingSource.ValueMember = "Id";
                                    //allHesabTafzilisBindingSource.Columns[1].FieldName = "HesabName";
                                    if (Fm.ListTasviyeNashode)
                                    {
                                        var q1 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5 && f.IsActive == true).OrderBy(s => s.Code).ToList();
                                        if (q1.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q1;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    else if (En == EnumCED.Edit)
                                    {
                                        var q2 = db.AllHesabTafzilis.Where(f => f.GroupTafziliId == 5).OrderBy(s => s.Code).ToList();
                                        if (q2.Count > 0)
                                            allHesabTafzilisBindingSource1.DataSource = q2;
                                        else
                                            allHesabTafzilisBindingSource1.DataSource = null;
                                    }
                                    break;
                                }
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
        public void FillchkcmbEntekhabZamenin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int _DaryaftKonandeId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                    if (Fm.ListTasviyeNashode)
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.IsActive == true && s.Id != _DaryaftKonandeId).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            allHesabTafzilisBindingSource2.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource2.DataSource = null;
                    }
                    else
                    {
                        var q1 = db.AllHesabTafzilis.Where(s => s.GroupTafziliId == 3 && s.Id != _DaryaftKonandeId).OrderBy(s => s.Code).ToList();
                        if (q1.Count > 0)
                            allHesabTafzilisBindingSource2.DataSource = q1;
                        else
                            allHesabTafzilisBindingSource2.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void FillDataGridCheckTazmin()
        {
            using (var db = new MyContext())
            {
                try
                {
                    int AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                    var q1 = db.CheckTazmins.Where(s => s.IsInSandogh == true && s.VamGerandeId == AazaId).OrderBy(s => s.SeryalDaryaft).ToList();
                    if (q1.Count > 0)
                        checkTazminsBindingSource.DataSource = q1;
                    else
                        checkTazminsBindingSource.DataSource = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void NewCode()
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.VamPardakhtis.Select(s => s);
                    if (q.Any())
                    {
                        var MaximumCode = q.Max(p => p.Code);
                        if (MaximumCode.ToString() != "9999999")
                        {
                            txtCode.Text = (MaximumCode + 1).ToString();
                        }
                        else
                        {
                            if (En == EnumCED.Create)
                                XtraMessageBox.Show("اعمال محدودیت 9999999 کد وام  ..." + "\n" +
                                    "توجه : نمیتوان بیشتر از این تعداد، وام پرداختی ثبت نمود ", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        txtCode.Text = "1";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void FrmVamPardakhti_Load(object sender, EventArgs e)
        {
            FillcmbDaryaftkonande();
            FillcmbHesabMoin();
            HelpClass1.DateTimeMask(txtTarikhDarkhast);
            HelpClass1.DateTimeMask(txtTarikhPardakht);
            HelpClass1.DateTimeMask(txtSarresidAvalinGhest);
            _IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
            if (En == EnumCED.Create)
            {
                NewCode();
                cmbNahveyePardakht.SelectedIndex = 0;
                cmbNoeVam.SelectedIndex = 0;
                txtTarikhPardakht.Text = DateTime.Now.ToString().Substring(0, 10);
                cmbFaseleAghsat.SelectedIndex = 0;
                chkIsTasviye.Visible = false;
                using (var db = new MyContext())
                {
                    try
                    {
                        var q2 = db.HesabBankis.FirstOrDefault(s => s.IsActive == true && s.IsDefault == true);
                        if (q2 != null)
                        {
                            var q3 = db.AllHesabTafzilis.FirstOrDefault(f => f.GroupTafziliId == 1 || f.GroupTafziliId == 2 && f.Id2 == q2.Id);
                            if (q3 != null)
                            {
                                cmbHesabMoin.EditValue = 1;
                                cmbHesabTafzili.EditValue = q3.Id;
                            }
                        }
                        var q1 = db.Tanzimats.FirstOrDefault(s => s.Id == _IDSandogh);
                        if (q1 != null)
                        {
                            txtDarsadeKarmozd.Text = q1.DarsadeKarmozd.ToString();
                            txtMablaghDirkard.Text = q1.MablaghDirkard.ToString();
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                            "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                cmbDaryaftkonande.Focus();
            }
            else if (En == EnumCED.Edit)
            {
                //cmbDaryaftkonande.ReadOnly = true;
                EditRowIndex = Fm.gridView1.FocusedRowHandle;
                txtId.Text = Fm.gridView1.GetFocusedRowCellDisplayText("Id");
                cmbDaryaftkonande.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("AazaId"));
                cmbNahveyePardakht.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexNahveyePardakht"));
                cmbNoeVam.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexNoeVam"));
                txtDarsadeKarmozd.Text = Fm.gridView1.GetFocusedRowCellDisplayText("DarsadeKarmozd");
                txtMablaghDirkard.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghDirkard");
                checkEdit1.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("checkEdit1"));
                checkEdit2.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("checkEdit2"));
                if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("TarikhDarkhast")))
                {
                    txtTarikhDarkhast.Text = Fm.gridView1.GetFocusedRowCellDisplayText("TarikhDarkhast").Substring(0, 10);

                }
                txtShomareDarkhast.Text = Fm.gridView1.GetFocusedRowCellDisplayText("ShomareDarkhast");
                txtCode.Text = Fm.gridView1.GetFocusedRowCellDisplayText("Code");
                if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("TarikhPardakht")))
                {
                    txtTarikhPardakht.Text = Fm.gridView1.GetFocusedRowCellDisplayText("TarikhPardakht").Substring(0, 10);

                }
                txtMablaghAsli.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghAsli");
                txtMablaghKarmozd.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghKarmozd");
                cmbFaseleAghsat.SelectedIndex = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("IndexFaseleAghsat"));
                txtTedadAghsat.Text = Fm.gridView1.GetFocusedRowCellDisplayText("TedadAghsat");
                txtMablaghAghsat.Text = Fm.gridView1.GetFocusedRowCellDisplayText("MablaghAghsat");
                if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest")))
                {
                    txtSarresidAvalinGhest.Text = Fm.gridView1.GetFocusedRowCellDisplayText("SarresidAvalinGhest").Substring(0, 10);

                }
                cmbHesabMoin.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("HesabMoinId"));
                cmbHesabTafzili.EditValue = Convert.ToInt32(Fm.gridView1.GetFocusedRowCellValue("HesabTafziliId"));
                lstZamenin.Items.Add(Fm.gridView1.GetFocusedRowCellDisplayText("ZameninName"));
                if (!string.IsNullOrEmpty(Fm.gridView1.GetFocusedRowCellDisplayText("ZameninId")))
                {
                    chkcmbEntekhabZamenin.SetEditValue(Fm.gridView1.GetFocusedRowCellDisplayText("ZameninId"));

                }
                txtTozihat.Text = Fm.gridView1.GetFocusedRowCellDisplayText("Tozihat")!=null? Fm.gridView1.GetFocusedRowCellDisplayText("Tozihat"):null;
                chkIsTasviye.Visible = true;
                chkIsTasviye.Checked = Convert.ToBoolean(Fm.gridView1.GetFocusedRowCellValue("IsTasviye"));
            }
            cmbDaryaftkonande.Focus();
        }

        private void FrmVamPardakhti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSaveClose_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClose_Click(sender, null);
            }

        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(cmbDaryaftkonande.Text))
            {
                XtraMessageBox.Show("لطفا نام دریافت کننده وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbNahveyePardakht.Text))
            {
                XtraMessageBox.Show("لطفاً نحوه پرداخت وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbNoeVam.Text))
            {
                XtraMessageBox.Show("لطفاً نوع وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtCode.Text))
            {
                XtraMessageBox.Show("فیلد کد وام نبایستی خالی باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtTarikhPardakht.Text))
            {
                XtraMessageBox.Show("لطفا تاریخ پرداخت را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtMablaghAsli.Text) || Convert.ToInt32(txtMablaghAsli.Text.Replace(",", "")) == 0)
            {
                XtraMessageBox.Show("لطفا مبلغ اصلی وام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbFaseleAghsat.Text))
            {
                XtraMessageBox.Show("لطفا فاصله اقساط وام را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtTedadAghsat.Text) || Convert.ToInt32(txtTedadAghsat.Text.Replace(",", "")) == 0)
            {
                XtraMessageBox.Show("لطفا تعداد اقساط وام را وارد کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtMablaghAghsat.Text) || Convert.ToInt32(txtMablaghAghsat.Text.Replace(",", "")) == 0)
            {
                XtraMessageBox.Show("مبلغ اقساط تعیین نشده است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtSarresidAvalinGhest.Text))
            {
                XtraMessageBox.Show("لطفا سررسید اولین قسط وام را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(cmbHesabTafzili.Text))
            {
                XtraMessageBox.Show("لطفا نام بانک یا صندوق را انتخاب کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        int _IDSandogh = Convert.ToInt32(Fm.Fm.IDSandogh.Caption);
                        var q = db.Tanzimats.FirstOrDefault(f => f.Id == _IDSandogh).checkEdit1;
                        if (q)
                        {
                            if (chkcmbEntekhabZamenin.Text == string.Empty && checkTazminsBindingSource.DataSource == null)
                            {
                                XtraMessageBox.Show("لطفاً نوع ضمانت وام را مشخص کنید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
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
            return true;
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                int yyyy1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(0, 4));
                int MM1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(5, 2));
                int dd1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(8, 2));
                Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                int yyyy2 = Convert.ToInt32(txtSarresidAvalinGhest.Text.Substring(0, 4));
                int MM2 = Convert.ToInt32(txtSarresidAvalinGhest.Text.Substring(5, 2));
                int dd2 = Convert.ToInt32(txtSarresidAvalinGhest.Text.Substring(8, 2));
                Mydate d2 = new Mydate(yyyy2, MM2, dd2);
                if (d2 < d1 || d2 == d1)
                {
                    XtraMessageBox.Show("تاریخ سررسید اولین قسط بایستی بیشتر از تاریخ پرداخت وام باشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSarresidAvalinGhest.Focus();
                    return;
                }

                int _Code = Convert.ToInt32(txtCode.Text);
                int _Tedad = Convert.ToInt32(txtTedadAghsat.Text);
                //int yyyy1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(0, 4));
                //int MM1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(5, 2));
                //int dd1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(8, 2));
                //Mydate d1 = new Mydate(yyyy1, MM1, dd1);
                decimal _MablaghVam = 0;
                if (checkEdit1.Checked)
                {
                    _MablaghVam = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", ""));
                }
                else if (checkEdit2.Checked)
                {
                    _MablaghVam = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) + Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                }
                decimal _Tafazol = _MablaghVam - (Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) * (_Tedad - 1));
                if (_Tafazol <= 0)
                {
                    XtraMessageBox.Show("جمع مبالغ اقساط بیشتر از مبلغ وام است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var db = new MyContext())
                {
                    try
                    {
                        if (En == EnumCED.Create)
                        {
                            var q1 = db.AsnadeHesabdariRows.Any() ? db.AsnadeHesabdariRows.Max(f => f.ShomareSanad) : 0;
                            VamPardakhti obj = new VamPardakhti();
                            obj.AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                            obj.NameAaza = cmbDaryaftkonande.Text;
                            obj.IndexNahveyePardakht = cmbNahveyePardakht.SelectedIndex;
                            obj.NahveyePardakht = cmbNahveyePardakht.Text;
                            obj.IndexNoeVam = cmbNoeVam.SelectedIndex;
                            obj.NoeVam = cmbNoeVam.Text;
                            obj.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                            obj.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                            obj.checkEdit1 = checkEdit1.Checked ? true : false;
                            obj.checkEdit2 = checkEdit2.Checked ? true : false;
                            if (!string.IsNullOrEmpty(txtTarikhDarkhast.Text))
                                obj.TarikhDarkhast = Convert.ToDateTime(txtTarikhDarkhast.Text.Substring(0, 10));
                            obj.ShomareDarkhast = txtShomareDarkhast.Text;
                            obj.Code = Convert.ToInt32(txtCode.Text);
                            if (!string.IsNullOrEmpty(txtTarikhPardakht.Text))
                                obj.TarikhPardakht = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                            obj.MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                            obj.MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                            obj.IndexFaseleAghsat = cmbFaseleAghsat.SelectedIndex;
                            obj.FaseleAghsat = cmbFaseleAghsat.Text;
                            obj.TedadAghsat = Convert.ToInt32(txtTedadAghsat.Text);
                            obj.MablaghAghsat = !string.IsNullOrEmpty(txtMablaghAghsat.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : 0;
                            if (!string.IsNullOrEmpty(txtSarresidAvalinGhest.Text))
                                obj.SarresidAvalinGhest = Convert.ToDateTime(txtSarresidAvalinGhest.Text.Substring(0, 10));
                            obj.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                            obj.HesabMoinName = cmbHesabMoin.Text;
                            obj.HesabTafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                            obj.HesabTafziliName = cmbHesabTafzili.Text;
                            if (!string.IsNullOrEmpty(chkcmbEntekhabZamenin.Text))
                            {
                                obj.ZameninName = chkcmbEntekhabZamenin.Text;

                                string CheckedItems = string.Empty;
                                var CheckedList = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                if (CheckedList != null)
                                {
                                    foreach (var item in CheckedList)
                                    {
                                        CheckedItems += item.ToString() + ",";
                                    }
                                }
                                obj.ZameninId = CheckedItems;
                            }
                            else
                            {
                                obj.ZameninName = null;
                                obj.ZameninId = null;
                            }
                            obj.HaveCheckTazmin = checkTazminsBindingSource.DataSource != null ? true : false;
                            obj.IsTasviye = chkIsTasviye.Checked ? true : false;
                            obj.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            obj.ShomareSanad = q1 + 1;
                            obj.Tozihat = txtTozihat.Text;
                            db.VamPardakhtis.Add(obj);
                            db.SaveChanges();
                            //////////////////////////////////////////////////////////////////////////////////////
                            int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                            var _q2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabAazaId2);
                            var _q1 = db.CodeMoins.FirstOrDefault(f => f.Code == 2001);
                            AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                            obj2.ShomareSanad = q1 + 1;
                            obj2.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                            obj2.HesabMoinId = _q1.Id;
                            obj2.HesabMoinCode = 2001;
                            obj2.HesabMoinName = _q1.Name;
                            obj2.HesabTafId = _HesabAazaId2;
                            obj2.HesabTafCode = _q2.Code;
                            obj2.HesabTafName = cmbDaryaftkonande.Text;
                            obj2.Bed = _MablaghVam;
                            obj2.Sharh = "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                            obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj2);
                            db.SaveChanges();

                            int _HesabMoinId1 = Convert.ToInt32(cmbHesabMoin.EditValue);
                            var _q3 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                            int _HesabTafId1 = Convert.ToInt32(cmbHesabTafzili.EditValue);
                            var _q4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                            AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                            obj1.ShomareSanad = q1 + 1;
                            obj1.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                            obj1.HesabMoinId = _HesabMoinId1;
                            obj1.HesabMoinCode = _q3.Code;
                            obj1.HesabMoinName = cmbHesabMoin.Text;
                            obj1.HesabTafId = _HesabTafId1;
                            obj1.HesabTafCode = _q4.Code;
                            obj1.HesabTafName = cmbHesabTafzili.Text;
                            obj1.Bes = _MablaghVam - Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                            obj1.Sharh = _q3.Code == 1001 ? "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text :
                                "بابت اختصاص وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                            obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                            db.AsnadeHesabdariRows.Add(obj1);
                            //if (_q3.Code == 6001)
                            //    XtraMessageBox.Show("مبلغ وام به حساب وام پرداختنی منظور شد تا بعداً به وام گیرنده پرداخت شود", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.SaveChanges();


                            if (Convert.ToInt32(txtMablaghKarmozd.Text.Replace(",", "")) != 0)
                            {
                                var _q5 = db.CodeMoins.FirstOrDefault(f => f.Code == 8001);
                                var _q6 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == 1000001);
                                AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                                obj3.ShomareSanad = q1 + 1;
                                obj3.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                obj3.HesabMoinId = _q5.Id;
                                obj3.HesabMoinCode = 8001;
                                obj3.HesabMoinName = _q5.Name;
                                obj3.HesabTafId = _q6.Id;
                                obj3.HesabTafCode = 1000001;
                                obj3.HesabTafName = _q6.Name;
                                obj3.Bes = Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                obj3.Sharh = "بابت کارمزد وام شماره " + txtCode.Text + " " + cmbDaryaftkonande.Text;
                                obj3.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                db.AsnadeHesabdariRows.Add(obj3);
                            }
                            db.SaveChanges();

                            Fm.btnDisplyActiveList1_Click(null, null);

                            /////////////////////////////////////////////////////////////////////////////////////////////////////////
                            if (XtraMessageBox.Show("آیا قسط بندی وام انجام شود؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                var q2 = db.VamPardakhtis.FirstOrDefault(s => s.Code == _Code);
                                Fm._VamPardakhtiId = q2.Id;
                                if (cmbFaseleAghsat.SelectedIndex == 0)
                                {
                                    for (int i = 1; i <= _Tedad; i++)
                                    {
                                        RizeAghsatVam ct = new RizeAghsatVam();
                                        ct.ShomareGhest = i;
                                        ct.AazaId = _HesabAazaId2;
                                        ct.NameAaza = cmbDaryaftkonande.Text;
                                        ct.VamPardakhtiId = q2.Id;
                                        ct.VamPardakhtiCode = _Code;
                                        if (i != 1)
                                            d2.IncrementMonth();
                                        ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                        ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                        ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        db.RizeAghsatVams.Add(ct);
                                    }
                                }
                                else if (cmbFaseleAghsat.SelectedIndex == 1)
                                {
                                    for (int i = 1; i <= _Tedad; i++)
                                    {
                                        RizeAghsatVam ct = new RizeAghsatVam();
                                        ct.ShomareGhest = i;
                                        ct.AazaId = _HesabAazaId2;
                                        ct.NameAaza = cmbDaryaftkonande.Text;
                                        ct.VamPardakhtiId = q2.Id;
                                        ct.VamPardakhtiCode = _Code;
                                        if (i != 1)
                                            d2.IncrementYear();
                                        ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                        ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                        ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        db.RizeAghsatVams.Add(ct);
                                    }
                                }
                                db.SaveChanges();
                            }
                            /////////////////////////////////////////////////////////////////////////////////////////////////////////
                            En = EnumCED.Save;
                            //if (Fm.ListTasviyeNashode)
                            //else
                            //    Fm.btnDisplyNotActiveList1_Click(null, null);
                            Fm.FillDataGridRizeAghsatVam();
                            Fm.gridView1.MoveLast();
                            XtraMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else if (En == EnumCED.Edit)
                        {
                            int RowId = Convert.ToInt32(txtId.Text);
                            var q = db.VamPardakhtis.FirstOrDefault(s => s.Id == RowId);
                            if (q != null)
                            {
                                if (Fm.ListTasviyeNashode == true && chkIsTasviye.Checked == false)
                                {
                                    q.AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                    q.NameAaza = cmbDaryaftkonande.Text;
                                    q.IndexNahveyePardakht = cmbNahveyePardakht.SelectedIndex;
                                    q.NahveyePardakht = cmbNahveyePardakht.Text;
                                    q.IndexNoeVam = cmbNoeVam.SelectedIndex;
                                    q.NoeVam = cmbNoeVam.Text;
                                    q.DarsadeKarmozd = !string.IsNullOrEmpty(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) ? Convert.ToSingle(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) : 0;
                                    q.MablaghDirkard = !string.IsNullOrEmpty(txtMablaghDirkard.Text.Replace(",", "")) ? Convert.ToInt32(txtMablaghDirkard.Text.Replace(",", "")) : 0;
                                    q.checkEdit1 = checkEdit1.Checked ? true : false;
                                    q.checkEdit2 = checkEdit2.Checked ? true : false;
                                    if (!string.IsNullOrEmpty(txtTarikhDarkhast.Text))
                                        q.TarikhDarkhast = Convert.ToDateTime(txtTarikhDarkhast.Text.Substring(0, 10));
                                    q.ShomareDarkhast = txtShomareDarkhast.Text;
                                    q.Code = Convert.ToInt32(txtCode.Text);
                                    if (!string.IsNullOrEmpty(txtTarikhPardakht.Text))
                                        q.TarikhPardakht = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                    q.MablaghAsli = !string.IsNullOrEmpty(txtMablaghAsli.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) : 0;
                                    q.MablaghKarmozd = !string.IsNullOrEmpty(txtMablaghKarmozd.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", "")) : 0;
                                    q.IndexFaseleAghsat = cmbFaseleAghsat.SelectedIndex;
                                    q.FaseleAghsat = cmbFaseleAghsat.Text;
                                    q.TedadAghsat = Convert.ToInt32(txtTedadAghsat.Text);
                                    q.MablaghAghsat = !string.IsNullOrEmpty(txtMablaghAghsat.Text.Replace(",", "")) ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : 0;
                                    if (!string.IsNullOrEmpty(txtSarresidAvalinGhest.Text))
                                        q.SarresidAvalinGhest = Convert.ToDateTime(txtSarresidAvalinGhest.Text.Substring(0, 10));
                                    q.HesabMoinId = Convert.ToInt32(cmbHesabMoin.EditValue);
                                    q.HesabMoinName = cmbHesabMoin.Text;
                                    q.HesabTafziliId = Convert.ToInt32(cmbHesabTafzili.EditValue);
                                    q.HesabTafziliName = cmbHesabTafzili.Text;
                                    if (!string.IsNullOrEmpty(chkcmbEntekhabZamenin.Text))
                                    {
                                        q.ZameninName = chkcmbEntekhabZamenin.Text;

                                        string CheckedItems = string.Empty;
                                        var CheckedList = chkcmbEntekhabZamenin.Properties.GetItems().GetCheckedValues();
                                        if (CheckedList != null)
                                        {
                                            foreach (var item in CheckedList)
                                            {
                                                CheckedItems += item.ToString() + ",";
                                            }
                                        }
                                        q.ZameninId = CheckedItems;
                                    }
                                    else
                                    {
                                        q.ZameninName = null;
                                        q.ZameninId = null;
                                    }
                                    q.HaveCheckTazmin = checkTazminsBindingSource.DataSource != null ? true : false;
                                    q.IsTasviye = chkIsTasviye.Checked ? true : false;
                                    q.Tozihat = txtTozihat.Text;
                                    ////////////////////////////////////////////////////////////////////////////////////////////
                                    if (IsEditRizAghsat)
                                    {
                                        var q2 = db.AsnadeHesabdariRows.Where(f => f.ShomareSanad == q.ShomareSanad);
                                        if (q2.Count() > 0)
                                            db.AsnadeHesabdariRows.RemoveRange(q2);

                                        //////////////////////////////////////////////////////////////////////////////////////
                                        int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                        var _q2 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabAazaId2);
                                        var _q1 = db.CodeMoins.FirstOrDefault(f => f.Code == 2001);
                                        AsnadeHesabdariRow obj2 = new AsnadeHesabdariRow();
                                        obj2.ShomareSanad = q.ShomareSanad;
                                        obj2.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                        obj2.HesabMoinId = _q1.Id;
                                        obj2.HesabMoinCode = 2001;
                                        obj2.HesabMoinName = _q1.Name;
                                        obj2.HesabTafId = _HesabAazaId2;
                                        obj2.HesabTafCode = _q2.Code;
                                        obj2.HesabTafName = cmbDaryaftkonande.Text;
                                        obj2.Bed = _MablaghVam;
                                        obj2.Sharh = "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                                        obj2.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        db.AsnadeHesabdariRows.Add(obj2);

                                        int _HesabMoinId1 = Convert.ToInt32(cmbHesabMoin.EditValue);
                                        var _q3 = db.CodeMoins.FirstOrDefault(f => f.Id == _HesabMoinId1);
                                        int _HesabTafId1 = Convert.ToInt32(cmbHesabTafzili.EditValue);
                                        var _q4 = db.AllHesabTafzilis.FirstOrDefault(f => f.Id == _HesabTafId1);
                                        AsnadeHesabdariRow obj1 = new AsnadeHesabdariRow();
                                        obj1.ShomareSanad = q.ShomareSanad;
                                        obj1.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                        obj1.HesabMoinId = _HesabMoinId1;
                                        obj1.HesabMoinCode = _q3.Code;
                                        obj1.HesabMoinName = cmbHesabMoin.Text;
                                        obj1.HesabTafId = _HesabTafId1;
                                        obj1.HesabTafCode = _q4.Code;
                                        obj1.HesabTafName = cmbHesabTafzili.Text;
                                        obj1.Bes = _MablaghVam - Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                        obj1.Sharh = _q3.Code == 1001 ? "بابت پرداخت وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text :
                                            "بابت اختصاص وام شماره " + txtCode.Text + " به " + cmbDaryaftkonande.Text;
                                        obj1.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                        db.AsnadeHesabdariRows.Add(obj1);
                                        //if (_q3.Code == 6001)
                                        //    XtraMessageBox.Show("مبلغ وام به حساب وام پرداختنی منظور شد تا بعداً به وام گیرنده پرداخت شود", "پیغام ثبت ", MessageBoxButtons.OK);

                                        if (Convert.ToInt32(txtMablaghKarmozd.Text.Replace(",", "")) != 0)
                                        {
                                            var _q5 = db.CodeMoins.FirstOrDefault(f => f.Code == 8001);
                                            var _q6 = db.AllHesabTafzilis.FirstOrDefault(f => f.Code == 1000001);
                                            AsnadeHesabdariRow obj3 = new AsnadeHesabdariRow();
                                            obj3.ShomareSanad = q.ShomareSanad;
                                            obj3.Tarikh = Convert.ToDateTime(txtTarikhPardakht.Text.Substring(0, 10));
                                            obj3.HesabMoinId = _q5.Id;
                                            obj3.HesabMoinCode = 8001;
                                            obj3.HesabMoinName = _q5.Name;
                                            obj3.HesabTafId = _q6.Id;
                                            obj3.HesabTafCode = 1000001;
                                            obj3.HesabTafName = _q6.Name;
                                            obj3.Bes = Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                            obj3.Sharh = "بابت کارمزد وام شماره " + txtCode.Text + " " + cmbDaryaftkonande.Text;
                                            obj3.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                            db.AsnadeHesabdariRows.Add(obj3);
                                        }

                                    }
                                    db.SaveChanges();

                                    if (Fm.ListTasviyeNashode)
                                        Fm.btnDisplyActiveList1_Click(null, null);
                                    else
                                        Fm.btnDisplyNotActiveList1_Click(null, null);

                                    /////////////////////////////////////////////////////////////////////////////////////////////////////////
                                    if (IsEditRizAghsat == true)
                                    {
                                        if (XtraMessageBox.Show("آیا قسط بندی وام مجدداً انجام شود؟", "پیغام ثبت ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                        {

                                            var q3 = db.RizeAghsatVams.Where(s => s.VamPardakhtiId == RowId);
                                            if (q3.Count() > 0)
                                            {
                                                db.RizeAghsatVams.RemoveRange(q3);
                                            }
                                            /////////////////////////////////////////////////////////////////
                                            int _HesabAazaId2 = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                            var q4 = db.VamPardakhtis.FirstOrDefault(s => s.Code == _Code);
                                            Fm._VamPardakhtiId = q4.Id;
                                            if (cmbFaseleAghsat.SelectedIndex == 0)
                                            {
                                                for (int i = 1; i <= _Tedad; i++)
                                                {
                                                    RizeAghsatVam ct = new RizeAghsatVam();
                                                    ct.ShomareGhest = i;
                                                    ct.AazaId = _HesabAazaId2;
                                                    ct.NameAaza = cmbDaryaftkonande.Text;
                                                    ct.VamPardakhtiId = q4.Id;
                                                    ct.VamPardakhtiCode = _Code;
                                                    if (i != 1)
                                                        d2.IncrementMonth();
                                                    ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                    ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                                    ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                    db.RizeAghsatVams.Add(ct);
                                                }
                                            }
                                            else if (cmbFaseleAghsat.SelectedIndex == 1)
                                            {
                                                for (int i = 1; i <= _Tedad; i++)
                                                {
                                                    RizeAghsatVam ct = new RizeAghsatVam();
                                                    ct.ShomareGhest = i;
                                                    ct.AazaId = _HesabAazaId2;
                                                    ct.NameAaza = cmbDaryaftkonande.Text;
                                                    ct.VamPardakhtiId = q4.Id;
                                                    ct.VamPardakhtiCode = _Code;
                                                    if (i != 1)
                                                        d2.IncrementYear();
                                                    ct.TarikhSarresid = Convert.ToDateTime(d2.ToString());
                                                    ct.MablaghAghsat = i != _Tedad ? Convert.ToDecimal(txtMablaghAghsat.Text.Replace(",", "")) : _Tafazol;
                                                    ct.SalMaliId = Convert.ToInt32(Fm.Fm.IDSalMali.Caption);
                                                    db.RizeAghsatVams.Add(ct);
                                                }
                                            }
                                        }
                                    }

                                }
                                else if (Fm.ListTasviyeNashode == true && chkIsTasviye.Checked == true)
                                {
                                    q.IsTasviye = chkIsTasviye.Checked;
                                }
                                else if (Fm.ListTasviyeNashode == false)
                                {
                                    q.IsTasviye = chkIsTasviye.Checked;
                                }
                                db.SaveChanges();
                                /////////////////////////////////////////////////////////////////////////////////////////////////////////

                                En = EnumCED.Save;
                                Fm._VamPardakhtiId = RowId;
                                Fm.FillDataGridRizeAghsatVam();
                                if (Fm.gridView1.RowCount > 0)
                                    Fm.gridView1.FocusedRowHandle = EditRowIndex;
                                XtraMessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پیغام ثبت ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message, "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            En = EnumCED.Cancel;
            this.Close();
        }

        private void FrmVamPardakhti_FormClosing(object sender, FormClosingEventArgs e)
        {
            En = EnumCED.Cancel;
        }

        public string MohasebeKarmozd()
        {
            string Result = "";
            if (!string.IsNullOrEmpty(txtMablaghAsli.Text) && Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) != 0)
            {
                if (!string.IsNullOrEmpty(txtDarsadeKarmozd.Text) && Convert.ToDecimal(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) != 0)
                {
                    decimal d = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) * (Convert.ToDecimal(txtDarsadeKarmozd.Text.Replace("/", ".").Replace(",", "")) / 100);
                    Result = Math.Truncate(d).ToString();
                }
                else
                    Result = "0";
            }
            else
                Result = "0";

            return Result;
        }
        public string MohasebeMablaghAgsat()
        {
            string Result = "";
            using (var db = new MyContext())
            {
                try
                {
                    if (checkEdit1.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtMablaghAsli.Text) && Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) != 0)
                        {
                            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && Convert.ToInt32(txtTedadAghsat.Text) != 0)
                            {
                                decimal d = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) / Convert.ToInt32(txtTedadAghsat.Text);
                                Result = Math.Truncate(d).ToString();
                            }
                            else
                                Result = "0";
                        }
                        else
                            Result = "0";
                    }
                    else if (checkEdit2.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtMablaghAsli.Text) && Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) != 0)
                        {
                            if (!string.IsNullOrEmpty(txtTedadAghsat.Text) && Convert.ToInt32(txtTedadAghsat.Text) != 0)
                            {
                                decimal Sum = Convert.ToDecimal(txtMablaghAsli.Text.Replace(",", "")) + Convert.ToDecimal(txtMablaghKarmozd.Text.Replace(",", ""));
                                decimal d = Sum / Convert.ToInt32(txtTedadAghsat.Text);
                                Result = Math.Truncate(d).ToString();
                            }
                            else
                                Result = "0";
                        }
                        else
                            Result = "0";
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("عملیات با خطا مواجه شد" + "\n" + ex.Message,
                        "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Result;
        }
        private void txtMablaghAsli_EditValueChanged(object sender, EventArgs e)
        {
            txtMablaghKarmozd.Text = MohasebeKarmozd();
            txtMablaghAghsat.Text = MohasebeMablaghAgsat();
        }

        private void txtDarsadeKarmozd_EditValueChanged(object sender, EventArgs e)
        {
            txtMablaghKarmozd.Text = MohasebeKarmozd();

        }

        private void txtTedadAghsat_EditValueChanged(object sender, EventArgs e)
        {
            txtMablaghAghsat.Text = MohasebeMablaghAgsat();
        }

        private void txtMablaghKarmozd_EditValueChanged(object sender, EventArgs e)
        {
            txtMablaghAghsat.Text = MohasebeMablaghAgsat();

        }

        private void cmbFaseleAghsat_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTarikhPardakht.Text))
            {
                int yyyy1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(0, 4));
                int MM1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(5, 2));
                int dd1 = Convert.ToInt32(txtTarikhPardakht.Text.Substring(8, 2));
                Mydate d1 = null;
                if (cmbFaseleAghsat.SelectedIndex == 0)
                {
                    d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.IncrementMonth();
                }
                else if (cmbFaseleAghsat.SelectedIndex == 1)
                {
                    d1 = new Mydate(yyyy1, MM1, dd1);
                    d1.IncrementYear();
                }
                txtSarresidAvalinGhest.Text = d1.ToString();
            }
        }

        private void chkcmbAazaSandoogh_EditValueChanged(object sender, EventArgs e)
        {
            lstZamenin.Items.Clear();
            lstZamenin.Items.Add(chkcmbEntekhabZamenin.Text);

        }

        private void cmbDaryaftkonande_EditValueChanged(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
            {
                using (var db = new MyContext())
                {
                    try
                    {
                        var q = db.Tanzimats.FirstOrDefault(s => s.Id == _IDSandogh);
                        if (q != null)
                        {
                            if (q.checkEdit2)
                            {
                                int _AazaId = Convert.ToInt32(cmbDaryaftkonande.EditValue);
                                var q1 = db.VamPardakhtis.FirstOrDefault(s => s.IsTasviye == false && s.AazaId == _AazaId);
                                if (q1 != null)
                                {
                                    XtraMessageBox.Show("عضو انتخابی وام تسویه نشده قبلی دارد لذا اعطای وام مجدد به ایشان مقدور نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    cmbDaryaftkonande.EditValue = 0;
                                    cmbDaryaftkonande_Enter(null, null);
                                    return;
                                }
                                //if (Fm.gridView1.RowCount > 0)
                                //{
                                //    List<int> ListAazaId = new List<int>();
                                //    for (int i = 0; i < Fm.gridView1.RowCount; i++)
                                //    {
                                //        ListAazaId.Add(Convert.ToInt32(Fm.gridView1.GetRowCellValue(i, "AazaId")));
                                //        if (ListAazaId[i] == _AazaId)
                                //        {
                                //            XtraMessageBox.Show("عضو انتخابی وام تسویه نشده قبلی دارد لذا اعطای وام مجدد به ایشان مقدور نیست", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //            cmbDaryaftkonande.EditValue = 0;
                                //            return;
                                //        }
                                //    }
                                //}

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
            FillchkcmbEntekhabZamenin();
            FillDataGridCheckTazmin();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
                checkEdit2.Checked = false;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked)
                checkEdit1.Checked = false;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnCreate.Visible = xtraTabControl1.SelectedTabPageIndex == 1 ? true : false;
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            FrmDaryaftCheckTazmin fm = new FrmDaryaftCheckTazmin(this);
            fm.ShowDialog();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            HelpClass1.SetNumberRowsColumnUnboundGirdView(sender, e);

        }

        private void cmbDaryaftkonande_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
                cmbDaryaftkonande.ShowPopup();
        }

        private void cmbHesabMoin_EditValueChanged(object sender, EventArgs e)
        {
            FillcmbHesabTafzili();
        }

        private void cmbNahveyePardakht_Enter(object sender, EventArgs e)
        {
            cmbNahveyePardakht.ShowPopup();
        }

        private void cmbNoeVam_Enter(object sender, EventArgs e)
        {
            cmbNoeVam.ShowPopup();
        }

        private void cmbFaseleAghsat_Enter(object sender, EventArgs e)
        {
            cmbFaseleAghsat.ShowPopup();
        }

        private void cmbHesabMoin_Enter(object sender, EventArgs e)
        {
            cmbHesabMoin.ShowPopup();
        }

        private void cmbHesabTafzili_Enter(object sender, EventArgs e)
        {
            cmbHesabTafzili.ShowPopup();
        }

        private void chkcmbEntekhabZamenin_Enter(object sender, EventArgs e)
        {
            if (En == EnumCED.Create)
                chkcmbEntekhabZamenin.ShowPopup();
        }

        private void txtMablaghAsli_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpClass1.AddZerooToTextBox(sender, e);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var q = db.VamPardakhtis.Max(s => s.ShomareDarkhast);
                    if (!string.IsNullOrEmpty(q))
                    {
                        txtShomareDarkhast.Text = (Convert.ToInt32(q) + 1).ToString();
                    }
                    else
                        txtShomareDarkhast.Text = "1";
                    txtTarikhPardakht.Focus();

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