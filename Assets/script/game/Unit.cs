using UnityEngine;
using System.Collections;

public class Property
{
	public int m_sequence;
	public int m_life;
	public int m_attack;
	public float m_attackInterval;
	public float m_moveInterval;
}

public class Unit : MonoBehaviour 
{
	public Property m_Property = new Property();

	public UILabel m_life;
	public UILabel m_attack;
	public UILabel m_seq;

	public Player m_Owner;

	private float m_AttackCurTime = 0;
	private float m_MoveCurTime = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (true == IsDead())
		{
			return;
		}

		// 向前进
		GoForward();

		// 攻击对手
		Attack();
	}

	public void SetProperty(cardInfo info, int seq)
	{
		m_Property.m_attack = info.attack;
		m_Property.m_life = info.life;
		m_Property.m_sequence = seq;
		m_Property.m_attackInterval = 3.0f;
		m_Property.m_moveInterval = 2.0f;

		UpdatePropertyDisp();
	}

	private void UpdatePropertyDisp()
	{
		m_life.text = "life: " + m_Property.m_life.ToString();
		m_attack.text = "atk: " + m_Property.m_attack.ToString();
		m_seq.text = "seq: " + m_Property.m_sequence.ToString();

		if (m_Owner.m_Index == 0)
		{
			m_life.color = new Color(1, 0, 0, 1);
			m_attack.color = new Color(1, 0, 0, 1);
		}
		else
		{
			m_life.color = new Color(0, 1, 0, 1);
			m_attack.color = new Color(0, 1, 0, 1);
		}
	}

	public bool IsDead()
	{
		if (m_Property.m_life <= 0)
		{
			return true;
		}

		return false;
	}

	private void GoForward()
	{
		// 向前移动，等策划想好如何移动
	}

	private void Attack()
	{
		if (m_AttackCurTime < m_Property.m_attackInterval)
		{
			m_AttackCurTime += Time.deltaTime;
			return;
		}
		m_AttackCurTime = 0;

		// 有目标打目标，没有就打Player
		Unit target = GameManager.Instance.m_BattleField.FindEnemyUnit(m_Owner);
		if (target != null)
		{
			target.BeAttacked(this.m_Property.m_attack);
		}
		else
		{
			Player p = GameManager.Instance.GetOtherPlayer(m_Owner);
			p.SetLife(p.GetLife() - m_Property.m_attack);
		}
	}

	private void BeAttacked(int attack)
	{
		SetLife(m_Property.m_life - attack);
	}

	public int GetLife()
	{
		return m_Property.m_life;
	}

	private void SetLife(int life)
	{
		m_Property.m_life = life;
		m_life.text = "life: " + m_Property.m_life.ToString();
	}
}
