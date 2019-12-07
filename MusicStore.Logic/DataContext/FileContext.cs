using System;
using System.Collections.Generic;
using System.Linq;
using CommonBase.Extensions;

namespace MusicStore.Logic.DataContext
{
    internal abstract class FileContext : ContextObject
    {
        protected IEnumerable<T> GetSaveItems<T>(IEnumerable<T> source) where T : Entities.IdentityObject
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            List<T> result = new List<T>();

            foreach (var item in source)
            {
                if (item.Id == 0)
                {
                    item.Id = source.NextValue(i => i.Id);
                }
                result.Add(item);
            }
            return result;
        }

        protected static List<T> LoadFromCsv<T>() where T : class, new()
        {
            return new List<T>(FileHelper.ReadFromCsv<T>(FileHelper.GetCsvFilePath(typeof(T))));
        }

        protected IEnumerable<T> SaveToCsv<T>(IEnumerable<T> source) where T : Entities.IdentityObject
        {
            IEnumerable<T> result = GetSaveItems<T>(source);
            string filePath = FileHelper.GetCsvFilePath(typeof(T));

            FileHelper.WriteToCsv<T>(filePath, result.ToArray());
            return result;
        }

        protected static List<T> LoadFromSer<T>() where T : class, new()
        {
            string filePath = FileHelper.GetSerFilePath(typeof(T));

            return new List<T>(FileHelper.Deserialize<T>(filePath));
        }

        protected IEnumerable<T> SaveToSer<T>(IEnumerable<T> source) where T : Entities.IdentityObject
        {
            IEnumerable<T> result = GetSaveItems<T>(source);
            string filePath = FileHelper.GetSerFilePath(typeof(T));

            FileHelper.Serialize(filePath, result);
            return result;
        }
    }
}
