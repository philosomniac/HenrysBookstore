using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HenrysBookstore
{
    public partial class BOOK
    {
        private string thumbnailpath = string.Empty;
        private string largeimagepath = string.Empty;
        private string basepath = string.Empty;
        private string largeimagefilename = "large.jpg";
        private string thumbnailfilename = "thumb.jpg";

        private void Initialize()
        {
            basepath = $@"/Content/Images/{this.BOOK_CODE}/";
            largeimagepath = basepath + largeimagefilename;
            thumbnailpath = basepath + thumbnailfilename;
        }

        public string getThumbnailPath()
        {
            if (thumbnailpath.Length == 0)
            {
                Initialize();
            }

            return thumbnailpath;
        }

        public string getLargeImagePath()
        {
            if(largeimagepath.Length == 0)
            {
                Initialize();
            }

            return largeimagepath;
        }
    }
}