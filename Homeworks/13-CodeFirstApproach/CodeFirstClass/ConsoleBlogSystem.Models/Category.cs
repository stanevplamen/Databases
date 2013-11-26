using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlogSystem.Models
{
    public class Category
    {
        private ICollection<Post> posts;

        public Category()         
        {
            this.posts = new HashSet<Post>();
        }

        public int CategoryID { get; set; }

        public string Name{ get; set; }

        public int ParentId { get; set; }

        public virtual Category Parent { get; set; } // referent to itself

        public virtual ICollection<Post> Posts
        {
            get { return posts; }
            set { posts = value; }
        }            
    }
}
