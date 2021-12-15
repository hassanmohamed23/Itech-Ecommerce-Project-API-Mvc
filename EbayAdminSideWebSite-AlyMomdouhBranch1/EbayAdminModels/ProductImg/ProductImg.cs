namespace Models
{
    using System.Collections.Generic;

    public class ProductImg
    {
        public int ProductId { get; set; }
        public int ImgId { get; set; }
        public string src { get; set; }

        public Product product { get; set; }

        public static List<ProductImg> Create(string[] imgspathes)
        {
            if (imgspathes.Length>0)
            {
                var proImgs = new List<ProductImg>();
                foreach (var item in imgspathes)
                {
                    var proImg = new ProductImg() { src = item  };
                    proImgs.Add(proImg);
                }
                return proImgs;
            }
            return null;
        }
    }
}
