using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GamePrefs{
	public int buildingUpgradeCount;
	public int buildingDelayUpgradeCount;
	public float goldCount;
	public int adsPopout;
	public float totalTimeInGame;
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
		
		return instance;
	}
	#endregion

	
	public GamePrefs(int buildingUpgradeCount, int buildingDelayUpgradeCount, float goldCount, int adsPopout, float totalTimeInGame){
		this.buildingUpgradeCount = buildingUpgradeCount;
		this.buildingDelayUpgradeCount = buildingDelayUpgradeCount;
		this.goldCount = goldCount;
		this.adsPopout = adsPopout;
		this.totalTimeInGame = totalTimeInGame;
	}


	public void AddEarnedGold(float earnedGold){
		goldCount += earnedGold;
	}

	public float GetEarnedGold(){
		return goldCount;
	}
}
