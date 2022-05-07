using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pandoranime.Core.AniList;

namespace Pandoranime.Models
{
    public class PaginationGroup : List<MediaItemModel>
    {
        public string Name { get; private set; }

        public PaginationGroup(string name, List<MediaItemModel> animes) : base(animes)
        {
            Name = name;
        }
    }
}
