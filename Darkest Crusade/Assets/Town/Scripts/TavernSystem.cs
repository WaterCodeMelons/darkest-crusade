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
		private HeroesFactory _heroFactory = new HeroesFactory();

		// Use this for initialization
		void Start () {
			GameState.Instance.tavernHeroes = new ReactiveCollection<GameObject>(
				new GameObject[] {
				_heroFactory.SpawnOnUI(singleHeroPanel, heroListPanel, HeroStatusEnum.InTavern),
				_heroFactory.SpawnOnUI(singleHeroPanel, heroListPanel, HeroStatusEnum.InTavern),
				_heroFactory.SpawnOnUI(singleHeroPanel, heroListPanel, HeroStatusEnum.InTavern),
				_heroFactory.SpawnOnUI(singleHeroPanel, heroListPanel, HeroStatusEnum.InTavern)
			});
			PopulatePanel(GameState.Instance.tavernHeroes);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			PopulatePanel(GameState.Instance.tavernHeroes);
		}

		public void BuyHero(Button button, GameObject obj) {
			
		}

		public void PopulatePanel(ReactiveCollection<GameObject> tavernHeroes) 
		{
			while (tavernHeroes.Count < 4)
			{
				GameState.Instance.tavernHeroes.Add(_heroFactory.SpawnOnUI(singleHeroPanel, heroListPanel, HeroStatusEnum.InTavern));
			}
			KillAllChildren(heroListPanel);
			foreach (GameObject item in tavernHeroes)
			{
				GeneratePanel(item);

			}
		}

		public void GeneratePanel(GameObject heroObject) 
		{
			heroObject = _heroFactory.SpawnOnUI(singleHeroPanel, heroListPanel, HeroStatusEnum.InTavern);
			TextMeshProUGUI[] heroClassTexts = heroObject.GetComponentsInChildren<TextMeshProUGUI>();
			heroObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = heroObject.GetComponent<Hero>().HeroClass.ToString();
			heroObject.GetComponentsInChildren<TextMeshProUGUI>()[1].text = heroObject.GetComponent<Hero>().Level.ToString();
			heroObject.GetComponentsInChildren<TextMeshProUGUI>()[2].text = "BUY\n" + heroObject.GetComponent<Hero>().HeroValue.Value.ToString();
			Image heroImage = heroObject.GetComponentInChildren<Image>();
		}

		

		private void KillAllChildren(GameObject parentObject) 
		{
			if (parentObject.transform.childCount!=0) {
            	foreach (Transform child in parentObject.transform) {
            	GameObject.Destroy(child.gameObject);
            	}
        	}
		}


		public bool ValidatePurchase(ReactiveProperty<int> value) 
		{
			return GameState.Instance.gold.Value > value.Value ? true : false;
		}


		


	}
	
}
