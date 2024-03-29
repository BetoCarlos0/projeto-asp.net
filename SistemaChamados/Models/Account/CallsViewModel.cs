﻿using SistemaChamados.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaChamados.Models.Account
{
    public class CallsViewModel
    {
        public int CallsId { get; set; }

        [Required(ErrorMessage = "Nome vazio"), Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefone vazio"), Display(Name = "Telefone")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ramal vazio")]
        [Range(1, 100, ErrorMessage = "Ramal deve ser maior que 0 e menor que 100")]
        public int Ramal { get; set; }

        [Required(ErrorMessage = "Título vazio"), Display(Name = "Título")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição vazio"), Display(Name = "Descrição")]
        public string Decription { get; set; } = string.Empty;

        public string AnexoUrl { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? Anexo { get; set; }

        public string Status { get; set; } = string.Empty;

        public int AspNetUsersId { get; set; }

        [Display(Name = "Usuário")]
        public UserCustom? UserCustom { get; set; }
    }
}
