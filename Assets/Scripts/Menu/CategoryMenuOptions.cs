using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
[CreateAssetMenu(fileName = "CategoryMenuOptions")]
public class CategoryMenuOptions : ScriptableObject{
	[SerializeField]
	StringStringDictionary m_stringStringDictionary;
	public IDictionary<string, string> StringStringDictionary
	{
		get { return m_stringStringDictionary; }
		set { m_stringStringDictionary.CopyFrom (value); }
	}

	[Button()]
	public void LoadAllKeys(){
		var enumTypes = Enum.GetValues(typeof(CategoryType));
		foreach (var enumType in enumTypes){
			m_stringStringDictionary.Add(enumType.ToString(), "");
		}
	}

	
}

public enum CategoryType{
	BuildingUpgrade =0,
	BuildingDelayUpgrade =1,
	Gold = 2,
	AdsPopout =3 ,
	TotalTimeInGame = 4
}