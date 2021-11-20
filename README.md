# FirstProject

1、整体框架

- 层级视图中，每个小块都用空的游戏对象封装，方便禁用和启用
- 脚本代码以MVC层级结构分层



2、资源目录结构

| 目录名称      | 目录内容               | 父目录     | 其他说明           |
| ------------- | ---------------------- | ---------- | ------------------ |
| Resources     | 存放界面UI应用到的资源 |            | 处于根目录Assets下 |
| 01.Scenes     | 存放场景               |            |                    |
| 02.Scripts    | 存放脚本               |            |                    |
| 03.Sprites    | 存放2D精灵体           |            |                    |
| 04.Prefabs    | 存放预设体             |            |                    |
| 05.Plugs      | 存放插件               |            |                    |
| 06.JsonData   | 存放原始Json数据       |            |                    |
| 07.Animations | 存放动画和动画控制器   |            |                    |
| Controller    |                        | 02.Scripts |                    |
| Model         |                        | 02.Scripts |                    |
| View          |                        | 02.Scripts |                    |



3、界面对象结构拆分

| 结构                 | 结构对象说明                                                 | 父界面对象           | 其他说明                           |
| -------------------- | ------------------------------------------------------------ | -------------------- | ---------------------------------- |
| SellRootCanvas       | 主画布，作为根目录                                           |                      |                                    |
| SellRootPanel        | 售卖界面主画板                                               | SellRootCanvas       |                                    |
| PopupsPanel          | 确认购买界面的弹窗                                           | SellRootCanvas       | 默认是弃用的，其子层级也不写进这里 |
| SellBeginPanel       | 开始界面画板                                                 | SellRootCanvas       | 层级高于SellRootPanel              |
| SellScrollRectObject | 售卖界面的滚动矩形游戏对象，包含显示售卖信息的UI对象，实现可滚动视窗 | SellRootPanel        |                                    |
| PlayerStatePanel     | 玩家状态信息画板，包含显示玩家状态的UI对象                   | SellRootPanel        |                                    |
| SellExitObject       | 包含关闭退出按钮的游戏对象，实现退回主界面                   | SellRootPanel        |                                    |
| SellContentPanel     | 存放售卖内容的画板，内涵售卖各个小版块的UI                   | SellScrollRectObject |                                    |
| PlayerStateObject    | 存放玩家状态信息的游戏对象，内涵玩家状态信息的UI             | PlayerStatePanel     |                                    |



4、代码逻辑分层

| 类                                 | 主要职责                                           | 其他说明         |
| ---------------------------------- | -------------------------------------------------- | ---------------- |
| 实体类：RewardType.cs              | 对应售卖信息类型的映射                             | 位于Model下      |
| 实体类：DailyProduct.cs            | 对应售卖实体类的字段映射                           | 位于Model下      |
| 实体类：GetDailyProduct.cs         | 通过SImpleJson解析Json数据，得到商品信息           | 位于Model下      |
| 视图层：ShowProduct.cs             | 用于控制对应显示的商品信息                         | 位于View下       |
| 视图层：ProductManager.cs          | 用于获得商品预制体中需要动态改变的一些组件对象     | 位于View下       |
| 控制层：ViewSkipController.cs      | 控制各个按钮的视图跳转                             | 位于Controller下 |
| 控制层：CoinFlyAnimitionController | 用于控制飞金币动画对象的显示、位置和数量等实现逻辑 | 位于Controller下 |



5、存储设计

数据统一使用JSON格式存储



6、部分功能的实现思想

- 视图跳转的实现方式：将脚本ViewSkipController.cs挂载在根画布上，通过对象拖动的方式传入商品展示画板对象和开始界面画板对象；在代买中获得相应游戏对象，然后通过SetActive（）方法灵活控制整个视图对象的启用和禁用；
- 不同商品信息的显示：将脚本ShowProducts.cs挂载到商品展示对象上，获得单个商品的预置体以及该预制体上需要动态改变内容的所有子对象；在代码中，首先获得对应的具体数据，然后根据具体数据来变更预制体上需要动态改变的子对象的内容，最后实例化预制体对象来展示出来；
- 飞金币动画：动画封装到CoinFlyObject游戏对象预设体中，在CoinFlyAnimitionController.cs脚本中控制，脚本挂载在宝箱购买按钮上，并添加点击监听事件为脚本中的OnClick()方法。根据点击次数动态创建飞金币对象。OnCLick()点击方法先将宝箱图片修改为打开状态的图片，然后控制无论点击多少次只实例化一个特效对象，然后根据需求循环控制生成飞金币动画的数量，并动态改变玩家持有的金币数量；通过DoTween的OnComplete()方法，实现每次飞金币完成后，增加玩家持有金币数量、销毁飞金币对象、判断剩下最后一个金币时销毁特效对象和将宝箱图片修改为关闭状态的宝箱图片。
- 修改购买状态的实现：在ViewSkipController.cs中，购买按钮下面覆盖着一个✅按钮。购买完成后，通过对象的setActive()方法隐藏购买按钮，显示出下面的✅



7、关键代码逻辑的流程图

- 控制视图跳转的ViewSkipController.cs脚本代码逻辑：

<img src="https://github.com/89trillion-xuda/Project1New/blob/master/Assets/ReadMeImage/ViewSkipController.png" style="zoom:80%;" />



- 控制商品信息展示的ShowProduct.cs脚本代码逻辑：

<img src="https://github.com/89trillion-xuda/Project1New/blob/master/Assets/ReadMeImage/ShowProduct.png" style="zoom:80%;" />



- 控制飞金币动画的CoinFlyAnimitionController.cs脚本代码逻辑：

<img src="https://github.com/89trillion-xuda/Project1New/blob/master/Assets/ReadMeImage/CoinFLyAnimitionController.png" style="zoom:80%;" />



