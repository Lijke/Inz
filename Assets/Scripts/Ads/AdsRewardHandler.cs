using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum AdsPaymanceType{
	Gold = 1,
	PremiumCurrency = 2
}


public class AdsRewardHandler : MonoBehaviour{

	[FormerlySerializedAs("currentAdsType")] public AdsPaymanceType currentAdsPaymanceType;
	public void GiveReward(){
		switch (currentAdsPaymanceType){
			case AdsPaymanceType.Gold:
				var currentAmount = GoldContainer.Instance.currentGold;
				GoldContainer.Instance.AddGold(currentAmount*2);
				break;
			case AdsPaymanceType.PremiumCurrency:
				GoldContainer.Instance.AddPremiumCurrency(15);
				break;
		}
		
	}
}
