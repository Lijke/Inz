using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem{
   public static void SaveData(GamePrefs gamePrefs){
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "PrefsData.txt";
      FileStream stream = new FileStream(path, FileMode.Create);
      formatter.Serialize(stream, gamePrefs);
      stream.Close();
   }
   
   public static GamePrefs LoadPrefs(){
      GamePrefs.GetInstance().Init();
      string path = Application.persistentDataPath + "PrefsData.txt";
      if (File.Exists(path)){
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open);
         GamePrefs data = formatter.Deserialize(stream) as GamePrefs;
         stream.Close();
         return data;
      }
      else{
         Debug.LogError("No save file");
         return null;
      }
   }

  
}