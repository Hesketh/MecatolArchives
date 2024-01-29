using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesketh.MecatolArchives.API.Data
{
    public sealed class Expansion : IEntity
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; } = null!;
    }
}
