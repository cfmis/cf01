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
            strSql = "Select ID,Ver,ArtWork,ProductType,BasePrice,Unit,Remark,CreateUser,Convert(Varchar(50),CreateTime,20) AS CreateTime"+
                ",AmendUser,Convert(Varchar(50),AmendTime,20) AS AmendTime,SN" +
                " From mm_ProductTypePrice " +
                " Where ID='" + ID + "'";
            DataTable dtProductType = clsPublicOfCF01.GetDataTable(strSql);
            return dtProductType;
        }

        public static DataTable LoadPrdSizeGroup(int UpperSN)
        {
            string strSql = "";
            strSql = "Select a.UpperSN,a.Seq,a.SizeGroup,a.SN,a.SizeID,a.SizeName"+
                ",b.add_charge1,b.add_charge2,b.add_charge3 " +
                " From mm_ProductTypePriceSize a" +
                " Left Join bs_size b On a.SizeID=b.size_id " +
                " Where a.UpperSN='" + UpperSN + "'";
            DataTable dtSizeGroup = clsPublicOfCF01.GetDataTable(strSql);
            return dtSizeGroup;
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
            strSql = "Select UpperSN,Seq,ColorGroup,ValueDesc,Rate,Price,Curr,add_charge1,add_charge2,add_charge3,SN" +
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
                strSql += string.Format(@" Insert Into mm_ProductTypePrice(ID,Ver,ArtWork,ProductType,BasePrice,Unit,Remark,CreateUser,CreateTime)" +
                        " Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GETDATE() )"
                        , ID, Ver, mdlPtp.ArtWork, mdlPtp.ProductType, mdlPtp.BasePrice, mdlPtp.Unit, mdlPtp.Remark, userid);
            }
            else
                strSql += string.Format(@" Update mm_ProductTypePrice Set ArtWork='{2}',ProductType='{3}',BasePrice='{4}',Unit='{5}',Remark='{6}'" +
                    ",AmendUser='{7}',AmendTime=GETDATE()" +
                    " Where ID='{0}' And Ver='{1}'"
                    , ID, Ver, mdlPtp.ArtWork, mdlPtp.ProductType, mdlPtp.BasePrice, mdlPtp.Unit, mdlPtp.Remark, userid);
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

        public static string SavePrdSizeGroup(mdlProductTypePriceSize mdlPtps)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            if (!CheckExistRecord("mm_ProductTypePriceSize", mdlPtps.UpperSN, mdlPtps.Seq))
                strSql += string.Format(@" Insert Into mm_ProductTypePriceSize(UpperSN,Seq,SizeGroup,SizeID,SizeName ) " +
                        " Values ('{0}','{1}','{2}','{3}','{4}' )"
                        , mdlPtps.UpperSN, mdlPtps.Seq, mdlPtps.SizeGroup, mdlPtps.SizeID, mdlPtps.SizeName);
            else
                strSql += string.Format(@" Update mm_ProductTypePriceSize Set SizeGroup='{2}',SizeID='{3}',SizeName='{4}'" +
                    " Where UpperSN='{0}' And Seq='{1}'"
                    , mdlPtps.UpperSN, mdlPtps.Seq, mdlPtps.SizeGroup, mdlPtps.SizeID, mdlPtps.SizeName);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        public static string DeletePrdSizeGroup(int SN)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@" Delete From mm_ProductTypePriceSize Where SN='{0}'", SN);
            strSql += string.Format(@" Delete From mm_ProductTypePriceColorGroup Where UpperSN='{0}'", SN);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

        public static string DeletePrdColorGroup(int SN)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@" Delete From mm_ProductTypePriceColorGroup Where SN='{0}'", SN);
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
            if (!CheckExistRecord("mm_ProductTypePriceColorGroup", mdlMtpcg.UpperSN, mdlMtpcg.Seq))
                strSql += string.Format(@" Insert Into mm_ProductTypePriceColorGroup" +
                        " (UpperSN,Seq,ColorGroup,ValueDesc,Rate,Price,Curr,add_charge1,add_charge2,add_charge3)" +
                        " Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}' )"
                        , mdlMtpcg.UpperSN, mdlMtpcg.Seq, mdlMtpcg.ColorGroup
                        , mdlMtpcg.ValueDesc, mdlMtpcg.Rate, mdlMtpcg.Price, mdlMtpcg.Curr
                        , mdlMtpcg.AddCharge1, mdlMtpcg.AddCharge2, mdlMtpcg.AddCharge3);
            else
                strSql += string.Format(@" Update mm_ProductTypePriceColorGroup " +
                    " Set ColorGroup='{2}',ValueDesc='{3}',Rate='{4}',Price='{5}',Curr='{6}',add_charge1='{7}',add_charge2='{8}',add_charge3='{9}'" +
                    " Where UpperSN='{0}'  And Seq='{1}'"
                    , mdlMtpcg.UpperSN, mdlMtpcg.Seq, mdlMtpcg.ColorGroup
                    , mdlMtpcg.ValueDesc, mdlMtpcg.Rate, mdlMtpcg.Price, mdlMtpcg.Curr
                    , mdlMtpcg.AddCharge1, mdlMtpcg.AddCharge2, mdlMtpcg.AddCharge3);
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
            strSql += " Select size_id,size_cdesc AS SizeName,add_charge1,add_charge2,add_charge3" +
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
                ",b.Seq AS SizeSeq,b.SizeID,b.SizeName,b.SN AS SizeSN,b.SizeGroup " +
                " From mm_ProductTypePrice a " +
                " Left Join mm_ProductTypePriceSize b On a.SN=b.UpperSN " +
                " Where a.ID>=''";
            if(ArtWork!="")
                strSql+= " And a.ArtWork Like '%" + ArtWork + "%'";
            if (ProductType != "")
                strSql += " And a.ProductType Like '%" + ProductType + "%'";
            if (SizeName != "")
                strSql += " And b.SizeName Like '%" + SizeName + "%'";
            DataTable dtProductType = clsPublicOfCF01.GetDataTable(strSql);
            return dtProductType;
        }
        public static DataTable FindColor(int SizeSN)
        {
            string strSql = "";
            strSql = "Select a.ColorGroup,b.ColorID,c.clr_cdesc AS ColorName,a.Price,a.Curr,a.ValueDesc " +
                " From mm_ProductTypePriceColorGroup a " +
                " Left Join mm_ProductTypeColorGroup b On a.ColorGroup=b.GroupID "+
                " Left Join bs_color c On b.ColorID=c.clr_code " +
                " Where a.UpperSN='" + SizeSN + "'";
            strSql += " Order By a.SN,b.ColorID";

            DataTable dtColor = clsPublicOfCF01.GetDataTable(strSql);
            return dtColor;
        }

        public static string SaveSizeGroup(mdlSizeGroup mdlSG)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            string GroupID = mdlSG.GroupID;
            string SizeID = mdlSG.SizeID;
            if(GroupID=="")
            {
                GroupID= GenSizeGroupID();
            }
            if (!CheckExistSizeGroupID(GroupID, SizeID))
                strSql += string.Format(@" Insert Into mm_ProductTypePriceSizeGroup(GroupID,SizeID)" +
                        " Values ('{0}','{1}' )"
                        , GroupID, mdlSG.SizeID);
            else
                strSql += string.Format(@" Update mm_ProductTypePriceSizeGroup Set SizeID='{1}'" +
                    " Where GroupID='{0}' And SizeID='{1}'"
                    , GroupID, mdlSG.SizeID);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result=GroupID;
            else
                result="";
            return result;
        }
        private static bool CheckExistSizeGroupID(string GroupID,string SizeID)
        {
            bool result = false;
            string strSql = "Select GroupID From mm_ProductTypePriceSizeGroup Where GroupID='" + GroupID + "' And SizeID='" + SizeID + "'";
            DataTable dtGroupID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtGroupID.Rows.Count > 0)
                result = true;
            return result;
        }
        private static string GenSizeGroupID()
        {
            string result = "";
            string strSql = "";
            strSql += " Select Max(GroupID) AS GroupID From mm_ProductTypePriceSizeGroup ";
            DataTable dtID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtID.Rows[0]["GroupID"].ToString() == "")
                result = "S" + "001";
            else
                result = "S" + (Convert.ToInt32(dtID.Rows[0]["GroupID"].ToString().Substring(1, 3)) + 1).ToString().PadLeft(3, '0');
            return result;
        }

        public static DataTable LoadSizeDetails(string GroupID,string SizeID)
        {
            string strSql = "Select a.GroupID,a.SizeID,b.size_cdesc AS SizeName,b.add_charge1,b.add_charge2,b.add_charge3 " +
                " From mm_ProductTypePriceSizeGroup a" +
                " Left Join bs_size b On a.SizeID=b.size_id " +
                " Where a.GroupID>=''";
            if (GroupID != "")
                strSql += " And a.GroupID = '" + GroupID + "'";
            if (SizeID != "")
                strSql += " And a.SizeID Like '%" + SizeID + "%'";
            strSql += " Order By a.GroupID,a.SizeID";
            DataTable dtSize = clsPublicOfCF01.GetDataTable(strSql);
            dtSize.Columns.Add("SelectSizeFlag", typeof(bool));
            for(int i=0;i< dtSize.Rows.Count;i++)
            {
                dtSize.Rows[i]["SelectSizeFlag"] = true;
            }
            return dtSize;
        }

        public static string DeleteSizeGroup(mdlSizeGroup mdlSG)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@" Delete From mm_ProductTypePriceSizeGroup" +
                " Where GroupID='{0}' And SizeID='{1}'"
                , mdlSG.GroupID, mdlSG.SizeID);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }


        public static string SaveColorGroup(mdlColorGroup mdlCG)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            string GroupID = mdlCG.GroupID;
            string ColorID = mdlCG.ColorID;
            if (GroupID == "")
            {
                GroupID = GenColorGroupID();
            }
            if (!CheckExistColorGroupID(GroupID, ColorID))
                strSql += string.Format(@" Insert Into mm_ProductTypeColorGroup(GroupID,ColorID)" +
                        " Values ('{0}','{1}' )"
                        , GroupID, mdlCG.ColorID);
            else
                strSql += string.Format(@" Update mm_ProductTypeColorGroup Set ColorID='{1}'" +
                    " Where GroupID='{0}' And ColorID='{1}'"
                    , GroupID, mdlCG.ColorID);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if (result == "")
                result = GroupID;
            else
                result = "";
            return result;
        }

        private static bool CheckExistColorGroupID(string GroupID, string ColorID)
        {
            bool result = false;
            string strSql = "Select GroupID From mm_ProductTypeColorGroup Where GroupID='" + GroupID + "' And ColorID='" + ColorID + "'";
            DataTable dtGroupID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtGroupID.Rows.Count > 0)
                result = true;
            return result;
        }
        private static string GenColorGroupID()
        {
            string result = "";
            string strSql = "";
            strSql += " Select Max(GroupID) AS GroupID From mm_ProductTypeColorGroup ";
            DataTable dtID = clsPublicOfCF01.GetDataTable(strSql);
            if (dtID.Rows[0]["GroupID"].ToString() == "")
                result = "C" + "001";
            else
                result = "C" + (Convert.ToInt32(dtID.Rows[0]["GroupID"].ToString().Substring(1, 3)) + 1).ToString().PadLeft(3, '0');
            return result;
        }

        public static DataTable LoadColorGroup(string ColorGroup,string ColorID)
        {
            string strSql = "Select a.GroupID,a.ColorID,b.clr_cdesc AS ColorName " +
                " From mm_ProductTypeColorGroup a" +
                " Left Join bs_color b On a.ColorID=b.clr_code " +
                " Where a.GroupID>=''";
            if(ColorGroup!="")
                strSql += " And a.GroupID = '" + ColorGroup + "'";
            if (ColorID != "")
                strSql += " And a.ColorID Like '%" + ColorID + "%'";
            strSql += " Order By a.GroupID,a.ColorID";
            DataTable dtGroupID = clsPublicOfCF01.GetDataTable(strSql);
            return dtGroupID;
        }

        public static string DeleteColorGroup(mdlColorGroup mdlCG)
        {
            string result = "";
            string strSql = "";
            strSql += string.Format(@" SET XACT_ABORT  ON ");
            strSql += string.Format(@" BEGIN TRANSACTION ");
            strSql += string.Format(@" Delete From mm_ProductTypeColorGroup" +
                " Where GroupID='{0}' And ColorID='{1}'"
                , mdlCG.GroupID, mdlCG.ColorID);
            strSql += string.Format(@" COMMIT TRANSACTION ");
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            return result;
        }

    }
}
