using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// <para>An easy way to serialize Vector3/Quaternion values.</para>
/// </summary>
[Serializable]
public class XYZHelper : System.Object {
    public float x, y, z;

    public XYZHelper(Vector3 v)
    {
        ConvertVector(v);
    }

    public XYZHelper(Quaternion q)
    {
        ConvertVector(q.eulerAngles);
    }

    private void ConvertVector(Vector3 v)
    {
        x = v.x;
        y = v.y;
        z = v.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }

    public Quaternion ToQuaternion()
    {
        return Quaternion.Euler(ToVector3());
    }
    public override string ToString()
    {
        return string.Format("X = {0}; Y = {1}; Z = {2}", x, y, z);
    }
}
