using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalContactManagement.Domain.IServe;
using PersonalContactManagement.Domain.Model;
using PersonalContactManagement.EntityFrameCore.Config;
using PersonalContactManagement.EntityFrameCore.EntityModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace PersonalContactManagement.Domain.Serve
{
    public class ContactServe: IContactServe
    {
        public required  MyDbContext _dbContext;

        public readonly ILogger<ContactServe> _logger;

        public ContactServe(MyDbContext dbContext, ILogger<ContactServe> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddContactPersonAsync(AddContactPersonDTO addContact)
        {
            try
            {
                //数据验证在前端做
                //DTOModel to EntityModel
                Contact contact = new Contact
                {
                    Name = addContact.Name,
                    PhoneNumber = addContact.PhoneNumber,
                    Email = addContact.Email,
                    Address = addContact.Address,
                    Company = addContact.Company,
                    Keywords = addContact.Keywords,
                    CreateTime = DateTime.Now,
                    UpdateTime = addContact.UpdateTime,
                };

                _dbContext.Contacts.Add(contact);
                int affectedrow = await _dbContext.SaveChangesAsync();
                if(affectedrow > 0)
                {
                    _logger.LogInformation($"添加姓名为{addContact.Name}的联系人成功！");
                    return true;
                }
                else
                {
                    _logger.LogWarning($"添加姓名为{addContact.Name}的联系人失败！");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"服务端发生异常，异常信息为{ex.Message}");
                return false;
            }
           
            
        }

        public async Task<List<Contact>> GetContactPersonListAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }


        public async Task<Contact> GetContactPersonByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"服务端发生异常！异常信息为：{ex.Message}");
                return null;
            }
        }

        public async Task<bool> EditContactPersonByIdAsync(int id,EditContactPersonDTO contactPersonDTO)
        {
            //数据验证放前端做
            try
            {
                //根据id找到需要修改的ContactPerson
                var Person = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
                if (Person != null)
                {
                    Person.Name = contactPersonDTO.Name;
                    Person.PhoneNumber = contactPersonDTO.PhoneNumber;
                    Person.Email = contactPersonDTO.Email;
                    Person.Address = contactPersonDTO.Address;
                    Person.Company = contactPersonDTO.Company;
                    Person.Keywords = contactPersonDTO.Keywords;
                    Person.UpdateTime = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"修改id为：{id}的联系人信息成功！");
                    return true;
                }
                else
                {
                    _logger.LogInformation($"修改id为：{id}的联系人信息失败！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"服务端发生异常，异常信息为：{ex.Message}");
                return false;   
            }
           
           



        }

        public async Task<bool> DeletedContactPersonByIdAsync(int id)
        {
            try
            {
                var person = await _dbContext.Contacts.FindAsync(id);
                if (person != null)
                {
                    _dbContext.Contacts.Remove(person);
                    _dbContext.SaveChanges();
                    _logger.LogInformation($"删除id为{id}的联系人成功");
                    return true;
                }
                else
                {
                    _logger.LogInformation($"id为{id}的联系人不存在！！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"服务端发生异常，异常信息为：{ex.Message}");
                return false;
            }
        }
    }
}
