using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BuildingStatus{
	Unlocked = 0,
	Lock = 1
}

public class BuildingUiItem : MonoBehaviour{

	[ReadOnly] public ItemSO item;

	public Image slider;

	public float currentTimer;
	[SerializeField] float maxTime;
	bool working;
	private BuildingLogic buildingLogic;

	public GameObject unlockedGameObject;
	public GameObject lockGammeObject;

	[Header("Unlock")]
	public TextMeshProUGUI lock_TMP;

	public BuildingUiView buildingUiView;
	private CancellationTokenSource cts = new CancellationTokenSource();
	private void Awake(){
		GameEvents.onLevelUp += ResetUi;
	}

	private void OnDestroy(){
		cts.Cancel();
	}

	public void ResetUi(ItemSO itemSo){
		if (item != itemSo){
			return;
		}
		buildingLogic.BreakAsyncWhile();
		CanlceSliderWhileLoop();
		ResetSlider();
	}
	
	private void ResetSlider(){
		cts = new CancellationTokenSource();
		
		SetupSlider(item.currentDuration);
	}
	
	private void CanlceSliderWhileLoop(){
		cts.Cancel();
	}
	
	public void SetupStatus(BuildingStatus buildingStatus, float timer){
		maxTime = timer;
		switch (buildingStatus){
			case BuildingStatus.Lock:
				unlockedGameObject.SetActive(false);
				lockGammeObject.SetActive(true);
				lock_TMP.text = item.currentPrice.ToString();
				buildingUiView.SetupView(item, buildingStatus);
				break;
			case BuildingStatus.Unlocked:
				unlockedGameObject.SetActive(true);
				lockGammeObject.SetActive(false);
				SetupSlider(timer);
				buildingUiView.SetupView(item, buildingStatus);
				break;
		}
	}


	public async UniTask SetupSlider(float timer){
		currentTimer = 0;
		maxTime = timer;
		working = true;
#if UNITY_EDITOR
		Debug.Log($"$start generating money {item.itemName}");
#endif
		while (working && !cts.IsCancellationRequested){

			var fillAmmount = currentTimer / maxTime;
			slider.fillAmount = fillAmmount;
			currentTimer += Time.deltaTime;
			await UniTask.NextFrame();
			if (currentTimer > maxTime){
				currentTimer = 0;
#if UNITY_EDITOR
				Debug.Log($"Finish {item.itemName}");
				GoldContainer.Instance.AddGold(item.currentPrice);
#endif
			}
		}
	}

	public void Unlock(){
		var canBuyItem =buildingLogic.goldContainer.CanBuyByGold(item.currentPrice);
	
		if (canBuyItem){
			GoldContainer.Instance.SubstractGold(item.currentPrice);
			CanvasManager.Instance.AddItem(item);
			buildingLogic.Unlock(item);
		}
	}
	public void InitLogic(BuildingLogic buildingLogic){
		this.buildingLogic = buildingLogic;
	}


	public void SpeedUp(){
		maxTime /= 2;
	}


	public void BackToNormal(){
		maxTime = item.currentDuration;
	}
}
