namespace pruebaJM.API.Tools
{
    public class CheckNull
    {
        
        public  bool IsNullOrValue( double? value, double valueToCheck) {

            return (value??valueToCheck) == valueToCheck;
        }

        public bool IsNullOrDefault<T>(T value) {

            return object.Equals(value, default(T));
        }

    }
}