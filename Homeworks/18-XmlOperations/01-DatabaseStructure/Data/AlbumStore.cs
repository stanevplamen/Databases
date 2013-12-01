using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseStructure.Data
{
    public class AlbumStore
    {
        public AlbumStore()
        {
            //this.AlbumStores = DataPersister.GetStores(MainDemo.DocPath);
        }

        private List<Album> albumStores;

        public IEnumerable<Album> AlbumStores
        {
            get
            {
                if (this.albumStores == null)
                {
                    this.AlbumStores = DataPersister.GetStores(MainDemo.DocPath);
                }
                return albumStores;
            }
            set
            {
                if (this.albumStores == null)
                {
                    this.albumStores = new List<Album>();
                }
                this.albumStores.Clear();
                foreach (var item in value)
                {
                    this.albumStores.Add(item);
                }
            }
        }
    }
}
