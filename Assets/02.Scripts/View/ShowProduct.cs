using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using ProductsData;

namespace ProductsView
{
    /// <summary>
    /// 根据数据，展示不同的商品卡牌
    /// </summary>
    public class ShowProduct : MonoBehaviour
    {
        //获得单个售卖卡片对象的预制体
        [SerializeField] private GameObject coinObjectClone;
        //获取锁住的商品ui
        [SerializeField] private GameObject sellLockObjectClone;
        
        private void Start()
        {
            //实例化 获取商品数据的类
            GetDailyProducts getDailyProducts = new GetDailyProducts();
            //调用Awake方法，得到商品数据
            getDailyProducts.Awake();
            
            //获取产品数据List
            List<DailyProduct> dailyProducts = GetDailyProducts.DailyProductss;

            //补齐商品数量数量为3的倍数
            for (int i = 0; i < dailyProducts.Count+(3-dailyProducts.Count % 3); ++i)
            {
                //这里设置 正常的有数据记载的商品
                if (i < dailyProducts.Count)
                {
                    //实例化一个 克隆的物体
                    GameObject coinObject = GameObject.Instantiate(coinObjectClone, transform);
                    
                    //得到当前对象下的 子对象集合类
                    ProductComponents components = coinObject.GetComponent<ProductComponents>();
                    
                    //调用初始化函数
                    components.setInit(dailyProducts[i].Type, 
                        dailyProducts[i].SubType,
                        dailyProducts[i].Num,
                        dailyProducts[i].IsPurchased);
                
                    //获取这个克隆物体的transform
                    RectTransform rtf = coinObject.transform as RectTransform;
                    //获取到transform后，将这个克隆物体的 父类 设置为 当前脚本所挂载的对象
                    if (!(rtf is null))
                    {
                        rtf.SetParent(transform);
                        //设置位置
                        rtf.position = new Vector3(0, 0, 0);
                        //设置缩放
                        rtf.localScale = new Vector3(1, 1, 1);
                        //设置旋转
                        rtf.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    }
                }
                else//这里设置多出来的 待解锁的商品栏位
                {
                    //实例化一个 克隆的物体
                    GameObject coinObject = GameObject.Instantiate(sellLockObjectClone, transform);
                
                    //获取这个克隆物体的transform
                    RectTransform rtf = coinObject.transform as RectTransform;
                    //获取到transform后，将这个克隆物体的 父类 设置为 当前脚本所挂载的对象
                    if (!(rtf is null))
                    {
                        rtf.SetParent(transform);
                        //设置位置
                        rtf.position = new Vector3(0, 0, 0);
                        //设置缩放
                        rtf.localScale = new Vector3(1, 1, 1);
                        //设置旋转
                        rtf.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    }
                }
                
                
            }
        }

    }

}