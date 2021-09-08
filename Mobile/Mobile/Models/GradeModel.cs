using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Mobile.Models
{
    [Table("Grado")]
    public class GradeModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdGrado { get; set; }

        public string Nombre { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All, ReadOnly = true)]
        public List<CourseModel> Cursos { get; set; }
    }
}