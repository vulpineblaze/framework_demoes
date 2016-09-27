using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerData : System.Object {
    public float resources;
    public float kills;
    public long lastSave;
    /// <summary>
    /// <para>Get Current Player Data and store it in a serializable class.</para>
    /// </summary>
    /// <returns>PlayerData object containing information about player -- if no global player objects, return null</returns>
    public static PlayerData GetCurrent()
    {
        var gps = GameObject.FindObjectOfType<GlobalPlayerScript>();
        if (gps != null)
        {
            var pd = new PlayerData() { kills = gps.enemiesKilled, resources = gps.currentResources };
            return pd;
        }
        return null;
    }

    /// <summary>
    /// <para>Restore player data from serializable object.</para>
    /// </summary>
    public void SetCurrent()
    {
        var gps = GameObject.FindObjectOfType<GlobalPlayerScript>();
        gps.enemiesKilled = kills;
        gps.currentResources = resources;
        gps.lastSession = lastSave;
    }
}
