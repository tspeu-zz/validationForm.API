namespace pruebaJM.API.Models {
    public class ProcessVehicleResponse {
        // public ProcessVehicleResponse () {
        //     this.VehicleId = 1;
        //     this.ReturnCode = returnCode;

        // }
        public int VehicleId { get; set; }
        
        public VehicleValidationResultCode ReturnCode { get; set; }

    }
}