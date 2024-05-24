using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SniperEnemy : Enemy
{
	[SerializeField] private LineRenderer lineRenderer;
	private float lastShot;

	private void FixedUpdate()
	{
		if (target != null)
		{
			if (Vector2.Distance(target.transform.position, transform.position) <= attackDistance)
			{ 
				lineRenderer.SetPosition(0, transform.position);
				lineRenderer.SetPosition(1, target.transform.position);
				transform.rotation = Quaternion.Euler(0, 0, angle);
			}
			else
			{
				lineRenderer.SetPosition(0, Vector3.zero);
				lineRenderer.SetPosition(1, Vector3.zero);
			}
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
		if (Time.time > lastShot + weapon.fireRate)
		{
			base.Attack();
			lastShot = Time.time;
		}
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
}
