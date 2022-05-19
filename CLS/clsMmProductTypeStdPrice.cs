using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using cf01.MDL;

namespace cf01.CLS
{
    public class clsMmProductTypeStdPrice
    {
        private static string userid = DBUtility._user_id.ToUpper();
        public static DataTable LoadProductType(string ID)
        {
            string strSql = "";
            strSql = "Select ID,Ver,ArtWork,ProductType,CreateUser,Convert(Varchar(50),CreateTime,20) AS CreateTime"+
                ",AmendUser,Convert(Varchar(50),AmendTime,20) AS AmendTime,SN" +
                " From mm_ProductTypePrice " +
                " Where ID='" + ID + "'";
            DataTable dtProductType = clsPublicOfCF01.GetDataTable(strSql);
            return dtProductType;
        }
        public static DataTable LoadSizeDetails(int UpperSN)
        {
            string strSql = "";
            strSql = "Select a.UpperSN,a.Seq,a.SizeID,b.size_cdesc AS SizeName,a.SN " +
                " From mm_ProductTypePriceSize a" +
                " Left Join bs_size b On a.SizeID=b.size_id " +
                " Where a.UpperSN='" + UpperSN + "'";
            DataTable dtSizeDetails= clsPublicOfCF01.GetDataTable(strSql);
            return dtSizeDetails;
        }
        public static DataTable LoadColorGroup(int UpperSN)
        {
            string strSql = "";
            strSql = "Select UpperSN,Seq,ColorGroup,ValueDesc,Price,Curr,SN" +
                " From mm_ProductTypePriceColorGroup" +
                " Where UpperSN='" + UpperSN + "'";
            DataTable dtColorGroup = clsPublicOfCF01.GetDataTable(strSql);
            return dtColorGroup;
        }
        public static DataTable LoadColorDetails(int UpperSN)
        {
            string strSql = "";
            strSql = "Select a.UpperSN,a.Seq,a.ColorID,a.ColorName" +
                " From mm_ProductTypePriceColorDetails a" +
                " Where a.UpperSN='" + UpperSN + "'";
            DataTable dtColorGroup = clsPublicOfCF01.GetDataTable(strSql);
            return dtColorGroup;
        }
        public static string Save(mdlProductTypePrice mdlPtp)
        {
            string result = "";
            string ID = mdlPtp.ID;
            string strSql = "";
            int Ver = mdlPtp.Ver;
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (ID=="")
            {
                ID = GenID();
            }
            if (!CheckID(ID))
            {
                Ver = 0;
                strSql += string.Format(@" Insert Into mm_ProductTypePrice(ID,Ver,ArtWork,ProductType,CreateUser,CreateTime)" +
                        " Values ('{0}','{1}','{2}','{3}','{4}',GETDATE() )"
                        , ID, Ver, mdlPtp.ArtWork, mdlPtp.ProductType, userid);
            }
            else
                strSql += string.Format(@" Update mm_ProductTypePrice Set ArtWork='{2}',ProductType='{3}'" +
                    ",AmendUser='{4}',AmendTime=GETDATE()" +
                    " Where ID='{0}' And Ver='{1}'"
                    , ID, Ver, mdlPtp.ArtWork, mdlPtp.ProductType, userid);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = ID;
            return result;
        }

