using UnityEngine;

public class PlaySceneLoader : MonoBehaviour {

    private void Start() {
        PlaySceneLoadData data = GameObject.FindObjectOfType<PlaySceneLoadData>();

        GameObject.Destroy(data.gameObject);
    }
}