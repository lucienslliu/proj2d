using UnityEngine;
using System.Collections;

public struct UnitSlot
{
	public bool m_Used;
	public Transform m_Unit;
}

public class BattleField : MonoBehaviour 
{
	private const int m_MaxUnitNum = 10;
	private UnitSlot[] m_Units;

	public Transform m_UnitPrefab;
	public static int InvalidSlotIndex = -1;

	public enum SearchSeq
	{
		SearchSeq_Clockwise = 0,
		SearchSeq_CountClockwise = 1,
	}

	// Use this for initialization
	void Start () 
	{
		m_Units = new UnitSlot[m_MaxUnitNum];
		for (int i = 0; i < m_MaxUnitNum; i++)
		{
			m_Units[i].m_Used = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void CreateUnit(Card card)
	{
		SearchSeq ss = (SearchSeq)card.m_owner.m_Index;

		// 使用之前检测过了，这里就不再检测了，但需要按顺序搜了
		int index = FindEmptySlot(ss);
		
		GameObject obj = NGUITools.AddChild(this.gameObject, m_UnitPrefab.gameObject);
		GameObject a = GameObject.Find("unit");
		obj.transform.localScale = a.transform.localScale;
		Unit unit = obj.GetComponent<Unit>();
		unit.m_Owner = card.m_owner;
		unit.SetProperty(card.m_cardInfo);

		m_Units[index].m_Used = true;
		m_Units[index].m_Unit = obj.transform;

		UpdateUnit(true);
	}

	public bool HasEmptySlot()
	{
		return (FindEmptySlot(BattleField.SearchSeq.SearchSeq_Clockwise) != InvalidSlotIndex);
	}

	public int FindEmptySlot(BattleField.SearchSeq s)
	{
		if (s == SearchSeq.SearchSeq_Clockwise)
		{
			for (int i = 0; i < m_MaxUnitNum; i++)
			{
				if (m_Units[i].m_Used == false)
				{
					return i;
				}
			}
		}
		else if (s == SearchSeq.SearchSeq_CountClockwise)
		{
			for (int i = m_MaxUnitNum -1; i >= 0; i--)
			{
				if (m_Units[i].m_Used == false)
				{
					return i;
				}
			}
		}

		return InvalidSlotIndex;
	}

	private void UpdateUnit(bool active)
	{
		for (int i = 0; i < m_MaxUnitNum; i++)
		{
			if (m_Units[i].m_Used == true)
			{
				m_Units[i].m_Unit.localPosition = new Vector3(30 + i * 80, m_Units[i].m_Unit.localPosition.y);
				m_Units[i].m_Unit.gameObject.SetActive(active);
			}
		}
	}
}
