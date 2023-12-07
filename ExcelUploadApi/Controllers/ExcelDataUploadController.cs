using ExcelDataReader;
using ExcelUploadApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ExcelUploadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelDataUploadController : ControllerBase
    {
        [HttpPost("UploadExcel")]
        public ActionResult<string> ExcelUpload()
        {
            string message = "";
            var httpRequest = HttpContext.Request;

            using (ExcelContext objEntity = new ExcelContext())
            {
                if (httpRequest.Form.Files.Count > 0)
                {
                    IFormFile file = httpRequest.Form.Files[0];
                    Stream stream = file.OpenReadStream();

                    IExcelDataReader reader = null;

                    if (file.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        message = "This file format is not supported";
                    }

                    if (reader != null)
                    {
                        DataSet excelRecords = reader.AsDataSet();
                        reader.Close();

                        var finalRecords = excelRecords.Tables[0];
                        for (int i = 0; i < finalRecords.Rows.Count; i++)
                        {
                            UserDetail objUser = new UserDetail();
                            objUser.UserName = finalRecords.Rows[i][0].ToString();
                            objUser.EmailId = finalRecords.Rows[i][1].ToString();
                            objUser.Gender = finalRecords.Rows[i][2].ToString();
                            objUser.Address = finalRecords.Rows[i][3].ToString();
                            objUser.MobileNo = finalRecords.Rows[i][4].ToString();
                            objUser.PinCode = finalRecords.Rows[i][5].ToString();

                            objEntity.UserDetails.Add(objUser);
                        }

                        int output = objEntity.SaveChanges();
                        if (output > 0)
                        {
                            message = "Excel file has been successfully uploaded";
                        }
                        else
                        {
                            message = "Excel file uploaded has failed";
                        }
                    }
                }
                else
                {
                    return BadRequest("No files were uploaded");
                }
            }

            return Ok(message);
        }

        [HttpGet("UserDetails")]
        public ActionResult<List<UserDetail>> BindUser()
        {
            List<UserDetail> lstUser;
            using (ExcelContext objEntity = new ExcelContext())
            {
                lstUser = objEntity.UserDetails.ToList();
            }
            return Ok(lstUser);
        }
    }
}
