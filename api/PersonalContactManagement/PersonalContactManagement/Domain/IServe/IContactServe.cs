using PersonalContactManagement.Domain.Model;
using PersonalContactManagement.EntityFrameCore.EntityModel;

namespace PersonalContactManagement.Domain.IServe
{
    public interface IContactServe
    {
        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <returns></returns>
        Task<bool> AddContactPersonAsync(AddContactPersonDTO addContact);

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        Task<List<Contact>> GetContactPersonListAsync();


        /// <summary>
        /// 根据id获取联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Contact> GetContactPersonByIdAsync(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> EditContactPersonByIdAsync(int id,EditContactPersonDTO personDTOcontactPersonDTO);

        /// <summary>
        /// 根据Id删除联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeletedContactPersonByIdAsync(int id);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<bool> ImportAsync(IFormFile file);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<MemoryStream> ExportAsync();
    }
}
