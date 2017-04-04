using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGUIManager : MonoBehaviour {

    WindowSystem winSystem = null;

    private void Start() {
        winSystem = FindObjectOfType<WindowSystem>();
    }

    public void CreateEmpty() {
        winSystem.NewWindow("name", null);
    }
}
