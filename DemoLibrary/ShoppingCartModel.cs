using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        public List<ProductModel> Items { get; set; }
        public decimal ItemPriceSum { get => Items.Sum(x => x.Price);}
        public ShoppingCartModel()
        {
            this.Items = new List<ProductModel>();
        }
        public delegate void MentionDiscount(decimal subtotal);
        public decimal GenerateTotal(MentionDiscount discountAlert, Func<List<ProductModel> , decimal , decimal> calcultateDiscount, Action<String> mentionDiscount)
        {
            discountAlert( this.ItemPriceSum);

            mentionDiscount("Applied discount. ");

            return calcultateDiscount(Items, this.ItemPriceSum);
        }
    }
}
