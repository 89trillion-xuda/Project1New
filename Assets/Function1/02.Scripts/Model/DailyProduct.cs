using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyProduct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// 作为json读取的中间数据结构，用来装载json内容
    /// </summary>
    public class dailyProducts
    {
        public List<dailyProduct> dailyProduct;
    }
    
    /// <summary>
    /// 商店售卖物品信息数据
    /// </summary>
    //增加序列化特性，防止出错
    [System.Serializable]
    public class dailyProduct
    {
        public int productId;
        public int type;
        public int subType;
        public int num;
        public int costGold;
        public int isPurchased;
    }
}
