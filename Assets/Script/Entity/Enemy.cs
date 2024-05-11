using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : Character
{
	protected Player target;
	//[SerializeField] protected Weapon weapon;
	[SerializeField] protected float attackDistance;
	[SerializeField] protected GameObject[] pickUpPrefab;
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
		//Debug.Log($"Health Changed! {health}");
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
		GenerateRandomLoot();
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

	private void GenerateRandomLoot()
	{
		GameObject randomLootPrefab = pickUpPrefab[Random.Range(0, pickUpPrefab.Length)];
		float randomSpawnProbability = Random.Range(0.0f, 1.0f);

		float spanwProbability = randomLootPrefab.GetComponent<PickUp>().SpawnProbability();

		Debug.Log(spanwProbability);
		if(spanwProbability >= randomSpawnProbability)
		{
			Instantiate(randomLootPrefab, transform.position, Quaternion.identity);
		}
	}
}
