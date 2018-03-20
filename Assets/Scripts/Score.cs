using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	public Text scoreText;
    private GameObject obstacle;
    private string score;
    public static int proxscore = 0;
    private float detectionRange = 2f;

    void Update () {
        obstacle = GameObject.Find("Obstacle(Clone)");
        if (obstacle != null && Vector3.Distance(player.transform.position, obstacle.transform.position) < detectionRange)
        {
            Debug.Log("a");
            proxscore += 1;
        }
        score = (player.position.z + proxscore).ToString("0");
        scoreText.text = score; 
	}
}
