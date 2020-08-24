using AutoMapper;
using CodingActivity.WebApiVue.DTOs;
using CodingActivity.WebApiVue.Entities;
using CodingActivity.WebApiVue.Services;
using CodingActivity.WebApiVue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodingActivity.WebApiVue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            this._contactService = contactService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get([FromQuery] string sort)
        {
            if (string.IsNullOrWhiteSpace(sort))
                sort = "Id ASC";

            var contacts = await this._contactService.GetAll(sort);            

            return
                Ok(this._mapper.Map<ContactDTO[]>(contacts));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id <= 0)
                return
                    BadRequest(new { error = "Must send id." });

            var concat = await this._contactService.Get(id);

            return
                Ok(this._mapper.Map<ContactDTO>(concat));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody] ContactDTO contact)
        {
            if (!ModelState.IsValid)
                return
                    BadRequest();

            var enContact = this._mapper.Map<Contact>(contact);
            var newContact = await this._contactService.Add(enContact);

            return
                Ok(this._mapper.Map<ContactDTO>(newContact));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] ContactDTO contact)
        {
            if (!ModelState.IsValid)
                return
                    BadRequest();

            var enContact = this._mapper.Map<Contact>(contact);
            var updContact = await this._contactService.Update(enContact);

            return
                Ok(this._mapper.Map<ContactDTO>(updContact));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            if (id <= 0)
                return
                    BadRequest(new { error = "Must send id." });

            var reContact = await this._contactService.Remove(id);

            return
                Ok(this._mapper.Map<ContactDTO>(reContact));
        }

        [HttpGet]
        [Route("DropDown/{dropDowns}")]
        public async Task<IActionResult> GetDropDown([FromRoute] string dropDowns)
        {
            if (string.IsNullOrWhiteSpace(dropDowns))
                BadRequest(new { error = "Must send dropdown names separate by ," });

            return
                Ok(await this._contactService.GetDropDown(dropDowns));
        }
    }
}