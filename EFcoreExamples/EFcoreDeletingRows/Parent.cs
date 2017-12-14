using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreDeletingRows
{
    public class Parent
    {
        public string Id { get; set; }
        public string RootId { get; set; }
        public string Name { get; set; }
        [InverseProperty("ParentEntity")]
        public virtual ICollection<Child> Children { get; set; }

        [ForeignKey("RootId")]
        [InverseProperty("Children")]
        public virtual Root RootEntity { get; set; }

        public Parent()
        {
            this.Children = new HashSet<Child>();
        }
    }
}
