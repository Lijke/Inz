using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour{
	public float timer;
	private void Update(){
		timer += Time.deltaTime;
		GamePrefs.statisticInfo.totalTimeInGame = timer;
	}
}
