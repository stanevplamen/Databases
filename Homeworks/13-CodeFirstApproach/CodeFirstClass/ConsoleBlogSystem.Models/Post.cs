using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlogSystem.Models
{
    public class Post
    {
        private ICollection<PostAnswer> answers;
        private ICollection<Tag> tags;

        public Post()
        {
            this.answers = new HashSet<PostAnswer>();
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        //[Column("SubContent")]
        public string Content { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<PostAnswer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        //[NotMapped]
        public PostType Type { get; set; }
    }
}
