using UnityEngine;

public class FollowPlayer : MonoBehaviour{
    public Transform player;
	public Vector3 offset;

	// Update is called once per frame
	void Update () {
		if (gameObject.name == "Ground") transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
		else if (gameObject.name == "WallRight") transform.position = new Vector3(8.5f, 15f, player.position.z);
		else if (gameObject.name == "WallLeft") transform.position = new Vector3(-8.5f, 15f, player.position.z);
		else if (gameObject.name == "Light") transform.position = new Vector3(0f, 5f, player.position.z);
		else transform.position = player.position + offset;
	}
}