        //public static string SaveSize(List<mdlProductTypePriceSize> lsMtps)
        //{
        //    string result = "";
        //    string strSql = "";
        //    string ID = lsMtps[0].ID;
        //    int Ver = lsMtps[0].Ver;
        //    strSql += string.Format(@" SET XACT_ABORT  ON ");
        //    strSql += string.Format(@" BEGIN TRANSACTION ");
        //    string MaxSeq = "";
        //    //獲取已存在的最大序號
        //    for (int i = 0; i < lsMtps.Count; i++)
        //    {
        //        MaxSeq = string.Compare(MaxSeq, lsMtps[i].Seq) >= 0 ? MaxSeq : lsMtps[i].Seq;
        //    }
        //    int MaxSeqInt = Convert.ToInt32(MaxSeq);
        //    for (int i = 0; i < lsMtps.Count; i++)
        //    {
        //        string Seq = lsMtps[i].Seq;
        //        //最大序號 + 1
        //        if (Seq == "")
        //            Seq = ((MaxSeqInt + i) - 1).ToString().PadLeft(3, '0');
        //        if (!CheckExistSize(ID, Seq))
        //            strSql += string.Format(@" Insert Into mm_ProductTypePriceSize(ID,Ver,Seq,SizeID)" +
        //                    " Values ('{0}','{1}','{2}','{3}' )"
        //                    , ID, Ver, Seq, lsMtps[i].SizeID);
        //        else
        //            strSql += string.Format(@" Update mm_ProductTypePriceSize Set SizeID='{3}'" +
        //                " Where ID='{0}' And Ver='{1}' And Seq='{2}'"
        //                , ID, Ver, Seq, lsMtps[i].SizeID);
        //    }
        //    strSql += string.Format(@" COMMIT TRANSACTION ");
        //    result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
        //    if (result == "")
        //        result = lsMtps[0].ID;
        //    return result;
        //}

