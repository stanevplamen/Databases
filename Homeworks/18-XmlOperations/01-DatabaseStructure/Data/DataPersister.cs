using DatabaseStructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseStructure.Data
{
    public static class DataPersister
    {
        public static string tempP = String.Empty;

        public static IEnumerable<Album> GetStores(string albumsStoreDocumentPath)
        {
            try
            {
                var albumsDocumentRoot = XDocument.Load(albumsStoreDocumentPath).Root;

                var albumsVMs = from storeElement in albumsDocumentRoot.Elements("album")
                                select new Album()
                                {
                                    AlbumName = storeElement.Element("aname").Value,
                                    AlbumArtist = new Artist()
                                    {
                                        RealName = storeElement.Element("artist").Element("rname").Value,
                                        NickName = storeElement.Element("artist").Element("nname").Value,
                                        //musicStyle = Enum.Parse(typeof(MusicStyle),  (storeElement.Element("Artist").Element("version").Value)),
                                        musicStyle = MusicStyle.Commersial,
                                    },
                                    Year = int.Parse(storeElement.Element("year").Value),
                                    AlbumProduser = new Produser()
                                    {
                                        RealName = storeElement.Element("produser").Element("rname").Value,
                                        NickName = storeElement.Element("produser").Element("nname").Value,
                                    },
                                    Price = decimal.Parse(storeElement.Element("price").Value),
                                    SongsList =
                                    from albumElement in storeElement.Element("songs").Elements("song")
                                    select new Song()
                                    {
                                        Title = albumElement.Element("sname").Value,
                                        Seconds = int.Parse(albumElement.Element("seconds").Value)
                                    }
                                };

                return albumsVMs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file is not created exception with message: {0}", ex.Message);
                Console.WriteLine("Creating a new file");
                DataPersister.CreateFile();
                return DataPersister.GetStores(MainDemo.DocPath);
            }
        }

        public static void CreateFile()
        {          
            XElement aubumsXml = 

                    new XElement("albums", new XElement("album",
                        new XElement("aname", "Default album"),
                        new XElement("artist", 
                            new XElement("rname", "Real Name"),
                            new XElement("nname", "Nick Name")
                            ),
                        new XElement("year", "2013"),
                        new XElement("produser", 
                            new XElement("rname", "Real Name"),
                            new XElement("nname", "Nick Name")
                            ),
                        new XElement("price", "30.20"),
                        new XElement("songs", new XElement("song",
                            new XElement("sname", "FirstSong"),
                            new XElement("seconds", "270"))
                            )

                )
            );

            System.Console.WriteLine(aubumsXml);
            aubumsXml.Save(MainDemo.DocPath); 
        }

        internal static void AddAlbum(string documenPath, Album album)
        {
            var root = XDocument.Load(documenPath).Root;
            root.Add(new XElement("album",
                        new XElement("aname", album.AlbumName),
                        new XElement("artist",
                            new XElement("rname", album.AlbumArtist.RealName),
                            new XElement("nname", album.AlbumArtist.NickName)
                            ),
                        new XElement("year", album.Year),
                        new XElement("produser",
                            new XElement("rname", album.AlbumProduser.RealName),
                            new XElement("nname", album.AlbumProduser.NickName)
                            ),
                        new XElement("price", album.Price),
                        new XElement("songs", null)
                            ));


            root.Document.Save(documenPath);
        }

        internal static void RemoveAlbum(string documenPath, Album album)
        {
            var root = XDocument.Load(documenPath).Root;
            foreach (var storeChild in root.Elements("album"))
            {
                if (storeChild.Element("aname").Value.ToLower() == album.AlbumName.ToLower())
                {
                    storeChild.Remove();
                    root.Document.Save(documenPath);
                    break;
                }
            }
        }

        internal static void AddSongs(string documenPath, Song song, string albumName)
        {
            var root = XDocument.Load(documenPath).Root;
            XElement storeElement = null;
            foreach (var store in root.Elements("album"))
            {
                if (store.Element("aname").Value.ToLower() == albumName.ToLower())
                {
                    storeElement = store.Element("songs");
                    break;
                }
            }
            if (storeElement == null)
            {
                Console.WriteLine("Album of name did not found");
            }
            storeElement.Add(new XElement("song",
                            new XElement("sname", song.Title),
                            new XElement("seconds", song.Seconds))
                            );
            root.Document.Save(documenPath);
        }
    }
}