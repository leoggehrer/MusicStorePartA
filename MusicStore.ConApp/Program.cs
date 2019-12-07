using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.ConApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Copy async
            //await CopyDataFromToByLogicAsync(Logic.Factory.PersistenceType.Csv, Logic.Factory.PersistenceType.Ser);
            // Copy sync		
            //CopyDataFromToByLogic(Logic.Factory.PersistenceType.Csv, Logic.Factory.PersistenceType.Db);

            // Output async
            //await PrintDataAdapterAsync(Adapters.Factory.AdapterType.Service);
            await PrintDataLogicAsync(Logic.Factory.PersistenceType.Ser);
            // Output sync
        }

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
        static async Task CopyDataFromToByLogicAsync(Logic.Factory.PersistenceType source, Logic.Factory.PersistenceType target)
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
                    foreach (var item in await genreCtrl.GetAllAsync())
                    {
                        await genreCpyCtrl.InsertAsync(item);
                    }
                    await genreCpyCtrl.SaveChangesAsync();

                    foreach (var item in await artistCtrl.GetAllAsync())
                    {
                        await artistCpyCtrl.InsertAsync(item);
                    }
                    await artistCpyCtrl.SaveChangesAsync();

                    foreach (var item in await albumCtrl.GetAllAsync())
                    {
                        await albumCpyCtrl.InsertAsync(item);
                    }
                    await albumCpyCtrl.SaveChangesAsync();

                    foreach (var item in await trackCtrl.GetAllAsync())
                    {
                        await trackCpyCtrl.InsertAsync(item);
                    }
                    await trackCpyCtrl.SaveChangesAsync();
                }
            }
        }
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
        static async Task PrintDataLogicAsync(Logic.Factory.PersistenceType source)
        {
            Logic.Factory.Persistence = source;
            using (var genreCtrl = Logic.Factory.CreateGenreController())
            using (var artistCtrl = Logic.Factory.CreateArtistController(genreCtrl))
            using (var albumCtrl = Logic.Factory.CreateAlbumController(genreCtrl))
            using (var trackCtrl = Logic.Factory.CreateTrackController(genreCtrl))
            {
                Console.WriteLine("Write all genres");
                foreach (var item in await genreCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all artists");
                foreach (var item in await artistCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }

                Console.WriteLine("Write all alben");
                foreach (var item in await albumCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }

                Console.WriteLine("Write all tracks");
                foreach (var item in await trackCtrl.GetAllAsync())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }
    }
}

