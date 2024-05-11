using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	[SerializeField] protected float spawnProbability;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			PickMe(collision.gameObject.GetComponent<Character>());
		}
	}

	protected virtual void PickMe(Character character)
	{
		Destroy(gameObject);
	}

	public virtual float SpawnProbability()
	{
		return spawnProbability;
	}
}
