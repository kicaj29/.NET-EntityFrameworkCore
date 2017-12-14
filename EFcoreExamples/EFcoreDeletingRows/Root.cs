using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreDeletingRows
{
    public class Root
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("RootEntity")]
        public virtual ICollection<Parent> Children { get; set; }
    }
}
