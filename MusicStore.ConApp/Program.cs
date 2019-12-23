using System;

namespace MusicStore.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Copy sync		
            //CopyDataFromToByLogic(Logic.Factory.PersistenceType.Csv, Logic.Factory.PersistenceType.Db);

            // Output sync
            PrintDataLogic(Logic.Factory.PersistenceType.Ser);
        }
        /// <summary>
        /// Kopiert die Daten von der Quelle zum angegebenen Ziel.
        /// </summary>
        /// <param name="source">Daten-Quelle</param>
        /// <param name="target">Zielspeicher</param>
        static void CopyDataFromToByLogic(Logic.Factory.PersistenceType source, Logic.Factory.PersistenceType target)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Logic.Factory.Persistence = target;
                using (var genreCpyCtrl = Logic.Factory.CreateGenreController())
                using (var artistCpyCtrl = Logic.Factory.CreateArtistController(genreCpyCtrl))
                using (var albumCpyCtrl = Logic.Factory.CreateAlbumController(genreCpyCtrl))
                using (var trackCpyCtrl = Logic.Factory.CreateTrackController(genreCpyCtrl))
                {
                    foreach (var item in genreCtrl.GetAll())
                    {
                        genreCpyCtrl.Insert(item);
                    }
                    genreCpyCtrl.SaveChanges();

                    foreach (var item in artistCtrl.GetAll())
                    {
                        artistCpyCtrl.Insert(item);
                    }
                    artistCpyCtrl.SaveChanges();

                    foreach (var item in albumCtrl.GetAll())
                    {
                        albumCpyCtrl.Insert(item);
                    }
                    albumCpyCtrl.SaveChanges();

                    foreach (var item in trackCtrl.GetAll())
                    {
                        trackCpyCtrl.Insert(item);
                    }
                    trackCpyCtrl.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Gibt die Daten von der angegebenen Quelle auf die Konsole aus.
        /// </summary>
        /// <param name="source">Daten-Quelle</param>
        static void PrintDataLogic(Logic.Factory.PersistenceType source)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Console.WriteLine("Write all genres");
                foreach (var item in genreCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in artistCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in albumCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in trackCtrl.GetAll())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}

