using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {
	
	public Transform player;
	public GameObject obstacle;
    public GameObject diamond;
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

    void genObstacleObj(float x, float y, float z)
    {
        Instantiate(obstacle, new Vector3(x, y, z), Quaternion.identity);
    }

    void genDiamondObj(float x, float y, float z)
    {
        Instantiate(diamond, new Vector3(x, y, z), Quaternion.Euler(new Vector3(90, 0, 0)));
    }

    void generateObstacle()
	{
		if (player.position.x < -2.8f) pos = -1;
		else if (player.position.x < 2.8f) pos = 0;
		else pos = 1;
        /*
		 * Compliquer les levels en mettant les symétriques des fonctions latérals
		 */
        genDiamondObj(player.position.x, 1.5f, player.position.z + spawnMarge);
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
            timeSpawned += 1.4f * spawnDelay;
            int rand = Random.Range(1, 5);
			if (rand == 1) Template7(pos);
            if (rand == 2) Template10();
            if (rand == 3) Template11();
            if (rand == 4) Template12();
        }
		else // Hard
        {
            timeSpawned += 1.9f * spawnDelay;
            int rand = Random.Range(1,5);
			if (rand == 1) Template3(pos);
			if (rand == 2) Template8(pos, 2f, 10f);
			if (rand == 3) Template9(pos, 2f, 10f);
            if (rand == 4) Template13();
        }
	}

	/* Mur droit */
	void Template1(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 6;
		else if (pos == 1) delta = 12;
		genObstacleObj(-7.5f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-6.5f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-5.5f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-4.5f + delta, 1f, player.position.z + spawnMarge);
	}

	/* Mur droit espacé */
	void Template2(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 4.5f;
		else if (pos == 1) delta = 9;
		genObstacleObj(-7.5f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-6f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-3f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-1.5f + delta, 1f, player.position.z + spawnMarge);
	}

	/* Mur dégradé long */
	void Template3(int pos)
	{
		if (pos == 0) pos = 1;
		genObstacleObj(-7.5f * pos, 1f, player.position.z + spawnMarge);
		genObstacleObj(-6.5f * pos, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(-5.5f * pos, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(-4.5f * pos, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(-3.5f * pos, 1f, player.position.z + spawnMarge + 4);
		genObstacleObj(-2.5f * pos, 1f, player.position.z + spawnMarge + 5);
		genObstacleObj(-1.5f * pos, 1f, player.position.z + spawnMarge + 6);
		genObstacleObj(-0.5f * pos, 1f, player.position.z + spawnMarge + 7);
		genObstacleObj(0.5f * pos, 1f, player.position.z + spawnMarge + 8);
		genObstacleObj(1.5f * pos, 1f, player.position.z + spawnMarge + 9);
		genObstacleObj(2.5f * pos, 1f, player.position.z + spawnMarge + 10);
		genObstacleObj(3.5f * pos, 1f, player.position.z + spawnMarge + 11);
		genObstacleObj(4.5f * pos, 1f, player.position.z + spawnMarge + 12);
	}

	

	/* Mur dégradé court arrière */
	void Template4(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 5.5f;
		else if (pos == 1) delta = 11;
		genObstacleObj(-7.5f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-6.5f + delta, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(-5.5f + delta, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(-4.5f + delta, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(-3.5f + delta, 1f, player.position.z + spawnMarge + 4);
	}

	/* Mur dégradé court avant */
	void Template5(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 5.5f;
		else if (pos == 1) delta = 11;
		genObstacleObj(-7.5f + delta, 1f, player.position.z + spawnMarge + 4);
		genObstacleObj(-6.5f + delta, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(-5.5f + delta, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(-4.5f + delta, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(-3.5f + delta, 1f, player.position.z + spawnMarge);
	}

	/* Mur V */
	void Template6(int pos)
	{
		float delta = 0;
		if (pos == 0) delta = 4;
		else if (pos == 1) delta = 8;
		genObstacleObj(-4f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-3f + delta, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(-5f + delta, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(-2f + delta, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(-6f + delta, 1f, player.position.z + spawnMarge + 2);
	}

	/* Mur ^ large */
	void Template7(int pos)
	{
		float delta = 0;
		if (pos == -1) delta = -4.5f;
		else if (pos == 1) delta = 4.5f;
		genObstacleObj(0f + delta, 1f, player.position.z + spawnMarge + 4);
		genObstacleObj(1f + delta, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(-1f + delta, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(2f + delta, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(-2f + delta, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(3f + delta, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(-3f + delta, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(3f + delta, 1f, player.position.z + spawnMarge);
		genObstacleObj(-3f + delta, 1f, player.position.z + spawnMarge);
	}

	/* Mur // */
	void Template8(int pos, float espace, float profondeur)
	{
		float depart = -7.5f;
		if (pos == 0) depart = -4.5f;
		else if (pos == 1) depart = -0.5f - espace;
		float depart2 = depart + espace + 4;
		genObstacleObj(depart2, 1f, player.position.z + spawnMarge);
		genObstacleObj(depart2 + 1, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(depart2 + 2, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(depart2 + 3, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(depart2 + 4, 1f, player.position.z + spawnMarge + 4);
		genObstacleObj(depart, 1f, player.position.z + spawnMarge + profondeur);
		genObstacleObj(depart + 1, 1f, player.position.z + spawnMarge + 1 + profondeur);
		genObstacleObj(depart + 2, 1f, player.position.z + spawnMarge + 2 + profondeur);
		genObstacleObj(depart + 3, 1f, player.position.z + spawnMarge + 3 + profondeur);
		genObstacleObj(depart + 4, 1f, player.position.z + spawnMarge + 4 + profondeur);
		for (int i = -7; i < 8; i++)
		{
			if (i < depart)
			{
				genObstacleObj(i - 0.5f, 1f, player.position.z + spawnMarge + profondeur);
			}
			else if (i > depart2 + 4)
			{
				genObstacleObj(i + 0.5f, 1f, player.position.z + spawnMarge + 4);
			}
		}
	}

	/* Mur \\ */
	void Template9(int pos, float espace, float profondeur)
	{
		float depart = 7.5f;
		if (pos == 0) depart = 4.5f;
		else if (pos == 1) depart = 0.5f + espace;
		float depart2 = depart - espace - 4;
		genObstacleObj(depart2, 1f, player.position.z + spawnMarge);
		genObstacleObj(depart2 - 1, 1f, player.position.z + spawnMarge + 1);
		genObstacleObj(depart2 - 2, 1f, player.position.z + spawnMarge + 2);
		genObstacleObj(depart2 - 3, 1f, player.position.z + spawnMarge + 3);
		genObstacleObj(depart2 - 4, 1f, player.position.z + spawnMarge + 4);
		genObstacleObj(depart, 1f, player.position.z + spawnMarge + profondeur);
		genObstacleObj(depart - 1, 1f, player.position.z + spawnMarge + 1 + profondeur);
		genObstacleObj(depart - 2, 1f, player.position.z + spawnMarge + 2 + profondeur);
		genObstacleObj(depart - 3, 1f, player.position.z + spawnMarge + 3 + profondeur);
		genObstacleObj(depart - 4, 1f, player.position.z + spawnMarge + 4 + profondeur);
		for (int i = -7; i < 8; i++)
		{
			if (i < depart2 - 4)
			{
				genObstacleObj(i - 0.5f, 1f, player.position.z + spawnMarge + 4);
			}
			else if (i > depart)
			{
				genObstacleObj(i + 0.5f, 1f, player.position.z + spawnMarge + profondeur);
			}
		}
	}

	/* Mur passage */
	void Template10(int espace = 2)
	{
		int originePassage = (int)Mathf.Floor(player.position.x*-1);
		int finPassage = originePassage + espace;
		for (int i = -7; i<=8; i++)
		{
			if (i < originePassage || i > finPassage)
			{
				genObstacleObj(i-0.5f, 1f, player.position.z + spawnMarge);
			}
		}
	}

    /* Mur droit devans le joueur */
    void Template11()
    {
        int blockage = (int)Mathf.Floor(player.position.x);
        for (int i = blockage - 2; i <= blockage + 2; i++)
        {
            if (i > -7.5f && i < 7.5f) genObstacleObj(i - 0.5f, 1f, player.position.z + spawnMarge);
        }
    }

    /* Pavage aléatoire */
    void Template12()
    {
        for (int i = -7; i <= 8; i++)
        {
            int rand = Random.Range(1, 11);
            if (rand < 5)
            {
                genObstacleObj(i - 0.5f, 1f, player.position.z + spawnMarge);
                i+=2;
            }
        }
    }

    /* 3 x / */
    void Template13()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1) pos = 1;
        else pos = -1;

        genObstacleObj(-7.5f * pos, 1f, player.position.z + spawnMarge);
        genObstacleObj(-6.5f * pos, 1f, player.position.z + spawnMarge + 1);
        genObstacleObj(-5.5f * pos, 1f, player.position.z + spawnMarge + 2);

        genObstacleObj(-1.5f * pos, 1f, player.position.z + spawnMarge);
        genObstacleObj(-0.5f * pos, 1f, player.position.z + spawnMarge + 1);
        genObstacleObj(0.5f * pos, 1f, player.position.z + spawnMarge + 2);

        genObstacleObj(4.5f * pos, 1f, player.position.z + spawnMarge);
        genObstacleObj(5.5f * pos, 1f, player.position.z + spawnMarge + 1);
        genObstacleObj(6.5f * pos, 1f, player.position.z + spawnMarge + 2);
    }
}
