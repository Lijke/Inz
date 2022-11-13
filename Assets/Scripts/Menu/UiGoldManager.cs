using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TypeOfGold{
   gold =1,
   premium =2
}

public class UiGoldManager : MonoBehaviour{
   public TextMeshProUGUI goldText;
   public TextMeshProUGUI premiumValueText;
   public static UiGoldManager Instance;
   public GoldContainer goldContainer;
   private void Awake(){
      Instance = this;
      goldContainer.Init();

   }

   public void UpdateText(TypeOfGold typeOfGold, string value){
      switch (typeOfGold){
         case TypeOfGold.gold:
            goldText.text = value;
            break;
         case TypeOfGold.premium:
            premiumValueText.text = value;
            break;
      }
   }
}
