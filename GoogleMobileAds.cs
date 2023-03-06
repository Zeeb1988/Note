using UnityEngine;
using System;
using GoogleMobileAds.Api;

//Unity SDK  ����  �ȸ��̵���  AdMob

һ.׼������
#region
{
    1.�򿪹ȸ��й������߹���

    2.�ҵ�AdMob

    3.�ҵ�Unity

    4.�����ƶ����Unity ���

    5.���������Unity

    6.���ͼ�飨Assets => External Dependency Manager => Android Resolver => Resolve��

    7.���Ӧ��ID��Assets => GoogleMobileAds => Settings��
}
#endregion


��.���뼤�����Ļ�������
#region
{
    1.���������ռ� => using GoogleMobileAds.Api;

    2.��ʼ���ƶ����SDK����Start�����м������´��룺
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }

    3.�������������� => RewardedAds rewardedAd;

    4.���������ع�棺ʹ��OnAdClosedԤ������һ�����
    ��Ϊ������������һ���Զ��󣬼��ع���������ص�

    public void CreateAndLoadRewardedAd()
    {
        //��׿Ӧ��ID���ڹȸ��̵괴��Ӧ�ú�õ�ID���뽫��ID�滻
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
        //���������ع���¼��ص�
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        //���û��ۿ�����ȡ�����¼��ص�
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    ...
        //�ٴδ���һ�������󣬲�����ص�
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
    }

    ��������溯������Start�ķ����У�
    void Start()
    {
        //��ʼ��SDK
        MobileAds.Initialize(initStatus => { });
        //����洴��������
        CreateAndLoadRewardedAd()��
    }

    5.ѡ��Ҫչʾ����λ�ò����뺯��������
    void StartGame()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    6.�û�����ͨ���ۿ���������ȡ��Ӧ����Ϸ���ߣ�
        //���¼���Ȼ��Ҫ�ص�
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
    }

}
#endregion