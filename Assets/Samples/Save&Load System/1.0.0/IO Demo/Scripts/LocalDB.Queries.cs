
using com.alec.io;
using Newtonsoft.Json;
using System.Collections.Generic;

public static partial class LocalDB
{
    internal static class Queries
    {

        #region Book Data

        public static void UpdateBook(string bookID, Dictionary<string, object> bookEntry)
        {
            if (dbRootRef == null) Initialize((result) => { });

            if (dbBooksRef.ContainsKey(bookID))
            {
                dbBooksRef[bookID] = JsonConvert.SerializeObject(bookEntry, Formatting.Indented);
            }
            else
            {
                dbBooksRef.Add(bookID, JsonConvert.SerializeObject(bookEntry, Formatting.Indented));
            }
            IO.Save(dbRootRef);
        }

        internal static Book.Model GetBookWithID(string bookID)
        {
            if (dbRootRef == null) Initialize((result) => { });

            Book.Model bookEntry = null;
            if (dbBooksRef.ContainsKey(bookID))
            {
                bookEntry = new Book.Model(dbBooksRef[bookID].ToString());
            }
            return bookEntry;
        }
        #endregion

        #region Chapters Data
     
        public static void UpdateChapter(string chapterId, Dictionary<string, object> chapterEntry)
        {
            if (dbRootRef == null) Initialize((result) => { });

            if (dbChaptersRef.ContainsKey(chapterId))
            {
                dbChaptersRef[chapterId] = JsonConvert.SerializeObject(chapterEntry, Formatting.Indented);
            }
            else
            {
                dbChaptersRef.Add(chapterId, JsonConvert.SerializeObject(chapterEntry, Formatting.Indented));
            }
            IO.Save(dbRootRef);
        }
        internal static Chapter.Model GetChapterWithID(string chapterId)
        {
            if (dbRootRef == null) Initialize((result) => { });

            Chapter.Model chapterModel = null;
            if (dbChaptersRef.ContainsKey(chapterId))
            {
                chapterModel = new Chapter.Model(dbChaptersRef[chapterId].ToString());
            }
            return chapterModel;
        }
        #endregion
    }
}

public class Book
{
    public class Model
    {
        public Model(string json)
        {

        }
        public Model(Dictionary<string, object> dictionary)
        {

        }
    }
}


public class Chapter
{
    public class Model
    {
        public Model(string json)
        {

        }
        public Model(Dictionary<string, object> dictionary)
        {

        }
    }
}
