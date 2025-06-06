namespace PersonalContactManagement.EntityFrameCore
{
    public class Common
    {
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime UpdateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDelted { get; set; }
    }
}
