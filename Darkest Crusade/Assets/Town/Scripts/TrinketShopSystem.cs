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
        GameState.Instance.shopTrinkets = new ReactiveCollection<GameObject>();

        PopulatePanel(GameState.Instance.shopTrinkets);
    }

    void OnEnable()
    {
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
            GameState.Instance.shopTrinkets.Add(_trinketFactory.SpawnOnUI(singleTrinketPanel, trinketListPanel));
        }
        KillAllChildren(trinketListPanel);
        foreach (GameObject item in shopTrinkets)
        {
            GeneratePanel(item);
        }
    }


    private string createString(Trinket trinket, bool isBuff)                                               // TODO Refactor
    {
        if (trinket.TrinketClass.ToString().Equals("Epic"))
        {
            return isBuff ? trinket.Buff.BuffType + "\n" + "+" + trinket.Buff.BuffValue
                      : "";
        }
        else
        {
            return isBuff ? trinket.Buff.BuffType + "\n" + "+" + trinket.Buff.BuffValue
                          : trinket.Debuff.BuffType + "\n" + trinket.Debuff.BuffValue;

        }

    }




    public void GeneratePanel(GameObject trinketObject)
    {
        trinketObject = _trinketFactory.SpawnOnUI(singleTrinketPanel, trinketListPanel);
        TextMeshProUGUI[] trinketClassTexts = trinketObject.GetComponentsInChildren<TextMeshProUGUI>();
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = trinketObject.GetComponent<Trinket>().TrinketClass.ToString();
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[1].text = createString(trinketObject.GetComponent<Trinket>(),true);
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[2].text = createString(trinketObject.GetComponent<Trinket>(), false);
        trinketObject.GetComponentsInChildren<TextMeshProUGUI>()[3].text = "BUY\n" + trinketObject.GetComponent<Trinket>().TrinketValue.Value.ToString();
        Image trinketImage = trinketObject.GetComponentInChildren<Image>();
    }



    private void KillAllChildren(GameObject parentObject)
    {
        if (parentObject.transform.childCount != 0)
        {
            foreach (Transform child in parentObject.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public bool ValidatePurchase(ReactiveProperty<int> value)
    {
        return GameState.Instance.gold.Value > value.Value ? true : false;
    }





}
