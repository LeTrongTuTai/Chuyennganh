using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace DoanMVC.Models
{
    [Serializable]
    public class CartItem
    {
        public PRODUCT Product { set; get; }
        public int Quantity { set; get; }

    }
}