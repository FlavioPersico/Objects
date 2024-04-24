using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : Enemy
{

	private void FixedUpdate()
	{
		if (target != null)
		{
			Vector2 direction = target.transform.position - transform.position;
			angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Move(direction, angle);
		}
	}
	public override void SetUpEnemy(int healthParam)
	{
		base.SetUpEnemy(healthParam);
	}

	public override void Attack()
	{
		base.Attack();
		Die();
	}

	public override void ChangeHealth(int health)
	{
		base.ChangeHealth(health);
	}

	public override void Move(Vector2 direction, float angle)
	{
		base.Move(direction, angle);
	}

	public override void Die()
	{
		base.Die();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Attack();
		}
	}
}
