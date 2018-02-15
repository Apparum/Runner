using UnityEngine;
using System.Collections;

public class AddScoreProximity : MonoBehaviour {

	private GameObject player;
	public int score = 0;
	private float detectionRange = 20f;

	void Update () {
		player = GameObject.Find("Player");
		if (player != null && Vector3.Distance(player.transform.position, transform.position) < detectionRange)
		{
			score += 1;
		}
	}
}
