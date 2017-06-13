using UnityEngine;

public class resourceListLineView : MonoBehaviour {

    [SerializeField]
    private TMPro.TextMeshProUGUI nameText = null;

    private OSTData.ResourceElement.ResourceType _type = OSTData.ResourceElement.ResourceType.Unknown;

    public void SetType(OSTData.ResourceElement.ResourceType type) {
        _type = type;
        nameText.text = type.ToString();
    }

    public void OnClic() {
        TestGUIManager guiManager = FindObjectOfType<TestGUIManager>();
        guiManager.CreateResourceInfoView(_type);
    }
}