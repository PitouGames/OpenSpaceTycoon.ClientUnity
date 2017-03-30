using UnityEngine;

public class WindowSystem : MonoBehaviour {

    [SerializeField] Window windowPrefab = null;
    
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
        return newWindow;
    }

    public void BringToFront(Window window){
		window.transform.SetAsLastSibling ();        
	}
}
