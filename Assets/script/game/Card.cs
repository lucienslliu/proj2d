using UnityEngine;
using System.Collections;

public struct cardInfo
{
	public int cardID;
	public int life;
	public int attack;
	public int cost;

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

	public UILabel m_life;
	public UILabel m_cost;
	public UILabel m_attack;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public int GetCardID()
	{
		return m_cardInfo.cardID;
	}
	
	public void Init(int nId)
	{
		cardInfo info = CardMgr.Instance.GetCardInfo(nId);
		m_cardInfo = new cardInfo(info);//new cardInfo(1, 5, 10, 13);
		UpdateCard();
	}
	
	private void UpdateCard()
	{
		m_life.text = "life: " + m_cardInfo.life.ToString();
		m_cost.text = "cost: " + m_cardInfo.cost.ToString();
		m_attack.text = "atk: " + m_cardInfo.attack.ToString();
	}
}
