using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticDetails : MonoBehaviour{
    public GameObject rowPrefab;
    public CategoryMenuOptions categoryMenuOptions;


    private void Awake(){
        LoadDetails();
    }

    public void LoadDetails(){
        var enumTypes = Enum.GetValues(typeof(CategoryType));
        foreach (var enumType in enumTypes){
            var rowObj = Instantiate(rowPrefab, transform);
            var objScript = rowObj.GetComponent<ItemRow>();
            string data;
            categoryMenuOptions.StringStringDictionary.TryGetValue(enumType.ToString(), out data);
            objScript.name.text = data;
        }
    }
}
