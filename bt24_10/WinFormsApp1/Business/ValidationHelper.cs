using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuanLySinhVienWF.Business
{
    /// <summary>
    /// Lớp tĩnh sử dụng System.ComponentModel.DataAnnotations
    /// để kiểm tra tính hợp lệ của các đối tượng Entity
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Kiểm tra tính hợp lệ của một đối tượng dựa trên Data Annotations
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng cần kiểm tra</typeparam>
        /// <param name="obj">Đối tượng cần kiểm tra</param>
        /// <returns>Tuple gồm IsValid (hợp lệ hay không) và ErrorMessages (danh sách thông báo lỗi)</returns>
        public static (bool IsValid, List<string> ErrorMessages) ValidateObject<T>(T obj)
        {
            var errorMessages = new List<string>();

            if (obj == null)
            {
                errorMessages.Add("Đối tượng không được null.");
                return (false, errorMessages);
            }

            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, validateAllProperties: true);

            if (!isValid)
            {
                errorMessages = validationResults
                    .Where(r => !string.IsNullOrEmpty(r.ErrorMessage))
                    .Select(r => r.ErrorMessage!)
                    .ToList();
            }

            return (isValid, errorMessages);
        }
    }
}
