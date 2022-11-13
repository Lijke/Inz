using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScreenManager : MonoBehaviour{
    [SerializeField] public GoldContainer goldContainer;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI premiumText;
    private void Awake(){
        GameEvents.onAddGold += UpdateUi;
        UpdateUi();
    }

    private void OnDestroy(){
        GameEvents.onAddGold -= UpdateUi;
    }

    public void UpdateUi(){
        goldText.text = goldContainer.GetCurrentGold().ToString();
        premiumText.text = goldContainer.currentPremiumCurrency.ToString();
    }
}
