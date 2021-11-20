using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;

/// <summary>
/// 数据准备：
/// 通过SimpleJson解析json格式的商品数据，存储在List类型的 DailyProductss 中
/// </summary>
public class GetDailyProducts
{
    public static List<DailyProduct> DailyProductss = new List<DailyProduct>();

    //通过SimpleJson解析，得到商品数据
    public void Awake()
    {
        //获得数据文件路径下的text格式数据
        TextAsset filePath = (TextAsset)Resources.Load("JsonData/data");
        //转为Json格式
        JSONNode jsonNode = JSON.Parse(filePath.text);
        //取出第一个数据的值 即：jsonNode[0]，里面存有所有商品信息
        JSONNode jsonNode1 = jsonNode[0];

        //循环遍历json数据，并映射到实体类DailyProduct中
        for (int  i = 0; i < jsonNode1.Count; i++)
        {
            //实例化一个商品对象，用于映射json数据
            DailyProduct dailyProductNode = new DailyProduct();
            dailyProductNode.ProductId = jsonNode1[i]["productId"];
            dailyProductNode.Type = jsonNode1[i]["type"];
            dailyProductNode.SubType = jsonNode1[i]["subType"];
            dailyProductNode.Num = jsonNode1[i]["num"];
            dailyProductNode.CostGold = jsonNode1[i]["costGold"];
            dailyProductNode.IsPurchased = jsonNode1[i]["isPurchased"];
            
            //通过数组存储数据
            DailyProductss.Add(dailyProductNode);
        }
    }
}
