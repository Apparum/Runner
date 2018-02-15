using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Player") gameManager.CompleteLevel();
	}
}
