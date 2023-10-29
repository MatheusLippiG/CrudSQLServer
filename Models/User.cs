namespace DapperCrud.Models
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Adress { get; set; }
        public bool Premium { get; set; }
    }
}