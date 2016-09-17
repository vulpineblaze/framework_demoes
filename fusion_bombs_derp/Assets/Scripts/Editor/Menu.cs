using UnityEditor;
using UnityEngine;

using System.Collections;

public class Menu {
    [MenuItem("test/Prefabs Database")]
    public static void Database()
    {
        ScriptableObjectUtility.CreateAsset<SerializablePrefabs>();
    }
}
