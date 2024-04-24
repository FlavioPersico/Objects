using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageble
{

    [SerializeField] protected float speed;
	[SerializeField] protected Rigidbody2D rb_character;
	[SerializeField] protected Weapon weapon;
	protected Health health;

	public Character()
	{
		this.speed = 5f;
	}

	public Character(float speedParam, int healthParam, Weapon weaponParam)
	{
		this.speed = speedParam;
		this.health = new Health(healthParam);
		this.weapon = weaponParam;
	}

	protected virtual void Start()
	{
		health = new Health(5);
	}

	public abstract void Attack();
    public abstract void Die();
	public virtual void Move(Vector2 direction, float angle)
    {
		rb_character.AddForce(direction.normalized * speed * Time.deltaTime * 500f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	public void ReceiveDamage()
	{
		health.TakeDamage();
	}
	public void ReceiveDamage(int damage)
	{
		health.TakeDamage(damage);
	}

	public void SetWeapon(Weapon newWeapon)
	{
		this.weapon = newWeapon;
	}
}
