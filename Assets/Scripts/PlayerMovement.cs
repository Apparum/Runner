using UnityEngine; 

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 8000f;
    public float sidewaysForce = 100f;
    private bool moveRight = false;
    private bool moveLeft = false;

    // Update is called once per frame
    void FixedUpdate () {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveRight) rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (moveLeft) rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            moveRight = true;
            moveLeft = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            moveLeft = true;
            moveRight = false;
        }
        else
        {
            moveLeft = false;
            moveRight = false;
        }
    }
}
