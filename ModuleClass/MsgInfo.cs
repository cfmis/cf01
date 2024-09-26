using System;
using System.Collections.Generic;
using System.Linq;

namespace cf01.ModuleClass
{
    public class MsgInfo
    {        
          public string msgTitle,msgSave_ok, msgSave_error, msgIsDelete, msgIsExists;
          public MsgInfo()
          {
              if (DBUtility._language == "2")
              {
                  msgTitle = "Prompt Message";
                  msgSave_ok = "Data saved successfully";
                  msgSave_error = "Failed to save the data";
                  msgIsDelete = "Are you sure you want to delete this record ?";
                  msgIsExists = "Data already exists.";
              }
              else
              {
                  msgTitle = "提示信息";
                  msgSave_ok = "資料保存成功!";
                  msgSave_error = "資料保存失敗!";
                  msgIsDelete = "確定要刪除此記錄?";
                  msgIsExists = "資料已存在!";
              }    
          }
    }
}
