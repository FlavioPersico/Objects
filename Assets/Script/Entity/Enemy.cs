using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : Character
{
	protected Player target;
	//[SerializeField] protected Weapon weapon;
	[SerializeField] protected float attackDistance;
	protected float angle;


	protected override void Start()
	{
		
	}

	private void FixedUpdate()
	{
		if (target != null)
		{
			Vector2 direction = target.transform.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Move(direction, angle);
		}
	}

	public Enemy()
	{

	}

	public virtual void SetUpEnemy(int healthParam)
	{
		target = FindObjectOfType<Player>();
		health = new Health(healthParam);
		health.OnHealthChange.AddListener(ChangeHealth);
	}

	public virtual void ChangeHealth(int health)
	{
		Debug.Log($"Health Changed! {health}");
		if(health <= 0)
		{
			GameManager.singleton.scoreManager.IncreaseScore();
			Die();
		}
	}

	public override void Attack()
	{
		rb_character.velocity = Vector2.zero;
		if(attackDistance > 0.1f)
		{
			weapon.Shoot(transform.position, transform.rotation, "Player");
		}
		else
		{
			target.ReceiveDamage(weapon.damage);
		}
	}

	public override void Die()
	{
		Destroy(gameObject);
	}

	public override void Move(Vector2 direction, float angle)
	{
		if(Vector2.Distance(target.transform.position, transform.position) > attackDistance)
		{
			base.Move(direction, angle);
		}
		else
		{
			Attack();
		}
	}
}
