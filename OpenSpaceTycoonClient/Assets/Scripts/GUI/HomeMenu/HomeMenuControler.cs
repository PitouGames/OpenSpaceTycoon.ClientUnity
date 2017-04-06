using UnityEngine;

public class HomeMenuControler : MonoBehaviour {

    public void OnPlayClic() {
        GameObject newObj = new GameObject("DataModel");
        DontDestroyOnLoad(newObj);

        DataModel model = newObj.AddComponent<DataModel>();
        model.Universe = new OSTData.Universe(0);

        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
    }
}