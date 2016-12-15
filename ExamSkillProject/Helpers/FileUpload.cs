using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ExamSkillProject.Helpers
{
    public class FileUpload
    {

        public FileUpload()
        {

        }


        public string Upload(string name, HttpPostedFileBase file)
        {
            if (file != null)
            {

                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _FileExtension = Path.GetExtension(file.FileName);

                    string _NewFileName = Regex.Replace(name.ToLower(), @"[^A-Za-z0-9]+", "-");
                    _FileName = $"{ _NewFileName }-logo{ _FileExtension }";

                    string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), _FileName);

                    file.SaveAs(_path);
                    return _FileName;
                }
                return null;
            }
            return null;
        }
            
            
    }
}