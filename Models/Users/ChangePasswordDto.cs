using System.ComponentModel.DataAnnotations;

namespace Models.Users {
    public class ChangePasswordDto {

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

    }
}
