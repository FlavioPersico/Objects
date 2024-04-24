using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon: ScriptableObject
{
    [SerializeField] private Bullet bulletReference;
	[SerializeField] private string name;
	[SerializeField] private Sprite icon;
	[SerializeField] public int damage;
    [SerializeField] public float fireRate;

	public Weapon()
    {

    }
    public Weapon(Bullet bullet)
    {
        this.bulletReference = bullet;
    }

    public void Shoot(Vector2 position, Quaternion direction, string tag)
    {
		Bullet tempBullet = GameObject.Instantiate(bulletReference, position, direction);
		tempBullet.SetUpBullet(tag, damage);
	}
}
