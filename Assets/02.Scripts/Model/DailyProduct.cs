using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每日精选 的 商品实体类
/// </summary>
public class DailyProduct
{
    private int productId;
    private int type;
    private int subType;
    private int num;
    private int costGold;
    private int isPurchased;

    public int ProductId
    {
        get => productId;
        set => productId = value;
    }

    public int Type
    {
        get => type;
        set => type = value;
    }

    public int SubType
    {
        get => subType;
        set => subType = value;
    }

    public int Num
    {
        get => num;
        set => num = value;
    }

    public int CostGold
    {
        get => costGold;
        set => costGold = value;
    }

    public int IsPurchased
    {
        get => isPurchased;
        set => isPurchased = value;
    }
}
