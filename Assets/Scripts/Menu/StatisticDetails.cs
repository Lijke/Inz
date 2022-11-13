using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticDetails : MonoBehaviour{
    public GameObject rowPrefab;
    public CategoryMenuOptions categoryMenuOptions;
    private List<GameObject> spawnedItems = new List<GameObject>();
    

    private void OnEnable(){
        LoadDetails();
    }

    private void OnDisable(){
        RemoveAllItems();
    }


    private void RemoveAllItems(){
        foreach (var item in spawnedItems){
            DestroyImmediate(item);
        }
    }


    public void LoadDetails(){
        var enumTypes = Enum.GetValues(typeof(CategoryType));
        foreach (CategoryType enumType in enumTypes){
            var rowObj = Instantiate(rowPrefab, transform);
            spawnedItems.Add(rowObj);
            var objScript = rowObj.GetComponent<ItemRow>();
            string data;
            categoryMenuOptions.StringStringDictionary.TryGetValue(enumType.ToString(), out data);
            objScript.itemName.text = data;
            objScript.LoadValue(enumType);
        }
    }
}
