using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobile.Models
{
    [Table("Asignacion")]
    public class AssignationModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdAsignacion { get; set; }

        [ForeignKey(typeof(CourseModel))]
        public int IdCurso { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public CourseModel Curso { get; set; }

        [ForeignKey(typeof(StudentModel))]
        public int IdEstudiante { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public StudentModel Estudiante { get; set; }

        [Column("Nota IU")]
        public uint? NotaIU { get; set; }

        [Column("Nota IIU")]
        public uint? NotaIIU { get; set; }

        [Column("Nota IIIU")]
        public uint? NotaIIIU { get; set; }

        [Column("Nota IVU")]
        public uint? NotaIVU { get; set; }
    }
}