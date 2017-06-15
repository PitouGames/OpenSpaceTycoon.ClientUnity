using System.Collections.Generic;

using UnityEngine;

public class WindowSystem : MonoBehaviour {

    [SerializeField]
    private Window windowPrefab = null;

    [System.Serializable]
    private struct WindowPosition {

        public WindowPosition(float x, float y) {
            X = x; Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }
    }

    private Dictionary<string, WindowPosition> positions = new Dictionary<string, WindowPosition>();

    private void Start() {
        if (PlayerPrefs.HasKey("positions")) {
            string s = PlayerPrefs.GetString("positions");
            positions = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, WindowPosition>>(s);
        }
    }

    private void OnDestroy() {
        string s = Newtonsoft.Json.JsonConvert.SerializeObject(positions);
        PlayerPrefs.SetString("positions", s);
    }

    public Window NewWindow(string name, GameObject data) {
        Window newWindow = Instantiate<Window>(windowPrefab);
        newWindow.transform.SetParent(transform);
        newWindow.SetPosition(Vector2.zero);
        data.transform.SetParent(newWindow.Content);
        RectTransform r = data.GetComponent<RectTransform>();
        r.anchorMin = Vector2.zero;
        r.anchorMax = Vector2.one;
        r.offsetMin = Vector2.zero;
        r.offsetMax = Vector2.zero;

        newWindow.OnClose += OnWindowClose;
        newWindow.WindowType = name;

        if (positions.ContainsKey(name)) {
            r = newWindow.GetComponent<RectTransform>();
            r.anchoredPosition = new Vector2(positions[name].X, positions[name].Y);
        }

        return newWindow;
    }

    public void BringToFront(Window window) {
        window.transform.SetAsLastSibling();
    }

    private void OnWindowClose(Window w) {
        RectTransform r = w.GetComponent<RectTransform>();

        if (!positions.ContainsKey(w.WindowType))
            positions.Add(w.WindowType, new WindowPosition());
        positions[w.WindowType] = new WindowPosition(r.anchoredPosition.x, r.anchoredPosition.y);
    }
}