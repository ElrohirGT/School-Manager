using Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile.Services.DataAccess
{
    public class MockDatabase : ISchoolManagerDatabase
    {
        public readonly string[] AREAS = new string[]
        {
           "Numérica",
           "Ciencias Naturales",
           "Lingüística",
           "Deportiva",
           "Música"
        };

        public readonly string[] STUDENTS_NAMES = new string[]
        {
            "Flavio Galán",
            "Erick Sagastume",
            "Pedro Picapiedra",
            "Juan Pineda",
            "Felix Reparador"
        };

        public readonly string[] SUBAREA = new string[]
        {
            "Matemática",
            "Ciencias Sociales",
            "Literatura",
            "Estadística",
            "Física"
        };

        public readonly string[] TEACHER_NAMES = new string[]
                                {
            "Javier Álvarez",
            "Adolfo Galán",
            "Alejandro Acosta",
            "Wotzbelí Aguilar"
        };

        private const int MAX_WAIT_TIME = 500;
        private List<AssignationModel> _assignations = new List<AssignationModel>();
        private List<CourseModel> _courses = new List<CourseModel>();
        private Random _generator = new Random();

        private List<GradeModel> _grades = new List<GradeModel>()
        {
            new GradeModel(){IdGrado = 1, Nombre = "Primero Básico A"},
            new GradeModel(){IdGrado = 2, Nombre = "Quinto Bachillerato A"}
        };

        private List<StudentModel> _students = new List<StudentModel>();
        private List<TeacherModel> _teachers = new List<TeacherModel>();

        private List<UserModel> _users = new List<UserModel>()
        {
            new UserModel()
            {
                IdUsuario = 1,
                IdRol = (int)Roles.Administrador,
                Nombre = "Admin",
                Contraseña = "admin"
            }
        };

        public MockDatabase()
        {
            for (int i = 0; i < _grades.Count * 2; i++)
            {
                UserModel user = CreateRandomUser(Roles.Profesor);
                TeacherModel teacher = CreateRandomTeacher(user);
                CreateRandomCourse(teacher, _grades[i / 2]);
            }
            for (int i = 0; i < _courses.Count * 5; i++)
            {
                UserModel user = CreateRandomUser(Roles.Estudiante);
                StudentModel student = CreateRandomStudent(user);
                CreateRandomAssignation(student, _courses[i / 5]);
            }
        }

        private delegate void GetLasIdMethod<T>(ref int id, T item);

        public async Task<IEnumerable<T>> GetAllItemsFrom<T>() where T : new()
        {
            var type = typeof(T);
            await RandomTime();
            if (type.Equals(typeof(CourseModel)))
                return (IEnumerable<T>)_courses;
            else if (type.Equals(typeof(AssignationModel)))
                return (IEnumerable<T>)_assignations;
            else if (type.Equals(typeof(GradeModel)))
                return (IEnumerable<T>)_grades;
            return null;
        }

        public async Task<IEnumerable<T>> GetAllItemsFrom<T>(System.Linq.Expressions.Expression<Func<T, bool>> filter, bool recursive = true)
            where T : new()
        {
            var type = typeof(T);
            await RandomTime();
            if (filter == null)
                return await GetAllItemsFrom<T>();
            if (type.Equals(typeof(CourseModel)))
            {
                Func<T, bool> compiledFunc = filter.Compile();
                Func<CourseModel, bool> func = (item) => compiledFunc.Invoke((T)Convert.ChangeType(item, type));
                return (IEnumerable<T>)_courses.Where(func);
            }
            if (type.Equals(typeof(AssignationModel)))
            {
                Func<T, bool> compiledFunc = filter.Compile();
                Func<AssignationModel, bool> func = (item) => compiledFunc.Invoke((T)Convert.ChangeType(item, type));
                return (IEnumerable<T>)_assignations.Where(func);
            }
            return null;
        }

        public async Task<T> GetItemWithId<T>(int selectedId, bool recursive = true) where T : new()
        {
            var type = typeof(T);
            await RandomTime();
            if (type.Equals(typeof(CourseModel)))
                return ((IEnumerable<T>)_courses.Where(c => c.IdCurso == selectedId)).FirstOrDefault();
            if (type.Equals(typeof(AssignationModel)))
                return ((IEnumerable<T>)_assignations.Where(a => a.IdAsignacion == selectedId)).FirstOrDefault();
            return default(T);
        }

        public async Task<int> GetStudentId(UserModel user)
        {
            int index = _students.FindIndex(s => s.Usuario.IdUsuario == user.IdUsuario);
            await RandomTime();
            if (index == -1)
                return -1;
            return _users[index].IdUsuario;
        }

        public async Task<int> GetTeacherId(UserModel user)
        {
            int index = _teachers.FindIndex(t => t.Usuario.IdUsuario == user.IdUsuario);
            await RandomTime();
            if (index == -1)
                return -1;
            return _teachers[index].IdProfesor;
        }

        public async Task<UserModel> LogIn(string userName, string password)
        {
            int index = _users.FindIndex(u => u.Nombre == userName && u.Contraseña == password);
            await RandomTime();
            if (index == -1)
                return null;
            return _users[index];
        }

        #region Random Data Generators

        private void CreateRandomAssignation(StudentModel student, CourseModel courseModel)
        {
            int newId = GetNewIdOf(_assignations, (ref int i, AssignationModel a) => i = Math.Max(a.IdAsignacion, i));
            var assignation = new AssignationModel()
            {
                IdAsignacion = newId,
                Curso = courseModel,
                Estudiante = student,
                NotaIU = (uint)_generator.Next(100),
                NotaIIU = (uint)_generator.Next(100),
                NotaIIIU = (uint)_generator.Next(100),
                NotaIVU = (uint)_generator.Next(100)
            };
            _assignations.Add(assignation);
        }

        private CourseModel CreateRandomCourse(TeacherModel teacher, GradeModel grade)
        {
            int newId = GetNewIdOf(_courses, (ref int i, CourseModel c) => i = Math.Max(c.IdCurso, i));
            var course = new CourseModel()
            {
                IdCurso = newId,
                Grado = grade,
                Profesor = teacher,
                Nombre = GetRandomValue(SUBAREA),
            };
            _courses.Add(course);
            return course;
        }

        private StudentModel CreateRandomStudent(UserModel user)
        {
            int newId = GetNewIdOf(_students, (ref int i, StudentModel s) => i = Math.Max(s.IdEstudiante, i));
            var student = new StudentModel()
            {
                IdEstudiante = newId,
                Usuario = user,
                Nombre = GetRandomValue(STUDENTS_NAMES),
                Encargado = GetRandomValue(TEACHER_NAMES),
                FechaDeNacimiento = RandomDay(),
                Sexo = RandomGender()
            };
            _students.Add(student);
            return student;
        }

        private TeacherModel CreateRandomTeacher(UserModel user)
        {
            int newId = GetNewIdOf(_teachers, (ref int i, TeacherModel t) => i = Math.Max(t.IdProfesor, i));
            var teacher = new TeacherModel()
            {
                IdProfesor = newId,
                Usuario = user,
                Nombre = GetRandomValue(TEACHER_NAMES),
                Área = GetRandomValue(AREAS),
                Subarea = GetRandomValue(SUBAREA),
                Sexo = RandomGender(),
                FechaDeNacimiento = RandomDay()
            };
            _teachers.Add(teacher);
            return teacher;
        }

        private UserModel CreateRandomUser(Roles role)
        {
            int newId = GetNewIdOf(_users, (ref int i, UserModel u) =>
            {
                if (u.IdUsuario > i)
                    i = u.IdUsuario;
            });
            var user = new UserModel()
            {
                IdUsuario = newId,
                IdRol = (int)role,
                Nombre = $"{role}{newId}",
                Contraseña = role.ToString().ToLower()
            };
            _users.Add(user);
            return user;
        }

        private int GetNewIdOf<T>(List<T> list, GetLasIdMethod<T> action)
        {
            int lastId = 0;
            list.ForEach(i => action(ref lastId, i));
            return ++lastId;
        }

        private string GetRandomValue(string[] array) => array[_generator.Next(array.Length)];

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_generator.Next(range));
        }

        #endregion Random Data Generators

        private string RandomGender() => (_generator.Next(1) == 0) ? "Masculino" : "Femenino";

        private Task RandomTime() => Task.Delay(_generator.Next(MAX_WAIT_TIME));
    }
}