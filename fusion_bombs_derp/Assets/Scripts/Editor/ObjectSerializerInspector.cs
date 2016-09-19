using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ObjectSerializer))]
public class ObjectSerializerInspector : Editor {

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        var os = (ObjectSerializer)target;
        GUILayout.BeginVertical();
        if (GUILayout.Button("Register Prefab"))
        {
            var db = Resources.Load<SerializablePrefabs>("Prefabs");
            if (db == null)
            {
                db = ScriptableObjectUtility.CreateAsset<SerializablePrefabs>("Assets/Resources/Prefabs.asset");
                Debug.Log("Prefabs database created!");
            }
            if (db.GetPrefab(os.gameObject.name) == null)
            {
                db.InsertPrefab(os.gameObject);
                Debug.Log("Added prefab to the database!");
            }
            else Debug.Log("This prefab is already registered!");
        }
        GUILayout.EndVertical();
    }
}
