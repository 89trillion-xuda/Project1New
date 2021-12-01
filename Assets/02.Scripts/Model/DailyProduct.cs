using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProductsData
{
    /// <summary>
    /// 每日精选 的 商品实体类
    /// </summary>
    public class DailyProduct
    {
        public int ProductId { get; set; }

        public int Type { get; set; }

        public int SubType { get; set; }

        public int Num { get; set; }

        public int CostGold { get; set; }

        public int IsPurchased { get; set; }
    }

}