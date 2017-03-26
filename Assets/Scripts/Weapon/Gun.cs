using UnityEngine;
using System.Timers;
using System;

public class Gun
{
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
		Debug.Log ("was not just fired: " + wasNotJustFired);
		Debug.Log ("reloading: " + reloading);
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
		}
	}

	public void Reload()
	{
		if (!reloading) {
			reloading = true;
			reloadTimer.Start ();
		}
	}

	private void ReloadFinished(object sender, ElapsedEventArgs e)
	{
		reloading = false;
		rounds = magazineSize;
	}
}

