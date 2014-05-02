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
	public UILabel m_attack;
	public UILabel m_cost;

	private bool m_bInHand = false;
	public Player m_owner;

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

	public void SetInHand(bool inHand)
	{
		m_bInHand = inHand;
	}

	public void OnCardClick()
	{
		PropertyCard p = this.transform.parent.gameObject.GetComponent<PropertyCard>();
		Player player = p.GetPlayer();
		if (false == Cost(player))
		{
			return;
		}

		p.UseCard(this);
	}

	private bool Cost(Player p)
	{
		int energe = p.GetEnerge();
		if (false == CheckCost(energe))
		{
			return false;
		}

		p.SetEnerge(energe - m_cardInfo.cost);

		return true;
	}

	private bool CheckCost(int energe)
	{
		if (energe < m_cardInfo.cost)
		{
			return false;
		}

		return true;
	}
}
