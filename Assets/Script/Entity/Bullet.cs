using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    public float bulletSpeed;
	private string targetTag;
	private int damage;

	private void Start()
	{
		Destroy(gameObject, 3f);	
	}

	public void SetUpBullet(string tag, int damageParam)
	{
		damage = damageParam;
		targetTag = tag;
	}
	private void Update()
	{
		transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(targetTag))
		{
			collision.GetComponent<IDamageble>().ReceiveDamage(damage);
			Destroy(this.gameObject);
		}
	}
}