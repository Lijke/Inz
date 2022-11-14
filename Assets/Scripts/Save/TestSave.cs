using NaughtyAttributes;
using UnityEngine;

public class TestSave : MonoBehaviour{

	[Button()]
	public void SaveData(){
		var prefs = GamePrefs.GetInstance();
		SaveSystem.SaveData(new GamePrefs(
			prefs.buildingUpgradeCount,
			prefs.buildingDelayUpgradeCount,
			prefs.goldCount, 
			prefs.adsPopout,
			prefs.totalTimeInGame));
	}
}
