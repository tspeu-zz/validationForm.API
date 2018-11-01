using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pruebaJM.API.Models;


namespace pruebaJM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public const int idVehicle = 1; 

/* instaciate variables result of the input form validation*/
        VehicleValidationResultCode valid = VehicleValidationResultCode.Valid;
        VehicleValidationResultCode invalid = VehicleValidationResultCode.Invalid;

/*output result object */
        ProcessVehicleResponse validationResult  = new ProcessVehicleResponse();

        // POST api/values
        [HttpPost]
        public ActionResult  ProcessVehicle([FromBody] VehicleRequest value)
        {
        

            if (value != null)  
            {

/* validated the input form data */
                if (String.IsNullOrEmpty(value.ManufacturerNameShort) || String.IsNullOrEmpty(value.Type) 
                    || IsNullOrValue(value.VehicleId, 0) || IsNullOrDefault(value.Price) ) 
                {   //item.IsNullOrValue(0)

                    validationResult.VehicleId = value.VehicleId ;
                    validationResult.ReturnCode =  invalid ;         
                }
                else { 

                    validationResult.VehicleId = value.VehicleId ;
                    validationResult.ReturnCode = valid ;     
                }
            
                return Ok(validationResult);

            }

            else {
                    return BadRequest(value);
                    //return NotFound(new NotFoundError("The data was not found"));
            }

        }
/**************************************************************************************************** */
/*validated if  is null or 0 any type

IsNullOrDefault(d); // true
MyClass c = null;
IsNullOrDefault(c); // true
If T it's a reference type, value will be compared with null ( default(T) ), 
otherwise, if T is a value type, let's say double, default(t) is 0d,
for bool is false, for char is '\0' and so on
/****************************************************************************************************/

        public bool IsNullOrDefault<T>(T value) {

            return object.Equals(value, default(T));
        }

/* REF: https://stackoverflow.com/questions/633286/nullable-types-best-way-to-check-for-null-or-zero-in-c-sharp */
        public  bool IsNullOrValue( int? value, int valueToCheck)
        {
            return (value??valueToCheck) == valueToCheck;
        }


    }
}