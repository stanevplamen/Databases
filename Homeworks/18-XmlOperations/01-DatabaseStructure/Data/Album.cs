using DatabaseStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStructure.Data
{
    public class Album
    {
        public string AlbumName { get; set; }
        public Artist AlbumArtist { get; set; }
        public int Year { get; set; }
        public Produser AlbumProduser { get; set; }
        public decimal Price { get; set; }
        private List<Song> songsList;

        public IEnumerable<Song> SongsList
        {
            get
            {
                return songsList;
            }
            set
            {
                if (this.songsList == null)
                {
                    this.songsList = new List<Song>();
                }
                this.songsList.Clear();
                foreach (var item in value)
                {
                    this.songsList.Add(item);
                }
            }
        }
    }
}
