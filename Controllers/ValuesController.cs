using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pruebaJM.API.Models;

namespace pruebaJM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public const int idVehicle = 1; 

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult  ProcessVehicle([FromBody] VehicleRequest value)
        {

        VehicleValidationResultCode valid = VehicleValidationResultCode.Valid;
        VehicleValidationResultCode invalid = VehicleValidationResultCode.Invalid;
        ProcessVehicleResponse validationResult  = new ProcessVehicleResponse() ;
//validated the input form data
        if (String.IsNullOrEmpty(value.ManufacturerNameShort) || 
            String.IsNullOrEmpty(value.Type) ) {

            // ProcessVehicleResponse validationResult  = new ProcessVehicleResponse 
            // {VehicleId = 1 , ReturnCode = invalid }; 
            validationResult.VehicleId = 1 ;
            validationResult.ReturnCode =  invalid ;         
        }
        
        else{ 
            // ProcessVehicleResponse validationResult  = new ProcessVehicleResponse 
            // {VehicleId = 1 , ReturnCode = valid };
                validationResult.VehicleId = 1 ;
                validationResult.ReturnCode = valid ;     
            }
        


            return Ok(validationResult);

        }

        // [HttpPost]
        // public string TestMethod([FromBody]string value)
        // {
        //     return "Hello from http post web api controller: " + value;
        // }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
