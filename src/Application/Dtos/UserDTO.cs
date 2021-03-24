namespace Application.Dtos
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
    }
}
