using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 数据准备：
/// 包含 dailyProduct 的商品对应的实体类
/// 并在启动时解析 dailyProduct 的 Json 文件数据，存储在变量 DailyProducts 中
/// </summary>
public class GetDailyProducts : MonoBehaviour
{
    public static List<DailyProduct.dailyProduct> DailyProductss;

    void Awake()
    {
        //打印查看 Application.dataPath 的具体根路径
        Debug.Log("=============" + Application.dataPath);
        //配置流读取路径
        StreamReader sr = new StreamReader(Application.dataPath + "/Function1/06.JsonData/data.json");
        /*if (sr == null)
        {
            Debug.Log("读取Json数据文件失败");
        }*/

        //加载Assets文件夹下的Json文件，通过流读取，获取它里面的数据内容
        string dps = sr.ReadToEnd();
        Debug.Log(dps);

        //根据json文件的内容，解析成对应的数据结构，并存储起来
        DailyProduct.dailyProducts dpInfo = JsonUtility.FromJson<DailyProduct.dailyProducts>(dps);
        //打印数据数量
        Debug.Log(dpInfo.dailyProduct.Count);
        //记录下 加载解析出来的商店售卖的商品信息
        DailyProductss = dpInfo.dailyProduct;

        /*for (int i = 0; i < dpInfo.dailyProduct.Count; i++)
        {
            DailyProduct.dailyProduct dp = new DailyProduct.dailyProduct{productId = dpInfo.dailyProduct[i].productId};
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
