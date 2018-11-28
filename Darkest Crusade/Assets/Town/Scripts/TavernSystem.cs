﻿using System.Collections;
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

		public void BuyHero(GameObject obj) {
			
		}

		public void PopulatePanel(ReactiveCollection<GameObject> tavernHeroes) 
		{
			while (tavernHeroes.Count < 4)
			{
				Debug.Log(GameState.Instance.tavernHeroes.Count);
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
			TextMeshProUGUI[] heroClass = heroObject.GetComponentsInChildren<TextMeshProUGUI>();
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