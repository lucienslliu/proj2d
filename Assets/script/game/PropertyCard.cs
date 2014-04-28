using UnityEngine;
using System.Collections;

public class PropertyCard
{	
	private const int m_MaxCardNum = 30;
	private const int m_MaxGetCardNum = 8;

	private ArrayList m_BagCardList = new ArrayList(m_MaxCardNum);
	private ArrayList m_HandCardList = new ArrayList(m_MaxGetCardNum);

	// Use this for initialization
	public PropertyCard() 
	{
		for(int i = 0; i < m_MaxCardNum; i++)
		{
			int nId = i % 2;
			Card card = new Card(nId);
			m_BagCardList.Add(card);
		}
	}

	public void GetOneCard()
	{
		if (m_HandCardList.Count < m_MaxGetCardNum)
		{
			int nIndex = Random.Range(0, m_BagCardList.Count - 1);
			Card[] cardList = (Card[])m_BagCardList.ToArray(typeof(Card));
			m_HandCardList.Add(cardList[nIndex]);
			m_BagCardList.RemoveAt(nIndex);
		}
	}
}
