using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobile.Models
{
    [Table("Curso")]
    public class CourseModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdCurso { get; set; }

        [ForeignKey(typeof(TeacherModel))]
        public int IdProfesor { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public TeacherModel Profesor { get; set; }

        [ForeignKey(typeof(GradeModel))]
        public int IdGrado { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public GradeModel Grado { get; set; }

        public string Nombre { get; set; }

        [Ignore]
        public string NombreCompleto => $"{Nombre}, {Grado.Nombre}";
    }
}