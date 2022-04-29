using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoranimeService.Models._9Anime
{
    public class AnimeByPageModel
    {
        private string _name;
        private string _url;
        private string _imageUrl;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value;}
        }
    }
}
