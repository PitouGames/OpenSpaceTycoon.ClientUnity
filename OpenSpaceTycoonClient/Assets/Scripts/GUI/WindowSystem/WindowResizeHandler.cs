using UnityEngine;
using UnityEngine.EventSystems;

public class WindowResizeHandler : MonoBehaviour, IDragHandler {

    RectTransform mRectTrans = null;

    void Awake() {
        mRectTrans = GetComponentInParent<Window>().GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData data) {
        mRectTrans.sizeDelta = new Vector2(mRectTrans.sizeDelta.x + data.delta.x,
                                           mRectTrans.sizeDelta.y - data.delta.y);
    }
}
