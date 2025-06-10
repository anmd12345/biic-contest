namespace BIIC_Contest.Entitys
{
    //Message entity for basic responses
    public class BasicResponseEntity
    {
        private bool success;
        private string message;
        private dynamic data;

        public BasicResponseEntity() { }

        public BasicResponseEntity(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }

        public BasicResponseEntity(bool success, string message, dynamic data)
        {
            this.success = success;
            this.message = message;
            this.Data = data;   
        }

        public bool Success { get => success; set => success = value; }
        public string Message { get => message; set => message = value; }
        public dynamic Data { get => data; set => data = value; }
    }
}