using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class SerializablePrefabs : ScriptableObject {
    [SerializeField]
    private List<GameObject> prefabs = new List<GameObject>();

    public GameObject GetPrefab(string name)
    {
        return prefabs.ToList().Where(o => o.name == name).FirstOrDefault();
    }

    public void InsertPrefab(GameObject p)
    {
        prefabs.Add(p);
    }
}
