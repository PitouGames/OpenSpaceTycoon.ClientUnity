using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IPointerClickHandler, IPointerDownHandler {

    [SerializeField]
    private Button closeButton = null;

    [SerializeField]
    private Transform content = null;

    [SerializeField]
    private Text title = null;

    private RectTransform mRectTrans = null;
    private WindowSystem windowSystem = null;

    public Transform Content {
        get { return content; }
    }

    private void Awake() {
        if (null != closeButton) {
            closeButton.onClick.AddListener(CloseWindow);
        }
        mRectTrans = GetComponent<RectTransform>();
        mRectTrans.anchorMin = new Vector2(0.0f, 1.0f);
        mRectTrans.anchorMax = new Vector2(0.0f, 1.0f);
    }

    private void Start() {
        windowSystem = GetComponentInParent<WindowSystem>();
    }

    public void SetPosition(Vector2 position) {
        mRectTrans.anchoredPosition = position;
    }

    public string Title {
        get { return (title == null ? "" : title.text); }
        set {
            if (title != null) {
                title.text = value;
            }
        }
    }

    private void CloseWindow() {
        GameObject.Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData data) {
    }

    public void OnPointerDown(PointerEventData data) {
        if (null != windowSystem)
            windowSystem.BringToFront(this);
    }
}