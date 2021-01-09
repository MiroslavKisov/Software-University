namespace IRunes.Models
{
    using System;

    public class User : BaseModel<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
