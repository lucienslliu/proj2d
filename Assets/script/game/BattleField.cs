using UnityEngine;
using System.Collections;

public struct UnitSlot
{
	public bool m_Used;
	public Unit m_Unit;
}

public class BattleField : MonoBehaviour 
{
	private const int m_MaxUnitNum = 8;
	private UnitSlot[] m_Units;

	public Transform m_UnitPrefab;

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

	public void CreateUnit()
	{
		UpdateUnit();
	}

	private void UpdateUnit()
	{
	}
}
