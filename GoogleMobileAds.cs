using UnityEngine;
using System;
using GoogleMobileAds.Api;

//Unity SDK  接入  谷歌商店广告  AdMob

一.准备工作
#region
{
    1.打开谷歌中国开发者官网

    2.找到AdMob

    3.找到Unity

    4.下载移动广告Unity 插件

    5.将插件导入Unity

    6.解释检查（Assets => External Dependency Manager => Android Resolver => Resolve）

    7.添加应用ID（Assets => GoogleMobileAds => Settings）
}
#endregion


二.加入激励广告的基本步骤
#region
{
    1.导入命名空间 => using GoogleMobileAds.Api;

    2.初始化移动广告SDK，在Start方法中加入如下代码：
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    3.创建奖励广告对象 => RewardedAds rewardedAd;

    4.创建并加载广告：使用OnAdClosed预加载下一个广告
    因为激励广告对象是一次性对象，加载广告对象后必须回调

    public void CreateAndLoadRewardedAd()
    {
        //安卓应用ID，在谷歌商店创建应用后得到ID，须将此ID替换
    #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    #elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/1712485313";
    #else
        string adUnitId = "unexpected_platform";
    #endif

        this.rewardedAd = new RewardedAd(adUnitId);

        //this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
       // this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        //将创建加载广告事件回调
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        //将用户观看广告获取奖励事件回调
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    ...
        //再次创建一个广告对象，并将其回调
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    将创建广告函数加入Start的方法中：
    void Start()
    {
        //初始化SDK
        MobileAds.Initialize(initStatus => { });
        //将广告创建并加载
        CreateAndLoadRewardedAd()；
    }

    5.选择要展示广告的位置并加入函数方法：
    void StartGame()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    6.用户可以通过观看奖励广告获取相应的游戏道具：
        //此事件任然需要回调
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
    }

}
#endregion