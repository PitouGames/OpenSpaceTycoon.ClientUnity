using UnityEngine;

public class TransitionManager : MonoBehaviour {

    private void Start() {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Allow the transition to another station zone
    /// </summary>
    /// <param name="zoneID">the ID of the station we want to look at</param>
    public void LoadNewStationZone(int zoneID) {
        DataModel model = GameObject.FindObjectOfType<DataModel>();
        if (null == model) {
            GameObject newObj = new GameObject("DataModel");
            DontDestroyOnLoad(newObj);

            model = newObj.AddComponent<DataModel>();
            model.Universe = new OSTData.Universe(0);
        }

        GameObject dataObj = new GameObject("loadData");
        GameObject.DontDestroyOnLoad(dataObj);
        PlaySceneLoadData data = dataObj.AddComponent<PlaySceneLoadData>();
        data.stationID = zoneID;

        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
    }
}