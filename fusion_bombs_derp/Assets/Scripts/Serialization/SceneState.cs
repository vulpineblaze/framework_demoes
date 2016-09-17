using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// <para>Stores information about single scene.</para>
/// </summary>
[Serializable]
public class SceneState : System.Object {
    public string name;
    public ObjectRepresentation[] objects;

    public static SceneState SaveCurrent()
    {
        var obj = new List<ObjectRepresentation>();
        var scene = SceneManager.GetActiveScene();
        var ss = new SceneState() { name = scene.name };
        var serializers = GameObject.FindObjectsOfType<ObjectSerializer>();
        for (int i = 0; i < serializers.Length; i++)
            obj.Add(serializers[i].Prepare());
        ss.objects = obj.ToArray();
        return ss;
    }

    public bool InstantiateCurrent()
    {
        var scene = SceneManager.GetActiveScene();
        var db = Resources.Load<SerializablePrefabs>("Prefabs");
        if (scene.name == name)
        {
            for(int i = 0; i < objects.Length; i++)
            {
                try
                {
                    var p = db.GetPrefab(objects[i].prefabName);
                    if (p != null)
                        objects[i].Restore();
                }
                catch (Exception ex) { Debug.LogError("Error while restoring scene state!\n" + ex.Message); }
            }
            return true;
        }
        return false;
    }
}
