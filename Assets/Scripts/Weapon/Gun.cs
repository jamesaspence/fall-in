using UnityEngine;
using System.Timers;
using System;

public abstract class Gun: MonoBehaviour
{
	public GameObject bulletPrefab;
	
	private int magazineSize;
	private int rateOfFire;
	private float range;

	private int rounds;
	private bool reloading = false;
	private Timer reloadTimer;
	private DateTime lastFired;

	public Gun(int magazineSize, int rateOfFire, int reloadSpeed, float range)
	{
		this.magazineSize = magazineSize;
		this.rounds = magazineSize;
		this.rateOfFire = rateOfFire;
		this.range = range;

		Timer reloadTimer = new Timer ();
		reloadTimer.Interval = reloadSpeed;
		reloadTimer.AutoReset = false;
		reloadTimer.Elapsed += ReloadFinished;
		this.reloadTimer = reloadTimer;
	}

	public int GetRounds()
	{
		return rounds;
	}

	public bool CanFire()
	{
		bool wasNotJustFired = lastFired <= System.DateTime.Now.Subtract (TimeSpan.FromMilliseconds (rateOfFire));
		return (
			!reloading &&
			rounds > 0 &&
			wasNotJustFired
		);
	}

	public void Fire(Transform transform)
	{
		if (CanFire ()) {
			Debug.Log ("Bang.");
			rounds--;
			lastFired = System.DateTime.Now;

			RaycastHit hit;

			Ray bullet = new Ray (transform.position, transform.forward);
			if (Physics.Raycast (bullet, out hit, this.range)) {
				GameObject gameObject = hit.collider.gameObject;
				Debug.Log (gameObject);
			}
			CreateBulletPrefab ();
		}
	}

	private void CreateBulletPrefab()
	{
		Vector3 start = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
		Instantiate(bulletPrefab, start, bulletPrefab.transform.rotation);
	}

	public void Reload()
	{
		if (!reloading && rounds != magazineSize) {
			reloading = true;
			rounds = 0;
			reloadTimer.Start ();
		}
	}

	private void ReloadFinished(object sender, ElapsedEventArgs e)
	{
		reloading = false;
		rounds = magazineSize;
	}
}

