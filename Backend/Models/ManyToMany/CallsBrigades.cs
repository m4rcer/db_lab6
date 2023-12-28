using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CallsBrigades
    {
        public int? CALLS_BRIGADES_ID { get; set; }
        public int? BRIGADE_ID { get; set; }
        public int? CALL_ID { get; set; }

        public CallsBrigades()
        {

        }
    }
}
