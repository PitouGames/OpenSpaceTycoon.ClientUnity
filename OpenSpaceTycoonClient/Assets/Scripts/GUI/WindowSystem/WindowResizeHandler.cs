using UnityEngine;
using UnityEngine.EventSystems;

public class WindowResizeHandler : MonoBehaviour, IDragHandler {
    private RectTransform mRectTrans = null;

    private void Awake() {
        mRectTrans = GetComponentInParent<Window>().GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData data) {
        mRectTrans.sizeDelta = new Vector2(mRectTrans.sizeDelta.x + data.delta.x,
                                           mRectTrans.sizeDelta.y - data.delta.y);
    }
}