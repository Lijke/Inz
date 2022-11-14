using UnityEngine;

public class GameInit : MonoBehaviour{
    public GoldContainer goldContainer;

    private void Awake(){
        LoadData();
    }


    private void LoadData(){
        goldContainer.goldMultiplayer = 1;
        GamePrefs data = SaveSystem.LoadPrefs();
        LoadToPrefs(data);
        goldContainer.currentGold = data.GetEarnedGold();
    }


    private void LoadToPrefs(GamePrefs gamePrefs){
        GamePrefs prefs = GamePrefs.GetInstance();
        prefs.adsPopout = gamePrefs.adsPopout;
        prefs.goldCount = gamePrefs.goldCount;
        prefs.buildingUpgradeCount = gamePrefs.buildingUpgradeCount;
        prefs.buildingDelayUpgradeCount = gamePrefs.buildingDelayUpgradeCount;
        prefs.totalTimeInGame = gamePrefs.totalTimeInGame;
    }
}
