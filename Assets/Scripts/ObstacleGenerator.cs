using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
	
	public Transform player;
	public GameObject obstacle;
	private float spawnDelay = 1f;
	private float timeSpawned = 0f;
	private int spawnMarge = 120;
	private int pos = 0;
	private float timeIncreaseDifficulty = 0f;
	private float difficultyDelay = 5f;

	void Update () {
		if ((Time.time - timeSpawned) >= spawnDelay)
		{
			timeSpawned = Time.time;
			generateObstacle();
		}
		if (Time.time - timeIncreaseDifficulty >= difficultyDelay)
		{
			timeIncreaseDifficulty = Time.time;
			if (spawnDelay > 0.2f)
			{
				spawnDelay -= 0.1f;
				if (spawnDelay < 0.2f) spawnDelay = 0.2f;
			}
		}
	}

	void generateObstacle()
	{
		if (player.position.x < -2.8f) pos = -1;
		else if (player.position.x < 2.8f) pos = 0;
		else pos = 1;
		/*
		 * Compliquer les levels en mettant les symétriques des fonctions latérals
		 */
		int randDifficulty = Random.Range(1, 101);
		if (randDifficulty < 60) // Easy
		{
			int rand = Random.Range(1, 6);
			if (rand == 1) Template1(pos);
			if (rand == 2) Template2(pos);
			if (rand == 3) Template4(pos);
			if (rand == 4) Template5(pos);
			if (rand == 5) Template6(pos);
		}
		else if(randDifficulty < 90) // Medium
		{
			int rand = Random.Range(1, 3);
			if (rand == 1) Template7(pos);
			if (rand == 2) Template10();
		}
		else // Hard
		{
			int rand = Random.Range(1,4);
			if (rand == 1) Template3(pos);
			if (rand == 2) Template8(pos, 2f, 10f);
			if (rand == 3) Template9(pos, 2f, 10f);
		}
	}

	/* Mur droit */
	void Template1(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 6;
		else if (pos == 1) delta = 12;
		Instantiate(obstacle, new Vector3(-7.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-6.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-5.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-4.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
	}

	/* Mur droit espacé */
	void Template2(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 4.5f;
		else if (pos == 1) delta = 9;
		Instantiate(obstacle, new Vector3(-7.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-6f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-1.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
	}

	/* Mur dégradé long */
	void Template3(int pos)
	{
		if (pos == 0) pos = 1;
		timeSpawned += 2 * spawnDelay;
		Instantiate(obstacle, new Vector3(-7.5f * pos, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-6.5f * pos, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-5.5f * pos, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-4.5f * pos, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3.5f * pos, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-2.5f * pos, 1f, player.position.z + spawnMarge + 5), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-1.5f * pos, 1f, player.position.z + spawnMarge + 6), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-0.5f * pos, 1f, player.position.z + spawnMarge + 7), Quaternion.identity);
		Instantiate(obstacle, new Vector3(0.5f * pos, 1f, player.position.z + spawnMarge + 8), Quaternion.identity);
		Instantiate(obstacle, new Vector3(1.5f * pos, 1f, player.position.z + spawnMarge + 9), Quaternion.identity);
		Instantiate(obstacle, new Vector3(2.5f * pos, 1f, player.position.z + spawnMarge + 10), Quaternion.identity);
		Instantiate(obstacle, new Vector3(3.5f * pos, 1f, player.position.z + spawnMarge + 11), Quaternion.identity);
		Instantiate(obstacle, new Vector3(4.5f * pos, 1f, player.position.z + spawnMarge + 12), Quaternion.identity);
	}

	

	/* Mur dégradé court arrière */
	void Template4(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 5.5f;
		else if (pos == 1) delta = 11;
		Instantiate(obstacle, new Vector3(-7.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-6.5f + delta, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-5.5f + delta, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-4.5f + delta, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3.5f + delta, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
	}

	/* Mur dégradé court avant */
	void Template5(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 5.5f;
		else if (pos == 1) delta = 11;
		Instantiate(obstacle, new Vector3(-7.5f + delta, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-6.5f + delta, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-5.5f + delta, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-4.5f + delta, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3.5f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
	}

	/* Mur V */
	void Template6(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 4;
		else if (pos == 1) delta = 8;
		Instantiate(obstacle, new Vector3(-4f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3f + delta, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-5f + delta, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-2f + delta, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-6f + delta, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
	}

	/* Mur ^ large */
	void Template7(int pos)
	{
		float delta = 0;
		if (pos == -1) delta = -4.5f;
		else if (pos == 1) delta = 4.5f;
		Instantiate(obstacle, new Vector3(0f + delta, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
		Instantiate(obstacle, new Vector3(1f + delta, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-1f + delta, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(2f + delta, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-2f + delta, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(3f + delta, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3f + delta, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(3f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(-3f + delta, 1f, player.position.z + spawnMarge), Quaternion.identity);
	}

	/* Mur // */
	void Template8(int pos, float espace, float profondeur)
	{
		timeSpawned += 2.5f * spawnDelay;
		float depart = -7.5f;
		if (pos == 0) depart = -4.5f;
		else if (pos == 1) depart = -0.5f - espace;
		float depart2 = depart + espace + 4;
		Instantiate(obstacle, new Vector3(depart2, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 + 1, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 + 2, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 + 3, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 + 4, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart, 1f, player.position.z + spawnMarge + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart + 1, 1f, player.position.z + spawnMarge + 1 + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart + 2, 1f, player.position.z + spawnMarge + 2 + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart + 3, 1f, player.position.z + spawnMarge + 3 + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart + 4, 1f, player.position.z + spawnMarge + 4 + profondeur), Quaternion.identity);
		for (int i = -7; i < 8; i++)
		{
			if (i < depart)
			{
				Instantiate(obstacle, new Vector3(i - 0.5f, 1f, player.position.z + spawnMarge + profondeur), Quaternion.identity);
			}
			else if (i > depart2 + 4)
			{
				Instantiate(obstacle, new Vector3(i + 0.5f, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
			}
		}
	}

	/* Mur \\ */
	void Template9(int pos, float espace, float profondeur)
	{
		timeSpawned += 2.5f * spawnDelay;
		float depart = 7.5f;
		if (pos == 0) depart = 4.5f;
		else if (pos == 1) depart = 0.5f + espace;
		float depart2 = depart - espace - 4;
		Instantiate(obstacle, new Vector3(depart2, 1f, player.position.z + spawnMarge), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 - 1, 1f, player.position.z + spawnMarge + 1), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 - 2, 1f, player.position.z + spawnMarge + 2), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 - 3, 1f, player.position.z + spawnMarge + 3), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart2 - 4, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart, 1f, player.position.z + spawnMarge + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart - 1, 1f, player.position.z + spawnMarge + 1 + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart - 2, 1f, player.position.z + spawnMarge + 2 + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart - 3, 1f, player.position.z + spawnMarge + 3 + profondeur), Quaternion.identity);
		Instantiate(obstacle, new Vector3(depart - 4, 1f, player.position.z + spawnMarge + 4 + profondeur), Quaternion.identity);
		for (int i = -7; i < 8; i++)
		{
			if (i < depart2 - 4)
			{
				Instantiate(obstacle, new Vector3(i - 0.5f, 1f, player.position.z + spawnMarge + 4), Quaternion.identity);
			}
			else if (i > depart)
			{
				Instantiate(obstacle, new Vector3(i + 0.5f, 1f, player.position.z + spawnMarge + profondeur), Quaternion.identity);
			}
		}
	}

	/* Mur passage */
	void Template10(int espace = 2)
	{
		timeSpawned += 1.75f * spawnDelay;
		int originePassage = (int)Mathf.Floor(player.position.x*-1);
		int finPassage = originePassage + espace;
		for (int i = -7; i<=8; i++)
		{
			if (i < originePassage || i > finPassage)
			{
				Instantiate(obstacle, new Vector3(i-0.5f, 1f, player.position.z + spawnMarge), Quaternion.identity);
			}
		}
	}
}
