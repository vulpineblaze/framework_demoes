using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// <para>Stores basic information about a single GameObject.</para>
/// </summary>
[Serializable]
public class ObjectRepresentation : System.Object {
    public string prefabName;
    public XYZHelper position;
    public XYZHelper rotation;

    public ObjectRepresentation(string prefab, GameObject go)
    {
        prefabName = prefab;
        position = new XYZHelper(go.transform.position);
        rotation = new XYZHelper(go.transform.rotation);
    }

    /// <summary>
    /// <para>Store basic information of a GameObject in new instance.</para>
    /// <para>Wrks only with objects instantiated from prefabs!</para>
    /// </summary>
    /// <param name="go"></param>
    /// <returns>New instance of 'ObjectRepresentation' which can be serialized</returns>
    public static ObjectRepresentation Store(GameObject go)
    {
        var db = Resources.Load<SerializablePrefabs>("Prefabs");
        var name = go.name.Replace("(Clone)", "");
        var p = db.GetPrefab(name);
        if (p != null)
        {
            var or = new ObjectRepresentation(name, go);
            return or;
        }
        return null;
    }

    /// <summary>
    /// <para>Restore saved GameObject data and instantiate it on current scene.</para>
    /// </summary>
    /// <returns>True/false depending on success state</returns>
    public bool Restore()
    {
        var db = Resources.Load<SerializablePrefabs>("Prefabs");
        var p = db.GetPrefab(prefabName);
        if(p != null)
        {
            GameObject.Instantiate(p, position.ToVector3(), rotation.ToQuaternion());
            return true;
        }
        return false;
    }
}
