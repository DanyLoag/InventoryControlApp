﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Almacen.AutoGen;

[Table("Semestre")]
public partial class Semestre
{
    [Key]
    public long SemestreId { get; set; }

    public long Numero { get; set; }

    [InverseProperty("Semestre")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
