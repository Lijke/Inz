using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamePrefs{
	private float earnGold=50f;
	public static StatisticInfo statisticInfo;
	public GamePrefs(){ }


	public void Init(){
		if (instance == null){
			instance = new GamePrefs();
		}
	}
	
	#region Singleton
	private static GamePrefs instance;
	
	public static GamePrefs GetInstance(){
		if (instance == null){
			instance = new GamePrefs();
		}

		if (statisticInfo == null){
			statisticInfo = new StatisticInfo();
		}
		return instance;
	}
	#endregion

	public GamePrefs(float earnGold){
		this.earnGold = earnGold;
	}


	public void AddEarnedGold(float earnedGold){
		this.earnGold = earnedGold;
	}

	public float GetEarnedGold(){
		return earnGold;
	}
}
