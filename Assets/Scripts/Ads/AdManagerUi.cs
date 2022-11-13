using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManagerUi : MonoBehaviour{
	public List<AdItemUI> adsUiObjects;

	private void Awake(){
		GameEvents.onEventStarted += StartCountingTime;
	}
	
	public void StartCountingTime(AdEventType adeventtype, float totalTime){
		GamePrefs.statisticInfo.adsPopout++;
		adsUiObjects[(int)adeventtype].gameObject.SetActive(true);
		adsUiObjects[(int)adeventtype].StartCountingTime(totalTime);

	}
}
