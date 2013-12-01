using DatabaseStructure.Data;
using DatabaseStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseStructure
{
    class MainDemo
    {
        public static string DocPath = "..\\..\\collection.xml";

        static void Main()
        {
            CheckCurrentAlbums();
            TestAddAlbum();
            TestRemoveAlbum();
        }

        private static void CheckCurrentAlbums()
        {
            AlbumStore loadedAlbumCollection = new AlbumStore();
            loadedAlbumCollection.AlbumStores = DataPersister.GetStores(DocPath);
        }

        private static void TestAddAlbum()
        {
            Produser ivan = new Produser { RealName = "Ivan Ivanov", NickName = "Ivans House" };
            Artist gosho = new Artist { RealName = "Georgi Ivanov", NickName = "Gosho Kitarata" };

            IEnumerable<Song> tempList = new List<Song>() { new Song() { Title = "FirstSong", Seconds = 300 }, new Song() { Title = "SecondsSong", Seconds = 270 } };

            Album newGoshoAlbum = new Album();
            newGoshoAlbum.AlbumName = "Gosho Tapoto Crazy";
            newGoshoAlbum.AlbumArtist = gosho;
            newGoshoAlbum.Year = DateTime.Now.Year;
            newGoshoAlbum.AlbumProduser = ivan;
            newGoshoAlbum.Price = 33.90m;
            newGoshoAlbum.SongsList = tempList;

            DataPersister.AddAlbum(DocPath, newGoshoAlbum);
            if (tempList != null && tempList.Count() > 1)
            {
                foreach (var song in tempList)
                {
                    DataPersister.AddSongs(DocPath, song, newGoshoAlbum.AlbumName);
                }
            }
        }

        private static void TestRemoveAlbum()
        {
            DataPersister.RemoveAlbum(DocPath, new Album() { AlbumName = "Default album" });  
        }
    }
}
