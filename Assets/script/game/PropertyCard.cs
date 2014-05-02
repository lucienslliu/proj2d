using UnityEngine;
using System.Collections;

public class PropertyCard : MonoBehaviour 
{	
	private const int m_MaxCardNum = 10;
	private const int m_MaxGetCardNum = 8;

	private ArrayList m_BagCardList = new ArrayList(m_MaxCardNum);
	private ArrayList m_HandCardList = new ArrayList(m_MaxGetCardNum);

	public Transform m_CardPrefab;
	public Player m_Owner;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < m_MaxCardNum; i++)
		{
			int nId = i % 2;

			GameObject go = NGUITools.AddChild(this.gameObject, m_CardPrefab.gameObject);
			GameObject a = GameObject.Find("card");
			UIButton abtn = a.GetComponent<UIButton>();

			go.transform.localScale = a.transform.localScale;
			go.transform.localPosition = new Vector3(-40, 0, i);

			Card card = go.GetComponent<Card>();
			card.Init(nId);

			m_BagCardList.Add(go.transform);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}


	public void GetOneCard(Player player)
	{
		if (m_BagCardList.Count <= 0)
		{
			return;
		}

		if (m_HandCardList.Count < m_MaxGetCardNum)
		{
			int nIndex = Random.Range(0, m_BagCardList.Count - 1);
			Transform[] cardList = (Transform[])m_BagCardList.ToArray(typeof(Transform));
			Card cardOld = cardList[nIndex].GetComponent<Card>();
			cardOld.SetInHand(true);

			//Transform trans = (Transform)Instantiate(m_CardPrefab, Vector3.zero, Quaternion.identity);
			//Card card = trans.GetComponent<Card>();
			//card.Init(cardOld.GetCardID());

			m_HandCardList.Add(cardList[nIndex]);
			m_BagCardList.RemoveAt(nIndex);

			UpdateCardPos(true);
		}
	}

	private void UpdateCardPos(bool active)
	{
		Transform[] cardList = (Transform[])m_HandCardList.ToArray(typeof(Transform));
		for (int i = 0; i < m_HandCardList.Count; i++)
		{
			cardList[i].localPosition = new Vector3(50 + i * 80, cardList[i].localPosition.y);
			cardList[i].gameObject.SetActive(active);
		}
	}

	public Player GetPlayer()
	{
		return m_Owner;
	}

	public void UseCard(Card card)
	{
		UpdateCardPos(false);
		m_HandCardList.Remove(card.transform);
		UpdateCardPos(true);
	}
}



















