using UnityEngine;

public class GameInit : MonoBehaviour{
    public GoldContainer goldContainer;

    private void Awake(){
        LoadData();
    }


    private void LoadData(){
        goldContainer.goldMultiplayer = 1;
        GamePrefs data = SaveSystem.LoadPrefs();
        goldContainer.currentGold = data.GetEarnedGold();
    }
}
