using System;
using System.Collections.Generic;
using System.Text;

namespace _053506_Ermolaev_Lab7
{
    struct Order
    {
        public Order(int kilograms,string rate,int discount,double sum)
        {
            Kilograms = kilograms;
            Rate = rate;
            Discount = discount;
            Sum = sum;
        }
        public int Kilograms { get; set; }
        public string Rate { get; set; }
        public int Discount { get; set; }
        public double Sum { get; set; }
    }
}
