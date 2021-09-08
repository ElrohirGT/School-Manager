using Foundation;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Mobile.iOS.DBConnectionCreator))]

namespace Mobile.iOS
{
    public class DBConnectionCreator : IDBConnectionCreator
    {
        public SQLiteAsyncConnection Create()
        {
            var sqliteFilename = Constants.DB_FILENAME;

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);
            string path = Path.Combine(libFolder, sqliteFilename);

            // This is where we copy in the pre-created database
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("SchoolManagerDB", "db");
                File.Copy(existingDb, path);
            }

            return new SQLiteAsyncConnection(path);
        }
    }
}