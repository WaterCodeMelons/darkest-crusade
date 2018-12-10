using System;
using UnityEngine;
using Core;
using UniRx;
using UnityEngine.UI;
using TMPro;
using Assets;

public class TrinketShopSystem : MonoBehaviour {

	public GameObject trinketListPanel;
    public GameObject singleTrinketPanel;
    private TrinketFactory _trinketFactory = new TrinketFactory();

    // Use this for initialization
    void Start()
    {
        GameState.Instance.shopTrinkets.Clear();
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
            GameState.Instance.shopTrinkets.Add(singleTrinketPanel);
        }
        foreach (GameObject item in shopTrinkets)
        {
            GeneratePanel(item);
        }
    }

    private string createString(Trinket trinket, bool isBuff)                                               // TODO Refactor
    {
        return isBuff
            ? trinket.Buff.BuffType + "\n" + "+" + trinket.Buff.BuffValue
            : (trinket.Debuff == null ? "" : trinket.Debuff.BuffType + "\n" + trinket.Debuff.BuffValue);
    }

    public void GeneratePanel(GameObject trinketObject)
    {
        trinketObject = _trinketFactory.SpawnOnUI(singleTrinketPanel, trinketListPanel);
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = trinketObject.GetComponent<Trinket>().TrinketClass.ToString();
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[1].text = createString(trinketObject.GetComponent<Trinket>(),true);
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[2].text = createString(trinketObject.GetComponent<Trinket>(), false);
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "BUY\n" + trinketObject.GetComponent<Trinket>().TrinketValue.Value.ToString();
    }

    public bool ValidatePurchase(ReactiveProperty<int> value)
    {
        return GameState.Instance.gold.Value > value.Value;
    }
}
