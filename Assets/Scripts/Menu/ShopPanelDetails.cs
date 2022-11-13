using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopPanelDetails : MonoBehaviour{
    [SerializeField] private int currentItem = 0;
    [SerializeField] private int itemCount;
    
    [Header("Ui")]
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI currentLevel;
    [SerializeField] private TextMeshProUGUI currentPrice; 
    [SerializeField] private TextMeshProUGUI currentDuration;
    [SerializeField] private TextMeshProUGUI desription;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider slider;
    [Header("Managers/ Containers")] 
    public GoldContainer goldContainer;
    [Header("Item")]
    [SerializeField] private List<ItemSO> item;

    [Header("Upgrade Duration")] 
    public UpgradeDurationUi durationUpgradeUi;

    [Header("UpgradeLevel")] 
    public UpgradeLevelUi upgradeLevelUi;
    private void Awake(){
        GameEvents.onAddGold += UpdateUi;
        GameEvents.onLevelUp += UpdateLevelUi;
        GameEvents.onDurationLevelUp += DurationLevelUi;
        itemCount = item.Count;
    }

    public void SetCurrenItem(int currentItem){
        this.currentItem = currentItem;
    }
    private void UpdateUi(){
        goldText.text = goldContainer.GetCurrentGold().ToString();
    }

    private void OnDestroy(){
        GameEvents.onAddGold -= UpdateUi;
        GameEvents.onLevelUp -= UpdateLevelUi;
        GameEvents.onDurationLevelUp -= DurationLevelUi;
    }

    private void DurationLevelUi(ItemSO itemSo){
        currentDuration.text = itemSo.currentDuration.ToString();
    }

    private void UpdateLevelUi(ItemSO itemSo){
        SetupView(itemSo);
    }

    public void SetupView(ItemSO item){
        this.item[currentItem] = item;
        itemName.text = item.itemName;
        currentLevel.text = "Level " + item.currentLevel.ToString();
        currentPrice.text = item.currentPrice.ToString();
        currentDuration.text = item.currentDuration.ToString();
        desription.text = item.description;
        goldText.text = goldContainer.GetCurrentGold().ToString();
        durationUpgradeUi.Init(item, goldContainer, this.item[currentItem].baseCost);
        durationUpgradeUi.SetUpgrade();
        upgradeLevelUi.Init(item);
    }

    public void SetupNextView(){
        currentItem += 1;
        if (currentItem >= itemCount){
            currentItem -= 1;
            return;
        }
        SetupView(item[currentItem]);
    }

    public void SetupPreviousView(){
        currentItem -= 1;
        if (currentItem < 0){
            currentItem += 1;
            return;
        }
        SetupView(item[currentItem]);
        
    }
    
    public void AddItem(ItemSO itemSo){
        item.Add(itemSo);
        itemCount = item.Count;
    }
}