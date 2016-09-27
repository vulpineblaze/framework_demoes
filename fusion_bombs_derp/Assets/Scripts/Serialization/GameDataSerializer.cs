using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// <para>Main serializer class.</para>
/// <para>Use it to manage the serialization and deserialization process.</para>
/// </summary>
public class GameDataSerializer : System.Object {
    static BinaryFormatter bf = new BinaryFormatter();
    public static bool SerializeCurrentScene()
    {
        var ss = SceneState.SaveCurrent();
        if(ss.objects.Length > 0)
        {
            var fs = new FileStream(Path.Combine(Application.persistentDataPath, ss.name + ".sav"), FileMode.Create, FileAccess.ReadWrite);
            bf.Serialize(fs, ss);
            fs.Close();
            return true;
        }
        return false;
    }

    public static bool SerializePlayerData()
    {
        var pd = PlayerData.GetCurrent();
        if(pd != null)
        {
            pd.lastSave = DateTime.Now.Ticks;
            var fs = new FileStream(Path.Combine(Application.persistentDataPath, "player.sav"), FileMode.Create, FileAccess.ReadWrite);
            bf.Serialize(fs, pd);
            fs.Close();
            return true;
        }
        return false;
    }

    public static bool RestoreCurrentScene()
    {
        var scene = SceneManager.GetActiveScene();
        var path = Path.Combine(Application.persistentDataPath, scene.name + ".sav");
        if (File.Exists(path))
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var ss = (SceneState)bf.Deserialize(fs);
            fs.Close();
            ss.InstantiateCurrent();
            return true;
        }
        return false;
    }

    public static bool RestorePlayerData()
    {
        var path = Path.Combine(Application.persistentDataPath, "player.sav");
        if(File.Exists(path))
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var pd = (PlayerData)bf.Deserialize(fs);
            fs.Close();
            pd.SetCurrent();
            return true;
        }
        return false;
    }

    public static double GetNumberOfDaysSinceLastSession()
    {
        var inGameDayRate = 7.5; // How many game days pass in one RL day (24h)

        var gps = GameObject.FindObjectOfType<GlobalPlayerScript>();
        var last = new DateTime(gps.lastSession);
        var now = DateTime.Now;

        if (gps.lastSession != 0L)
            return (now - last).TotalDays * inGameDayRate;
        else return 0;
    }

}
