namespace Model.EntityFramework
{
    using System;

    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class User
    {
        [DisplayName("STT")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Vui l�ng nh?p t�n ng??i d�ng!")]
        [DisplayName("T�n ??ng nh?p")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui l�ng nh?p m?t kh?u!")]
        [DisplayName("M?t kh?u")]
        //[Remote("CheckExistingEmail", "Home", ErrorMessage = "Email already exists!")]
        [StringLength(32)]
        public string Password { get; set; }

        [DisplayName("H? t�n")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("??a ch?")]
        [StringLength(150)]
        public string Address { get; set; }

        [DisplayName("Mail")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("S?T")]
        [StringLength(50)]
        public string Phone { get; set; }

        [DisplayName("Ng�y t?o")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("Ng??i t?o")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [DisplayName("Ng�y c?p nh?t")]
        public DateTime? ModifiedDate { get; set; }

        [DisplayName("Ng??i c?p nh?t")]
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [DisplayName("Tr?ng th�i")]
        public bool Status { get; set; }
    }
}
