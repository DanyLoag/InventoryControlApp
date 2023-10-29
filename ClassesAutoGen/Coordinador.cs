﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Coordinador")]
public partial class Coordinador
{
    [Key]
    [Column(TypeName = "int")]
    public int? CoordinadorId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string ApellidoPaterno { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    [StringLength(50)]
    public string ApellidoMaterno { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    [StringLength(100)]
    public string Correo { get; set; } = null!;

    [Column(TypeName = "int")]
    public int? PlantelId { get; set; }

    [Column(TypeName = "int")]
    public int? UsuarioId { get; set; }

    [ForeignKey("PlantelId")]
    [InverseProperty("Coordinadores")]
    public virtual Plantel? Plantel { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Coordinadores")]
    public virtual Usuario? Usuario { get; set; } = null!;
}
