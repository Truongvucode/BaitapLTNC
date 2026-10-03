using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp1.Entity
{
    public class LopHoc
    {
        [Required]
        [RegularExpression(@"^[A-Z]{3}\d{4}$")]
        public string MaLop { get; set; }
        [Required]
        public string TenLop { get; set; }
    }
}
