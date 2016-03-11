namespace HomeWorkW01.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new 客戶資料Entities();
            if (this.Id == 0)
            {
                if (db.客戶聯絡人.Where(x=>x.客戶Id == this.客戶Id && x.Email.Equals(this.Email)).Any())
                {
                    yield return new ValidationResult("Email is exist", new string[] { "Email" });
                }
            }
            else
            {
                if (db.客戶聯絡人.Where(x => x.客戶Id == this.客戶Id && x.Id != this.Id && x.Email.Equals(this.Email)).Any())
                {
                    yield return new ValidationResult("Email is exist", new string[] { "Email" });
                }
            }

            yield return ValidationResult.Success;
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "電話格式必須為(e.g.0911-111111)")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