        public static string SaveSize(mdlProductTypePriceSize mdlPtps)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (!CheckExistRecord("mm_ProductTypePriceSize",mdlPtps.UpperSN, mdlPtps.Seq))
                strSql += string.Format(@" Insert Into mm_ProductTypePriceSize(UpperSN,Seq,SizeID)" +
                        " Values ('{0}','{1}','{2}' )"
                        , mdlPtps.UpperSN, mdlPtps.Seq, mdlPtps.SizeID);
            else
                strSql += string.Format(@" Update mm_ProductTypePriceSize Set SizeID='{2}'" +
                    " Where UpperSN='{0}' And Seq='{1}'"
                    , mdlPtps.UpperSN, mdlPtps.Seq, mdlPtps.SizeID);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static string SaveColorGroup(mdlProductTypePriceColorGroup mdlMtpcg)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (!CheckExistRecord("mm_ProductTypePriceColorGroup",mdlMtpcg.UpperSN, mdlMtpcg.Seq))
                strSql += string.Format(@" Insert Into mm_ProductTypePriceColorGroup" +
                        " (UpperSN,Seq,ColorGroup,ValueDesc,Price,Curr)" +
                        " Values ('{0}','{1}','{2}','{3}','{4}','{5}' )"
                        , mdlMtpcg.UpperSN, mdlMtpcg.Seq, mdlMtpcg.ColorGroup
                        , mdlMtpcg.ValueDesc, mdlMtpcg.Price, mdlMtpcg.Curr);
            else
                strSql += string.Format(@" Update mm_ProductTypePriceColorGroup Set ColorGroup='{2}',ValueDesc='{3}',Price='{4}',Curr='{5}'" +
                    " Where UpperSN='{0}'  And Seq='{1}'"
                    , mdlMtpcg.UpperSN, mdlMtpcg.Seq, mdlMtpcg.ColorGroup
                    , mdlMtpcg.ValueDesc, mdlMtpcg.Price, mdlMtpcg.Curr);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        private static string GenID()
        {
            string result = "";
            string strSql = "";
            strSql += " Select Max(ID) AS ID From mm_ProductTypePrice ";
            DataTable dtID  = clsPublicOfCF01.GetDataTable(strSql);
            if (dtID.Rows[0]["ID"].ToString() == "")
                result = "P" + "00001";
            else
                result = "P" + (Convert.ToInt32(dtID.Rows[0]["ID"].ToString().Substring(1, 5)) + 1).ToString().PadLeft(5,'0');
            return result;
        }
        private static bool CheckID(string ID)
        {
            bool result = false;
            string strSql = "";
            strSql += " Select ID From mm_ProductTypePrice Where ID='" + ID + "'";
            DataTable dtID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtID.Rows.Count > 0)
                result = true;
            return result;
        }
        private static bool CheckExistRecord(string tbName,int UpperSN, string Seq)
        {
            bool result = false;
            string strSql = "";
            strSql += " Select UpperSN From " + tbName + " Where UpperSN='" + UpperSN + "' And Seq='" + Seq + "'";
            DataTable dtID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtID.Rows.Count > 0)
                result = true;
            return result;
        }
        public static string SaveColorDetails(mdlProductTypePriceColorDetails mdlPtpcd)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (!CheckExistRecord("mm_ProductTypePriceColorDetails", mdlPtpcd.UpperSN, mdlPtpcd.Seq))
                strSql += string.Format(@" Insert Into mm_ProductTypePriceColorDetails " +
                        " (UpperSN,Seq,ColorID,ColorName)" +
                        " Values ('{0}','{1}','{2}','{3}' )"
                        , mdlPtpcd.UpperSN, mdlPtpcd.Seq, mdlPtpcd.ColorID, mdlPtpcd.ColorName);
            else
                strSql += string.Format(@" Update mm_ProductTypePriceColorDetails Set ColorID='{2}',ColorName='{3}'" +
                    " Where UpperSN='{0}'  And Seq='{1}'"
                    , mdlPtpcd.UpperSN, mdlPtpcd.Seq, mdlPtpcd.ColorID, mdlPtpcd.ColorName);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }
        public static DataTable GetSize(string SizeID)
        {
            string strSql = "";
            strSql += " Select size_id,size_cdesc AS SizeName" +
                " From bs_size Where size_id='" + SizeID + "'";
            DataTable dtSize = clsPublicOfCF01.GetDataTable(strSql);
            return dtSize;
        }
        public static DataTable GetColor(string ColorID)
        {
            string strSql = "";
            strSql += " Select clr_code,clr_cdesc AS ColorName" +
                " From bs_color Where clr_code='" + ColorID + "'";
            DataTable dtSize = clsPublicOfCF01.GetDataTable(strSql);
            return dtSize;
        }
        public static DataTable FindData(string ArtWork,string ProductType,string SizeName)
        {
            string strSql = "";
            strSql = "Select a.ID,a.Ver,a.ArtWork,a.ProductType,a.CreateUser,Convert(Varchar(50),a.CreateTime,20) AS CreateTime" +
                ",a.AmendUser,Convert(Varchar(50),a.AmendTime,20) AS AmendTime,a.SN" +
                ",b.Seq AS SizeSeq,b.SizeID,c.size_cdesc AS SizeName,b.SN AS SizeSN " +
                " From mm_ProductTypePrice a " +
                " Left Join mm_ProductTypePriceSize b On a.SN=b.UpperSN " +
                " Left Join bs_size c On b.SizeID=c.size_id " +
                " Where a.ID>=''";
            if(ArtWork!="")
                strSql+= " And a.ArtWork Like '%" + ArtWork + "%'";
            if (ProductType != "")
                strSql += " And a.ProductType Like '%" + ProductType + "%'";
            if (SizeName != "")
                strSql += " And c.size_cdesc Like '%" + SizeName + "%'";
            DataTable dtProductType = clsPublicOfCF01.GetDataTable(strSql);
            return dtProductType;
        }
        public static DataTable FindColor(int SizeSN)
        {
            string strSql = "";
            strSql = "Select b.Seq,b.ColorID,b.ColorName,b.UpperSN,a.Price,a.Curr,a.ValueDesc " +
                " From mm_ProductTypePriceColorGroup a " +
                " Inner Join mm_ProductTypePriceColorDetails b On a.SN=b.UpperSN " +
                " Where a.UpperSN='" + SizeSN + "'";
            strSql += " Order By a.SN,b.Seq";
            DataTable dtColor = clsPublicOfCF01.GetDataTable(strSql);
            return dtColor;
        }
    }
}
