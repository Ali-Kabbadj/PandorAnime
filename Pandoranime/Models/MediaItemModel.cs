using Humanizer;
using Pandoranime.Core.AniList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandoranime.Models
{
    public class MediaItemModel
    {

        public int Id { get; }
        public string ImageUrl { get; }
        public string BannerImageUrl { get; }
        public string Title { get; }
        public string Format { get; }

        public MediaItemModel(Media media)
        {
            Id = media.Id;
            ImageUrl = media.Cover.ExtraLargeImageUrl;
            BannerImageUrl = media.BannerImageUrl;
            Title = media.Title.Preferred;
            Format = media.Format?.Humanize() ?? "???";
        }

    }
}
