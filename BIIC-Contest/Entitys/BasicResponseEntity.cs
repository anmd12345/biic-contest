namespace BIIC_Contest.Entitys
{
    //Message entity for basic responses
    public class BasicResponseEntity
    {
        private bool success;
        private string message;

        public BasicResponseEntity() { }

        public BasicResponseEntity(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }

        public bool Success { get => success; set => success = value; }
        public string Message { get => message; set => message = value; }
    }
}