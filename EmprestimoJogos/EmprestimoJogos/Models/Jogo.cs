//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmprestimoJogos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Jogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogo()
        {
            this.Emprestimos = new HashSet<Emprestimo>();
        }

        [Key]
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no m�ximo 50 caracteres.")]
        public string Nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
