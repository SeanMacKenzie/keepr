namespace keepr.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal UserReturnModel GetReturnModel()
        {
            return UserReturnModel() {
                Id = Id,
                UserName = Username,
                Email = Email
            };
        }
    }
}