using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Mobile.Models
{
    [Table("Profesor")]
    public class TeacherModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdProfesor { get; set; }

        [ForeignKey(typeof(UserModel))]
        public int IdUsuario { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public UserModel Usuario { get; set; }

        public string Nombre { get; set; }
        public string Sexo { get; set; }

        [Column("Fecha de Nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }

        public string Área { get; set; }
        public string Subarea { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All, ReadOnly = true)]
        public List<CourseModel> Cursos { get; set; }
    }
}