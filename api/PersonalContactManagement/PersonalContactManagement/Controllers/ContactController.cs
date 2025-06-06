using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalContactManagement.APIHelper;
using PersonalContactManagement.Domain.IServe;
using PersonalContactManagement.Domain.Model;
using PersonalContactManagement.Domain.Serve;

namespace PersonalContactManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public required IContactServe _ContactServe;

        public ContactController(IContactServe contactServe)
        {
            _ContactServe = contactServe;
        }

        [HttpPost]
        public async Task<IActionResult> AddContactPerson(AddContactPersonDTO personDTO)
        {
            var success = await _ContactServe.AddContactPersonAsync(personDTO);
            var result = new Result();
            if (success)
            {
                result.Code = 1;
                result.Msg = "添加成功！";
                return Ok(result);
            }
            else
            {
                result.Code = -99;
                result.Msg = "添加失败！";
                return Ok(result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetContactPersonList()
        {
            var contacts = await _ContactServe.GetContactPersonListAsync();
            var result = new Result
            {
                Code = 1,
                Msg = "获取所有联系人成功！",
                Data = contacts
            };
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetContactPersonById(int id)
        {
            var contact = await _ContactServe.GetContactPersonByIdAsync(id);
            return Ok(contact);
        }

        [HttpPut]
        public async Task<IActionResult> EditContactPersonById(int id,EditContactPersonDTO editContact)
        {
            var success = await _ContactServe.EditContactPersonByIdAsync(id, editContact);
            var result = new Result();
            if (success)
            {
                result.Code = 1;
                result.Msg = "修改成功！";
                return Ok(result);
            }
            else
            {
                result.Code = -99;
                result.Msg = "修改失败！";
                return Ok(result);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletedContactPersonById(int id)
        {
            var success =await _ContactServe.DeletedContactPersonByIdAsync(id);
            var result = new Result();
            if (success)
            {
                result.Code = 1;
                result.Msg = "删除成功！";
                return Ok(result);
            }
            else
            {
                result.Code = -99;
                result.Msg = "删除失败！";
                return Ok(result);
            }
        }


    }
}
