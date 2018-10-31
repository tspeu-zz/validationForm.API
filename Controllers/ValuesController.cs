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
/* instaciate variables result of the input form validation*/
        VehicleValidationResultCode valid = VehicleValidationResultCode.Valid;
        VehicleValidationResultCode invalid = VehicleValidationResultCode.Invalid;

/*output result object */
        ProcessVehicleResponse validationResult  = new ProcessVehicleResponse() ;

/* validated the input form data */
        if (String.IsNullOrEmpty(value.ManufacturerNameShort) || String.IsNullOrEmpty(value.Type) 
            || IsNullOrValue(value.VehicleId, 0) || IsNullOrDefault(value.Price) ) 
        {   //item.IsNullOrValue(0)

            validationResult.VehicleId = idVehicle ;
            validationResult.ReturnCode =  invalid ;         
        }
        else{ 

            validationResult.VehicleId = idVehicle ;
            validationResult.ReturnCode = valid ;     
        }
        
            return Ok(validationResult);

        }
/**************************************************************************************************** */
/*validated is any  type is null or 0

//...
double d = 0;
IsNullOrDefault(d); // true
MyClass c = null;
IsNullOrDefault(c); // true
If T it's a reference type, value will be compared with null ( default(T) ), 
otherwise, if T is a value type, let's say double, default(t) is 0d,
for bool is false, for char is '\0' and so on
  */
        public bool IsNullOrDefault<T>(T value) {

            return object.Equals(value, default(T));
        }

/* REF: https://stackoverflow.com/questions/633286/nullable-types-best-way-to-check-for-null-or-zero-in-c-sharp */
        public  bool IsNullOrValue( int? value, int valueToCheck)
        {
            return (value??valueToCheck) == valueToCheck;
        }

        // [HttpPost]
        // public string TestMethod([FromBody]string value)
        // {
        //     return "Hello from http post web api controller: " + value;
        // }
/********************************************************************************************** */

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
