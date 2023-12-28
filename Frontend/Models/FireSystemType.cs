namespace Backend.Models
{
    public class FireSystemType
    {
        public int? FIRE_SYSTEM_TYPE_ID { get; set; }
        public string FIRE_SYSTEM_TYPE_NAME { get; set; }

        public FireSystemType()
        {

        }

        public FireSystemType(int? id, string name)
        {
            FIRE_SYSTEM_TYPE_ID = id;
            FIRE_SYSTEM_TYPE_NAME = name;
        }
    }
}
