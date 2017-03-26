using UnityEngine;
using System.Timers;
using System;

public class Gun
{
	private int magazineSize;
	private int rateOfFire;

	private int rounds;
	private bool reloading = false;
	private Timer reloadTimer;
	private DateTime lastFired;

	public Gun(int magazineSize, int rateOfFire, int reloadSpeed)
	{
		this.magazineSize = magazineSize;
		this.rounds = magazineSize;
		this.rateOfFire = rateOfFire;

		Timer reloadTimer = new Timer ();
		reloadTimer.Interval = reloadSpeed;
		reloadTimer.AutoReset = false;
		reloadTimer.Elapsed += new ElapsedEventHandler (ReloadFinished);
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

	public void Fire()
	{
		if (CanFire ()) {
			Debug.Log ("Bang.");
			rounds--;
			lastFired = System.DateTime.Now;
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

