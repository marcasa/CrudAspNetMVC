using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudAspNetMvc.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "RE")]
        public string RE { get; set; }

        [Required]
        [Display(Name = "Posto/Grad")]
        public string PostoGrad { get; set; }

        [Required]
        public int PostoGradCod  { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Guerra")]
        public string NomeGuerra { get; set; }

        [Required]
        [Display(Name = "OPM")]
        public string OPM { get; set; }

        [Display(Name = "Situação Funcional")]
        public string SitFuncional { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        [Display(Name = "Data de Admissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Admissao { get; set; }

        [Display(Name = "SAT")]
        public string Sat { get; set; }

        [Display(Name = "Telefone 1")]
        public string Telefone1 { get; set; }

        [Display(Name = "Telefone 2")]
        public string Telefone2 { get; set; }

        [Display(Name = "Observações")]
        public string Obs { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }
    }
}