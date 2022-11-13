using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingUiView : MonoBehaviour{
  [SerializeField] private TextMeshProUGUI itemLevel_TMP;
  [SerializeField] private TextMeshProUGUI itemName_TMP;
  
  [SerializeField] private TextMeshProUGUI unlockItemLevel_TMP;
  [SerializeField] private TextMeshProUGUI unlockItemName_TMP;


  public void SetupView(ItemSO item, BuildingStatus buildingStatus){
    switch (buildingStatus){
      case BuildingStatus.Lock:
        itemLevel_TMP.text = "Level: "+item.currentLevel.ToString();
        itemName_TMP.text = item.itemName;
        break;
      case BuildingStatus.Unlocked:
        unlockItemLevel_TMP.text = "Level: "+item.currentLevel.ToString();
        unlockItemName_TMP.text =  item.itemName;
        break;
        
    }

  }
}
