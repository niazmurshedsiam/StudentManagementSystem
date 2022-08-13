using DAL;
using DAL.Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SchoolManagementSystem.PIMS
{
    public partial class ClassShedule : System.Web.UI.Page
    {
        StudentProfileBll objStuBll = new StudentProfileBll();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                CommonDAL.Fillddl(ddlShift, @"SELECT ShiftId, ShiftName FROM Conf_Shift", "ShiftName", "ShiftId");
                CommonDAL.Fillddl(ddlClass, @"
SELECT SchoolClassId, ClassName FROM Conf_SchoolClass", "ClassName", "SchoolClassId");
                CommonDAL.Fillddl(ddlSubject, @"
select SubjectId,SubjectName from Conf_Subject order by SubjectName asc", "SubjectName", "SubjectId");
            }
        }

      

        //private void Save()
        //{
        //    int save = 0;

        //    EStudentProfile objEStuPro = new EStudentProfile();

        //    objEStuPro.RegSl = int.Parse(hdnRegsl.Value)+1;
        //    objEStuPro.RegistrationNo = txtRegNo.Text;
        //    objEStuPro.RollNo = int.Parse(txtRoll.Text);
        //    objEStuPro.SessionYear = int.Parse(ddlSession.SelectedValue);
        //    objEStuPro.AdmissionDate = Convert.ToDateTime(txtDate.Text);
        //    objEStuPro.Shift = int.Parse(ddlShift.SelectedValue);
        //    objEStuPro.ClassId = int.Parse(ddlClass.SelectedValue);
        //    objEStuPro.StudentId = int.Parse(hdnStuId.Value);
        //    objEStuPro.EntryBy = int.Parse(Session["UserId"].ToString());

        //    save = objStuBll.InsertAdmissionInfo(objEStuPro);
        //    if (save > 0)
        //    {
        //        rmmsg.SuccessMessage = "Save Done";
        //    }
        //}

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            ListAdd();
        }
        private void ListAdd()
        {
           
          

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Shift", typeof(String));dt.Columns.Add(dc);
            dc = new DataColumn("ShiftID", typeof(String));   dt.Columns.Add(dc);
            dc = new DataColumn("Class", typeof(String));   dt.Columns.Add(dc);
            dc = new DataColumn("ClassID", typeof(String));   dt.Columns.Add(dc);
            dc = new DataColumn("WeekDay", typeof(String));  dt.Columns.Add(dc);
            dc = new DataColumn("Subject", typeof(String));  dt.Columns.Add(dc);
            dc = new DataColumn("SubjectId", typeof(String));  dt.Columns.Add(dc);
            dc = new DataColumn("StartTime", typeof(String));  dt.Columns.Add(dc);
            dc = new DataColumn("EndTime", typeof(String));dt.Columns.Add(dc);


            DataRow dr = dt.NewRow();

            if (ViewState["VSCS"] != null)
            {
                DataTable dt2 = (DataTable)ViewState["VSCS"];
            }

            dr[0] = ddlShift.SelectedItem.Text;
            dr[1] = ddlShift.SelectedValue;
            dr[2] = ddlClass.SelectedItem.Text;
            dr[3] = ddlClass.SelectedValue;
            dr[4] = ddlWeekDay.SelectedValue;
            dr[5] = ddlSubject.SelectedItem.Text;
            dr[6] = ddlSubject.SelectedValue;
            dr[7] = txtStartTime.Text;
            dr[8] = txtEndTime.Text;

            dt.Rows.Add(dr);

            gvClassShedule.DataSource = dt;
            gvClassShedule.DataBind();
            ViewState["VSCS"] = dt;

           

        }
    }
}