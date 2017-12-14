using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreDeletingRows
{
    public class Child
    {
        public int Id { get; set; }
        public string RootId { get; set; }
        public string Name { get; set; }

        public string ParentId { get; set; }

        [ForeignKey("ParentId,RootId")]
        [InverseProperty("Children")]
        public Parent ParentEntity { get; set; }
    }
}
