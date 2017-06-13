using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI ICUs = null;

    [SerializeField]
    private Button ResourcesButton = null;

    private OSTData.Corporation _playerCorp = null;

    private TestGUIManager _guiManager = null;

    private void Start() {
        _guiManager = FindObjectOfType<TestGUIManager>();

        DataModel dataModel = FindObjectOfType<DataModel>();
        SetData(dataModel.PlayerCorp);

        ResourcesButton.onClick.AddListener(() => { _guiManager.CreateResourceListView(); });
    }

    private void OnDestroy() {
        _playerCorp.onICUChange -= OnICUChange;
    }

    public void SetData(OSTData.Corporation playerCorp) {
        _playerCorp = playerCorp;
        _playerCorp.onICUChange += OnICUChange;
        UpdateView();
    }

    private void OnICUChange(long icu) {
        UpdateView();
    }

    private void UpdateView() {
        ICUs.text = _playerCorp.ICU.ToString();
    }
}