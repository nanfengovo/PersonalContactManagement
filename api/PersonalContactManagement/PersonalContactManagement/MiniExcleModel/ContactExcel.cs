using MiniExcelLibs.Attributes;

namespace PersonalContactManagement.MiniExcleModel
{
    public class ContactExcel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [ExcelColumnName("姓名")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 电话号码
        /// </summary>
        [ExcelColumnName("电话号码")]
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [ExcelColumnName("邮箱")]
        public string? Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [ExcelColumnName("地址")]
        public string? Address { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        [ExcelColumnName("公司")]
        public string? Company { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        [ExcelColumnName("关键词")]
        public string? Keywords { get; set; }
    }
}
