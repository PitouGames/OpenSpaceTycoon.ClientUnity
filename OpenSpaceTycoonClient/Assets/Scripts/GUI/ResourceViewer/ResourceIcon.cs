using UnityEngine;
using UnityEngine.UI;

public class ResourceIcon : MonoBehaviour {
    public Sprite wasteIcon = null;

    [SerializeField]
    private Image iconImage = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI qteText = null;

    private OSTData.ResourceStack _stack = null;

    public void SetData(OSTData.ResourceStack stack) {
        _stack = stack;
        _stack.onChange += OnChange;
        UpdateVisu();
    }

    private void OnDestroy() {
        _stack.onChange -= OnChange;
    }

    private void UpdateVisu() {
        iconImage.sprite = wasteIcon;
        qteText.text = _stack.Qte.ToString();
    }

    private void OnChange(OSTData.ResourceStack s) {
        UpdateVisu();
    }
}