using UnityEngine;

public class HUDView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI ICUs = null;

    private OSTData.Corporation _playerCorp = null;

    private void Start() {
        DataModel dataModel = FindObjectOfType<DataModel>();
        SetData(dataModel.PlayerCorp);
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