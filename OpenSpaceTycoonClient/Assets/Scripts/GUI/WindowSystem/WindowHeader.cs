using UnityEngine;
using UnityEngine.EventSystems;

public class WindowHeader : MonoBehaviour, IDragHandler {
	RectTransform mRectTrans = null;

	void Awake(){
		mRectTrans = GetComponentInParent<Window> ().GetComponent<RectTransform> ();	
	}

	public void OnDrag(PointerEventData data ){				
		mRectTrans.anchoredPosition += data.delta;
	}

}
