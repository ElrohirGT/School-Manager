using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Mobile.Models
{
    [Table("Usuario")]
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }

        [ForeignKey(typeof(RoleModel))]
        public int IdRol { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public RoleModel Rol { get; set; }

        public string Nombre { get; set; }
        public string Contraseña { get; set; }
    }
}