using UnityEngine;
using System.Collections;

// An example of how you could implement the GameDataSerializer API.
public class GlobalSerializationManager : MonoBehaviour {
    // On start of the game read player info, if available.
	void Start () {
        DontDestroyOnLoad(gameObject);
        if (GameDataSerializer.RestorePlayerData())
            Debug.Log("[Serialization Manager]Player Data Restored!");
        StartCoroutine(AutoSave()); // This is basically a placeholder, half-measure since I wasn't sure how you're going to manage your scenes. Be sure to customize it to your needs
        Debug.Log("In-Game Days since your last session: " + GameDataSerializer.GetNumberOfDaysSinceLastSession()); // Use this function to move your planets around the sun.
    }

    void OnLevelWasLoaded()
    {
        if(GameDataSerializer.RestoreCurrentScene())
            Debug.Log("[Serialization Manager]Scene Data Restored!");
    }

    // As mentioned above, it's not a recommended solution for saving scene data!
    IEnumerator AutoSave()
    {
        for(;;)
        {
            yield return new WaitForSeconds(10);
            if (GameDataSerializer.SerializeCurrentScene())
                Debug.Log("[Serialization Manager]Scene Data Serialized!");
            // else: No data was found, so you have to instantiate the basic set of enemies and stuff...
            GameDataSerializer.SerializePlayerData();
        }
    }
}
