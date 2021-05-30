using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


    public static class SavingSystem 
    {
        
         // static readonly string SettingsDataPath = Application.persistentDataPath + "/.jpt";
         private static readonly string AlmanacDataPath = Application.persistentDataPath + "/12.jpt";
         private static readonly string LevelDataPath = Application.persistentDataPath + "/142.jpt";

         public static bool CreatePathIfNull()
         {
             // if (!File.Exists(SettingsDataPath)) return true;
             if (!File.Exists(AlmanacDataPath)) return true;
             if (!File.Exists(LevelDataPath)) return true;
             
             return false;
         }
         

        //  public static void SaveSettings(CanvasMenu canvasMenu)
        // {
        //     BinaryFormatter formatter = new BinaryFormatter();
        //     FileStream stream = new FileStream(SettingsDataPath, FileMode.Create);
        //     SettingsData data = new SettingsData(canvasMenu);
        //     formatter.Serialize(stream,data);
        //     stream.Close();
        // }
        //  public static SettingsData LoadSettings()
        // {
        //     if (File.Exists(SettingsDataPath))
        //     {
        //         BinaryFormatter formatter = new BinaryFormatter();
        //         FileStream stream = new FileStream(SettingsDataPath, FileMode.Open);
        //         SettingsData data = formatter.Deserialize(stream) as SettingsData;
        //         stream.Close();
        //         return data;
        //     }
        //     else
        //     {
        //         Debug.LogError("no Path in " + SettingsDataPath);
        //         return null;
        //     }
        //     
        // }
        //  
         
         public static void SaveAlmanacData(Almanac_Manager almanacManager)
         {
             BinaryFormatter formatter = new BinaryFormatter();
             FileStream stream = new FileStream(AlmanacDataPath, FileMode.Create);
             AlmanacData data = new AlmanacData(almanacManager);
             formatter.Serialize(stream,data);
             stream.Close();
         }
         public static AlmanacData LoadAlmanacData()
         {
             if (File.Exists(AlmanacDataPath))
             {
                 BinaryFormatter formatter = new BinaryFormatter();
                 FileStream stream = new FileStream(AlmanacDataPath, FileMode.Open);
                 AlmanacData data = formatter.Deserialize(stream) as AlmanacData;
                 stream.Close();
                 return data;
             }
             else
             {
                 Debug.LogError("no Path in " + AlmanacDataPath);
                 
                 return null;
             }
            
         }




         #region LevelManager 

         public static void SaveLevelData(Level_Manager levelManager)
         {
             BinaryFormatter formatter1 = new BinaryFormatter();
             FileStream stream = new FileStream(LevelDataPath, FileMode.Create);
             LevelData data = new LevelData(levelManager);
             formatter1.Serialize(stream,data);
             stream.Close();
         }
         public static LevelData LoadLevelData()
         {
             if (File.Exists(LevelDataPath))
             {
             
                 BinaryFormatter formatter1 = new BinaryFormatter();
             
                 FileStream stream = new FileStream(LevelDataPath, FileMode.Open);
                 LevelData data = formatter1.Deserialize(stream) as LevelData;
                 stream.Close();
                 return data;
             }
             else
             {
                 Debug.LogError("no Path in " + LevelDataPath);
                 return null;
             }
            
         }

         #endregion
         
        
    }

