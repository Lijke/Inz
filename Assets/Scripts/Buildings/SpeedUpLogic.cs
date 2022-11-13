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

	private void Awake(){
		adCost_TMP.text = cost.ToString();
	}

	[NaughtyAttributes.Button()]
	public void ButtonSpeedUp(){
		if (GoldContainer.Instance.CanBuyByPremium(cost)){
			SpeedUp();
			GameEvents.EventStarted(AdEventType.SpeedUp, boostTime);
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