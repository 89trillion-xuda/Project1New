using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShowProduct : MonoBehaviour
{
    
    //定义一个变量，获取我们要克隆的物体，前提是该物体在预置体中
    public GameObject CoinObjectClone;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(GetDailyProducts.DailyProductss == null);
        //补齐商品数量数量为3的倍数
        for (int i = 0; i < GetDailyProducts.DailyProductss.Count+(3-GetDailyProducts.DailyProductss.Count % 3); ++i)
        {
            /*//实例化一个 克隆的物体
            GameObject SellCommodityObject = GameObject.Instantiate(SellCommodityObjectClone) as GameObject;
            //获取这个克隆物体的transform
            RectTransform rtf = SellCommodityObject.transform as RectTransform;
            //获取到transform后，将这个克隆物体的 父类 设置为 当前脚本所挂载的对象
            rtf.SetParent(transform);
            //设置位置
            rtf.position = new Vector3(0, 0, 0);
            //设置缩放
            rtf.localScale = new Vector3(1, 1, 1);
            //设置旋转
            rtf.rotation = Quaternion.Euler(new Vector3(0,0,0));*/
            
            //实例化一个 克隆的物体
            GameObject CoinObject = GameObject.Instantiate(CoinObjectClone,transform) as GameObject;

            //这里设置 正常的有数据记载的商品
            if (i < GetDailyProducts.DailyProductss.Count)
            {
                
                Transform[] tss = CoinObject.GetComponentsInChildren<Transform>();
                for(int j=0; j<tss.Length; j++)
                {
                    if (tss[j].name.Equals("SellContentImg"))
                    {
                        //设置商品图片资源
                        if (GetDailyProducts.DailyProductss[i].type == 2)
                        {
                            tss[j].GetComponent<Image>().sprite = Resources.Load("diamond_2", typeof(Sprite)) as Sprite;
                        }
                        else if (GetDailyProducts.DailyProductss[i].type == 3)
                        {
                            tss[j].GetComponent<Image>().sprite = Resources.Load(GetDailyProducts.DailyProductss[i].subType.ToString(), typeof(Sprite)) as Sprite;
                        }
                    }
                    if (tss[j].name.Equals("SellSumTxt"))
                    {
                        //设置商品售卖的数量
                        tss[j].GetComponent<Text>().text = GetDailyProducts.DailyProductss[i].num.ToString();
                    }
                    //判断商品售卖状态，未售卖就显示购买按钮
                    if (GetDailyProducts.DailyProductss[i].isPurchased == -1)
                    {
                        if (tss[j].name.Equals("SellPriceTxt"))
                        {
                            //设置商品价格
                            tss[j].GetComponent<Text>().text = GetDailyProducts.DailyProductss[i].costGold.ToString();
                        }
                    }//已售卖就隐藏购买按钮
                    else if (GetDailyProducts.DailyProductss[i].isPurchased == 1)
                    {
                        if (tss[j].name.Equals("SellSpendBtn"))
                        {
                            tss[j].gameObject.SetActive(false);
                        }
                    }
                }
            }
            else//这里设置多出来的 待解锁的商品栏位
            {
                Transform[] tss = CoinObject.GetComponentsInChildren<Transform>();
                for(int j=0; j<tss.Length; j++)
                {
                    if (tss[j].name.Equals("SellContentImg"))
                    {
                        //设置商品图片资源
                        tss[j].GetComponent<Image>().sprite = Resources.Load("shop_lock", typeof(Sprite)) as Sprite;
                        //缩放一下 不然太大了 0.87
                        tss[j].localScale = new Vector3(0.87f, 0.87f, 0.87f);
                    }
                    if (tss[j].name.Equals("SellSumTxt"))
                    {
                        //设置标题文字为 "待解锁"
                        tss[j].GetComponent<Text>().text = "待解锁";
                    }
                    if (tss[j].name.Equals("SellSpendBtn"))
                    {
                        //隐藏按钮
                        tss[j].gameObject.SetActive(false);
                    }

                    if (tss[j].name.Equals("SellFinishObject"))
                    {
                        //隐藏对号
                        tss[j].gameObject.SetActive(false);
                    }
                }
            }

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
