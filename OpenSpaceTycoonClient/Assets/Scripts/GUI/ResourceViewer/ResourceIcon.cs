using UnityEngine;
using UnityEngine.UI;

public class ResourceIcon : MonoBehaviour {

    //todo move somewhere clean
    public Sprite BatteriesIcon = null;

    public Sprite ElectronicsIcon = null;
    public Sprite FertilizerIcon = null;
    public Sprite FoodIcon = null;
    public Sprite IronIcon = null;
    public Sprite MechanicalPartIcon = null;
    public Sprite TennantiteIcon = null;
    public Sprite ToberniteIcon = null;
    public Sprite ToxicWasteIcon = null;
    public Sprite UnknownIcon = null;
    public Sprite UraniumIcon = null;
    public Sprite WastesIcon = null;
    public Sprite WaterIcon = null;

    [SerializeField]
    private Image iconImage = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI qteText = null;

    public OSTData.ResourceStack Stack { get; private set; }

    public void SetData(OSTData.ResourceStack stack) {
        Stack = stack;
        Stack.onChange += OnChange;
        UpdateVisu();
    }

    private void OnDestroy() {
        Stack.onChange -= OnChange;
    }

    private void UpdateVisu() {
        switch (Stack.Type) {
            case OSTData.ResourceElement.ResourceType.Batteries: iconImage.sprite = BatteriesIcon; break;
            case OSTData.ResourceElement.ResourceType.Electronics: iconImage.sprite = ElectronicsIcon; break;
            case OSTData.ResourceElement.ResourceType.Fertilizer: iconImage.sprite = FertilizerIcon; break;
            case OSTData.ResourceElement.ResourceType.Food: iconImage.sprite = FoodIcon; break;
            case OSTData.ResourceElement.ResourceType.Iron: iconImage.sprite = IronIcon; break;
            case OSTData.ResourceElement.ResourceType.MechanicalPart: iconImage.sprite = MechanicalPartIcon; break;
            case OSTData.ResourceElement.ResourceType.Tennantite: iconImage.sprite = TennantiteIcon; break;
            case OSTData.ResourceElement.ResourceType.Tobernite: iconImage.sprite = ToberniteIcon; break;
            case OSTData.ResourceElement.ResourceType.ToxicWaste: iconImage.sprite = ToxicWasteIcon; break;
            case OSTData.ResourceElement.ResourceType.Unknown: iconImage.sprite = UnknownIcon; break;
            case OSTData.ResourceElement.ResourceType.Uranium: iconImage.sprite = UraniumIcon; break;
            case OSTData.ResourceElement.ResourceType.Wastes: iconImage.sprite = WastesIcon; break;
            case OSTData.ResourceElement.ResourceType.Water: iconImage.sprite = WaterIcon; break;
        }

        qteText.text = Stack.Qte.ToString();
    }

    private void OnChange(OSTData.ResourceStack s) {
        UpdateVisu();
    }
}