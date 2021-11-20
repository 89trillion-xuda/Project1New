using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 根据数据，展示不同的商品卡牌
/// </summary>
public class ShowProduct : MonoBehaviour
{
    //获得单个售卖卡片对象的预制体
    [SerializeField] private GameObject CoinObjectClone;
    //获取需要动态改变的商品组件集合类
    [SerializeField] private ProductComponents ProductComponentsClone;

    void Start()
    {
        //实例化 获取商品数据的类
        GetDailyProducts getDailyProducts = new GetDailyProducts();
        //调用Awake方法，得到商品数据
        getDailyProducts.Awake();

        //获取需要动态改变的商品卡片背景对象
        GameObject sellContentBgImg = ProductComponentsClone.sellContentBgImg;
        //获取需要动态改变的商品卡片
        Image sellContentImg = ProductComponentsClone.sellContentImg;
        //获取需要动态改变的商品数量
        Text sellSumTxt = ProductComponentsClone.sellSumTxt;
        //获取需要动态设置的购买按钮
        GameObject sellSpendBtn = ProductComponentsClone.sellSpendBtn;
        //获取需要动态设置的购买完成按钮
        GameObject sellFinishBtn = ProductComponentsClone.sellFinishBtn;
        //获取产品数据List
        List<DailyProduct> dailyProducts = GetDailyProducts.DailyProductss;

        //补齐商品数量数量为3的倍数
        for (int i = 0; i < dailyProducts.Count+(3-dailyProducts.Count % 3); ++i)
        {
            //这里设置 正常的有数据记载的商品
            if (i < dailyProducts.Count)
            {
                //除了卡片以外的商品不需要卡片背景
                if (dailyProducts[i].Type != 3)
                {
                    sellContentBgImg.SetActive(false);
                }
                else
                {
                    sellContentBgImg.SetActive(true);
                }

                //设置商品图片资源
                if (dailyProducts[i].Type == 2)
                {
                    sellContentImg.sprite = Resources.Load("diamond_2", typeof(Sprite)) as Sprite;
                }else if (dailyProducts[i].Type == 3)
                {
                    sellContentImg.sprite = Resources.Load(dailyProducts[i].SubType.ToString(), typeof(Sprite)) as Sprite;
                }
                
                //设置商品售卖的数量
                sellSumTxt.text = dailyProducts[i].Num.ToString();
                
                //判断商品售卖状态，未售卖就显示购买按钮
                if (dailyProducts[i].IsPurchased == 1)
                {
                    sellSpendBtn.SetActive(false);
                }
                else
                {
                    sellSpendBtn.SetActive(true);
                }
                //显示购买完成的✅
                sellFinishBtn.SetActive(true);
            }
            else//这里设置多出来的 待解锁的商品栏位
            {
                //去除卡片用的背景
                sellContentBgImg.SetActive(false);
                //设置商品图片资源
                sellContentImg.sprite = Resources.Load("shop_lock", typeof(Sprite)) as Sprite;
                //缩放一下 不然太大了 0.87
                RectTransform ts = sellContentImg.gameObject.transform as RectTransform;
                ts.localScale = new Vector3(0.87f, 0.87f, 0.87f);
                //调整位置，偏下一点
                ts.position = new Vector3(ts.position.x, ts.position.y - 0.1f, ts.position.z);
                //设置标题文字为 "待解锁"
                sellSumTxt.text = "待解锁";
                //隐藏购买按钮
                sellSpendBtn.SetActive(false);
                //隐藏购买完成按钮
                sellFinishBtn.SetActive(false);
            }
            
            //实例化一个 克隆的物体
            GameObject CoinObject = GameObject.Instantiate(CoinObjectClone,transform) as GameObject;
            
            //获取这个克隆物体的transform
            RectTransform rtf = CoinObject.transform as RectTransform;
            //获取到transform后，将这个克隆物体的 父类 设置为 当前脚本所挂载的对象
            rtf.SetParent(transform);
            //设置位置
            rtf.position = new Vector3(0, 0, 0);
            //设置缩放
            rtf.localScale = new Vector3(1, 1, 1);
            //设置旋转
            rtf.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        
        //最后还原一下单个商品预制体，让它变回原来的样子
        Invoke("InitCard",1);
    }

    //还原商品预制体方法
    public void InitCard()
    {
        //ProductCompponents中的还原方法
        ProductComponentsClone.Init();
    }

}
