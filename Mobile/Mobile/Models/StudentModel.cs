using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace Mobile.Models
{
    [Table("Estudiante")]
    public class StudentModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdEstudiante { get; set; }

        [ForeignKey(typeof(UserModel))]
        public int IdUsuario { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public UserModel Usuario { get; set; }

        public string Nombre { get; set; }
        public string Sexo { get; set; }

        [Column("Fecha de Nacimineto")]
        public DateTime FechaDeNacimiento { get; set; }

        public string Encargado { get; set; }
    }
}