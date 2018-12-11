using UnityEngine;
using Core;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class TrinketShopSystem : MonoBehaviour {

	public GameObject trinketListPanel;
    public GameObject singleTrinketPanel;
    private TrinketFactory _trinketFactory;

    // Use this for initialization
    void Start()
    {
        _trinketFactory = new TrinketFactory();
        PopulatePanel(GameState.Instance.shopTrinkets);
        
    }
    public void BuyTrinket(Button button, GameObject obj)
    {
        //TODO
    }
    public void PopulatePanel(ReactiveCollection<GameObject> shopTrinkets)
    {
        while (shopTrinkets.Count < 3)
        {
            GameState.Instance.shopTrinkets.Add(GeneratePanel(singleTrinketPanel));
        }
    }
    private string createString(Trinket trinket, bool isBuff)                                               // TODO Refactor
    {
        return isBuff
            ? trinket.Buff.BuffType + "\n" + "+" + trinket.Buff.BuffValue
            : (trinket.Debuff == null ? "" : trinket.Debuff.BuffType + "\n" + trinket.Debuff.BuffValue);
    }
    public GameObject GeneratePanel(GameObject trinketObject)
    {
        GameObject newTrinket = _trinketFactory.SpawnOnUI(trinketObject, trinketListPanel);
        newTrinket.GetComponentsInChildren<TextMeshProUGUI>()[0].text = newTrinket.GetComponent<Trinket>().TrinketClass.ToString();
        newTrinket.GetComponentsInChildren<TextMeshProUGUI>()[1].text = createString(newTrinket.GetComponent<Trinket>(),true);
        newTrinket.GetComponentsInChildren<TextMeshProUGUI>()[2].text = createString(newTrinket.GetComponent<Trinket>(), false);
        newTrinket.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "BUY\n" + newTrinket.GetComponent<Trinket>().TrinketValue.Value.ToString();
        return newTrinket;
    }
    public bool ValidatePurchase(ReactiveProperty<int> value)
    {
        return GameState.Instance.gold.Value > value.Value;
    }
}