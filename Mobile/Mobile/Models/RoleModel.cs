using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Mobile.Models
{
    [Table("Rol")]
    public class RoleModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdRol { get; set; }

        public string Nombre { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All, ReadOnly = true)]
        public List<UserModel> Usuarios { get; set; }
    }
}