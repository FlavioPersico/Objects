using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : Character
{
	//[SerializeField] private Weapon weapon;
	[SerializeField] private Bullet bullet;
	private float lastShot;
	private bool powerUpShot;
	private Cooldown powerUpCoolDown;
	[SerializeField] private AudioClip dieAudio;

	protected override void Start()
	{
		health = new Health(100);
		rb_character = GetComponent<Rigidbody2D>();
		powerUpCoolDown = GetComponent<Cooldown>();
		health.OnHealthChange.AddListener(ChangeHealth);
	}

	public void ChangeHealth(int health)
	{
		UiManager.singleton.UpdateHealth(health);
		Debug.Log($"Health Changed! {health}");
		if (health <= 0)
		{
			Die();
		}
	}

	public override void Attack()
	{
		if (Time.time > lastShot + weapon.fireRate)
		{
			weapon.Shoot(transform.position, transform.rotation, "Enemy");
			lastShot = Time.time;
		}
	}

	public void NukeBomb()
	{
		weapon.ExplodeNuke();
	}

	public override void Die()
	{
		GameManager.singleton.EndGame();
		SoundControl.audioPlayer.PlayOneShot(dieAudio, 50f);
		Destroy(this.gameObject);
	}

	public override void Move(Vector2 direction, float angle)
	{
		base.Move(direction, angle);
	}

	public void ReceiveDamage(int damage)
	{
		health.TakeDamage(damage);
	}

	public bool GetPowerUp()
	{
		return powerUpCoolDown.GetCollingDown();
	}

	public void PowerUp(bool powerUpParam)
	{
		powerUpCoolDown.SetCollingDown(powerUpParam);
		powerUpShot = powerUpParam;
	}
}
