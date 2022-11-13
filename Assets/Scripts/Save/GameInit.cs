using UnityEngine;

public class GameInit : MonoBehaviour{
    public GoldContainer goldContainer;

    private void Awake(){
        LoadData();
        
        
    }


    private void LoadData(){
        GamePrefs data = SaveSystem.LoadPrefs();
        goldContainer.currentGold = data.GetEarnedGold();
    }
}
