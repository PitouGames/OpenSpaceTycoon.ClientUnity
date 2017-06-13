using UnityEngine;
using UnityEngine.UI;

public class HangarLineView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI stationName = null;

    private OSTData.Hangar _hangar = null;

    private void Awake() {
        Button but = GetComponent<Button>();
        but.onClick.AddListener(() => {
            TestGUIManager manager = GameObject.FindObjectOfType<TestGUIManager>();
            manager.CreateHangarView(_hangar);
        });
    }

    public void SetHangar(OSTData.Hangar h) {
        _hangar = h;
        stationName.text = h.Station.Name;
    }
}