using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour{
	public float timer;
	private void Update(){
		GamePrefs.GetInstance().totalTimeInGame += Time.deltaTime;
	}
}
