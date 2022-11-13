using NaughtyAttributes;
using UnityEngine;

public class TestSave : MonoBehaviour{

	[Button()]
	public void SaveData(){
		SaveSystem.SaveData(new GamePrefs(500));
	}
}
