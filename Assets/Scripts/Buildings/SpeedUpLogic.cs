using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class SpeedUpLogic : MonoBehaviour{
	public BuildingLogicManagerV2 buildingLogicManager;
	[SerializeField] private float boostTime;
	[SerializeField] private float cost;
	public TextMeshProUGUI adCost_TMP;
	public GoldContainer goldContainer;
	private void Awake(){
		adCost_TMP.text = cost.ToString();
	}

	[NaughtyAttributes.Button()]
	public void ButtonSpeedUp(){
		if (GoldContainer.Instance.CanBuyByPremium(cost)){
			SpeedUp();
			GoldContainer.Instance.goldMultiplayer = 2;
			GameEvents.EventStarted(AdEventType.SpeedUp, boostTime);
			GoldContainer.Instance.SubstractPremiumVal(cost);
		}

		
	}


	private void SpeedUp(){
		foreach (var building in buildingLogicManager.spawnedItems){
			building.SpeedUp();
		}

		BuildingUiManager.Instance.SpeedUpAllBuildings();
		CalculateTime();
	}

	public void SpeedUpFinish(){
		foreach (var building in buildingLogicManager.activeItemsPrefabs){
			building.BackToNormal();
			GoldContainer.Instance.goldMultiplayer = 1;
		}

		BuildingUiManager.Instance.BackToNormalAllBuildings();
	}

	private async UniTaskVoid CalculateTime(){
		float timer = boostTime;
		while (timer > 0){
			UniTask.NextFrame();
			timer -= Time.deltaTime;
		}
		SpeedUpFinish();
	}
}