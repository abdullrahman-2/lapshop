using lapshop.Areas.bl;
using lapshop.Models;

using Microsoft.AspNetCore.Mvc;


namespace lapshop.Areas.admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesApiController : ControllerBase
    {
        ITems Oitems;
        iCategory Ocategry;
        public ValuesApiController(ITems items,iCategory iCategory) {
        
            Oitems = items;
            Ocategry = iCategory;
        
        }
        clsApiResponse OApiResponse = new clsApiResponse();
        [HttpGet]
        [Route("GetItems")]
        public clsApiResponse GetItems()
        {
            try {
                OApiResponse.Data = Oitems.getAllData(null);
                OApiResponse.Errors = null;
                OApiResponse.StatusCode = 200;
                return OApiResponse;
            }
            catch (Exception ex) {

                OApiResponse.Errors = ex.Message;
                OApiResponse.Data = null;
                OApiResponse.StatusCode =500;   
                return OApiResponse;

            }
            
        }

        [HttpGet("GetCategory")]
        public clsApiResponse GetCategories()
        {

            try
            {
                OApiResponse.Data = Ocategry.getAll();
                OApiResponse.Errors = null;
                OApiResponse.StatusCode = 200;
                return OApiResponse;
            }
            catch (Exception ex)
            {

                OApiResponse.Errors = ex.Message;
                OApiResponse.Data = null;
                OApiResponse.StatusCode = 500;
                return OApiResponse;

            }
        }


        // GET api/<controller>/5
        [HttpGet("GetItemByID/{id}")]
        public clsApiResponse GetItemByID(int id)
        {
            
            try
            {
                OApiResponse.Data = Oitems.getVitemById(id); ;
                OApiResponse.Errors = null;
                OApiResponse.StatusCode = 200;
                return OApiResponse;
            }
            catch (Exception ex)
            {

                OApiResponse.Errors = ex.Message;
                OApiResponse.Data = null;
                OApiResponse.StatusCode = 500;
                return OApiResponse;

            }

        }


        
        [HttpGet("GetCategoryByID/{id}")]
        public clsApiResponse GetCategoryByID(int id)
        {
      
            try
            {
                OApiResponse.Data = Ocategry.getById(id); ; ;
                OApiResponse.Errors = null;
                OApiResponse.StatusCode = 200;
                return OApiResponse;
            }
            catch (Exception ex)
            {

                OApiResponse.Errors = ex.Message;
                OApiResponse.Data = null;
                OApiResponse.StatusCode = 500;
                return OApiResponse;

            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("PostItem")]
        public clsApiResponse PostItem([FromBody] TbItem Item)
        {
            Oitems.save(Item);
            try
            {
                OApiResponse.Data = "Done";
                OApiResponse.Errors = null;
                OApiResponse.StatusCode = 200;
                return OApiResponse;
            }
            catch (Exception ex)
            {

                OApiResponse.Errors = ex.Message;
                OApiResponse.Data = null;
                OApiResponse.StatusCode = 500;
                return OApiResponse;

            }
        }

        [HttpPost("PostCategory")]
        public clsApiResponse PostCategory([FromBody] TbCategory category)
        {
            Ocategry.save(category);
            try
            {
                OApiResponse.Data = "done";
                OApiResponse.Errors = null;
                OApiResponse.StatusCode = 200;
                return OApiResponse;
            }
            catch (Exception ex)
            {

                OApiResponse.Errors = ex.Message;
                OApiResponse.Data = null;
                OApiResponse.StatusCode = 500;
                return OApiResponse;

            }
        }


    }
}
