using AutoDeskAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileMetaData : ControllerBase
    {
        [HttpGet("filePath")]
        public IActionResult GetFileInfo(string path)
        {
            //need to read the path from Directory
          var exists =  Directory.Exists(path);
            if (!exists)
            {
                return NotFound();
            }

            //1. create a service
            List<FileMetaDataModel> filesMetaDataList = new List<FileMetaDataModel>();
            try
            {
                //need to read the files from directory
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                   FileInfo fileInfo = new FileInfo(file);
                    //meta data reading
                    var metaData = new FileMetaDataModel
                    {
                        FileName = fileInfo.Name,
                        FileExtension = fileInfo.Extension,
                        SizeofFile = fileInfo.Length,
                        CreationTime = fileInfo.CreationTime
                    };
                    filesMetaDataList.Add(metaData);
                }
                return Ok(filesMetaDataList);


            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
