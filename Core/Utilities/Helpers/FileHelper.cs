using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";

        public static IResult Upload(IFormFile formFile)
        {
            var folderExists = CheckFileExists(formFile);
            if (folderExists.Message != null)
            {
                return new ErrorResult(folderExists.Message);
            }
            var type = Path.GetExtension(formFile.FileName);
            var typeValid = CheckTypeValid(type);
            var randomName = Guid.NewGuid().ToString();
            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, formFile);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));

        }
        public static IResult Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
            {
                return new ErrorResult(typeValid.Message);
            }

            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));
        }
        public static IResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }
        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }

        }
        private static void CreateImageFile(string directory, IFormFile formFile)
        {
            using (FileStream fileStream = File.Create(directory))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        private static IResult CheckTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult("Wrong file type.");
            }
            return new SuccessResult();
        }

        private static IResult CheckFileExists(IFormFile formFile)
        {
            if (formFile.Length > 0 && formFile != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File doesn't not exists");
        }
    }
}
