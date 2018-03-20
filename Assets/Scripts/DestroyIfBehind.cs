using UnityEngine;
using System.Collections;

public class DestroyIfBehind : MonoBehaviour
{
	private void OnBecameInvisible()
	{
		Destroy(obj: gameObject);
	}
}
