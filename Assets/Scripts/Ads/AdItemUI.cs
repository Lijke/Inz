using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class AdItemUI : MonoBehaviour{
	
	public TextMeshProUGUI timer_TMP;
	
	public async UniTaskVoid StartCountingTime(float totalTime){
		float timer = totalTime;
		while (timer > 0){
			timer -= Time.deltaTime;
			await UniTask.NextFrame();
			timer_TMP.text = ((int)timer).ToString();
		}

		Disable();
	}

	public void Disable(){
		gameObject.SetActive(false);
	}
}