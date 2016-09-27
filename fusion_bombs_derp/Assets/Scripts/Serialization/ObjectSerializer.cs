using UnityEngine;
using System.Collections;

/// <summary>
/// <para>Assign this component to every prefab that should be serializable.</para>
/// <para>Remember to add the prefab to the database in 'Resources' folder -- important.</para>
/// </summary>
public class ObjectSerializer : MonoBehaviour {
    /// <summary>
    /// <para>Prepare GameObject for serialization by storing its data in a serializable class.</para>
    /// </summary>
    /// <returns>A serializable object info, or null -- if not a prefab instance</returns>
    public ObjectRepresentation Prepare()
    {
        return ObjectRepresentation.Store(gameObject);
    }
}
