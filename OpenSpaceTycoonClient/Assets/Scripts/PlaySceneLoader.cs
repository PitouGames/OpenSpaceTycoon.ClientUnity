using System.Collections.Generic;
using UnityEngine;

public class PlaySceneLoader : MonoBehaviour {

    [SerializeField]
    private Transform world = null;

    private void Start() {
        PlaySceneLoadData data = GameObject.FindObjectOfType<PlaySceneLoadData>();
        DataModel model = GameObject.FindObjectOfType<DataModel>();

        GameObject.Destroy(data.gameObject);
    }
}