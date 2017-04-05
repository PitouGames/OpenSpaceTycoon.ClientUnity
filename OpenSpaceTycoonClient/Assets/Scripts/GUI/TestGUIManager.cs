using UnityEngine;

public class TestGUIManager : MonoBehaviour {
    private WindowSystem winSystem = null;

    private void Start() {
        winSystem = FindObjectOfType<WindowSystem>();
    }

    public void CreateEmpty() {
        winSystem.NewWindow("name", null);
    }

    public void CreateStationView(Object obj) {
        GameObject newObj = Instantiate(obj) as GameObject;
        Window window = winSystem.NewWindow("name", newObj);
        window.Title = "Station info";
    }
}