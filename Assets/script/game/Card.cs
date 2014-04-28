using UnityEngine;
using System.Collections;

public struct cardInfo
{
	int cardID;
	int life;
	int attack;
	int cost;

	public cardInfo(int id, int l, int atk, int c)
	{
		cardID = id;
		life = l;
		attack = atk;
		cost = c;
	}
	
	public cardInfo(cardInfo info)
	{
		cardID = info.cardID;
		life = info.life;
		attack = info.attack;
		cost = info.cost;
	}
}

public class Card : MonoBehaviour 
{
	private cardInfo m_cardInfo;
	private int m_nCost = 0;

	public Card(int index)
	{
		m_cardInfo = new cardInfo(CardMgr.Instance.cardTemplate[index]);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


}
