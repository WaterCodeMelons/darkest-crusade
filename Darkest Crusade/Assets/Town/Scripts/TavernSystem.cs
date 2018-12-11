using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UniRx;
using UnityEngine.UI;
using TMPro;

namespace Assets
{
	public class TavernSystem : MonoBehaviour {

		
		public GameObject heroListPanel;
		public GameObject singleHeroPanel;
		private HeroesFactory _heroFactory;

		// Use this for initialization
		void Start () {
			_heroFactory = new HeroesFactory();
			PopulatePanel(GameState.Instance.tavernHeroes);
		}
		void OnEnable()
		{
			PopulatePanel(GameState.Instance.tavernHeroes);
		}

		public void BuyHero(Button button, GameObject obj) {
			// #TODO
		}

		public void PopulatePanel(ReactiveCollection<GameObject> tavernHeroes) 
		{
			while (tavernHeroes.Count < 4)
			{
				GameState.Instance.tavernHeroes.Add(GeneratePanel(singleHeroPanel));
			}
		}
		public GameObject GeneratePanel(GameObject heroObject) 
		{
			GameObject newHero = _heroFactory.SpawnOnUI(heroObject, heroListPanel, HeroStatusEnum.InTavern);			
			newHero.GetComponentsInChildren<TextMeshProUGUI>()[0].text = newHero.GetComponent<Hero>().HeroClass.ToString();
			newHero.GetComponentsInChildren<TextMeshProUGUI>()[1].text = newHero.GetComponent<Hero>().Level.ToString();
			newHero.GetComponentsInChildren<TextMeshProUGUI>()[2].text = "Buy for\n" + newHero.GetComponent<Hero>().HeroValue.Value.ToString() + " gold";
			Image heroImage = newHero.GetComponentInChildren<Image>();
			return newHero;
		}
		public bool ValidatePurchase(ReactiveProperty<int> value) 
		{
			return GameState.Instance.gold.Value > value.Value ? true : false;
		}
	}
}
