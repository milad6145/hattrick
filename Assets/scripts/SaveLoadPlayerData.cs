using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadPlayerData {

	//public static int experiencePoints=0;
	public static int playerLevel=0;
	public static void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat",
		                            FileMode.Open);
		
		PlayerData data = new PlayerData();
		//data.experiencePoints = experiencePoints;
		data.playerLevel = playerLevel;
		
		bf.Serialize(file, data);
		file.Close();
	}
	
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat",
			                            FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			
			//experiencePoints = data.experiencePoints;
			playerLevel = data.playerLevel;
		}
		else
		{
			playerLevel=0;
		}
	}
}