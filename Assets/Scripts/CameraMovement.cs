using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public Transform player;
	public Vector3 offset;
	// Update is called once per frame
	void Update()
    {
		transform.position = player.position + offset; //Following the players transform coordinates with an offset in order to stay above the world whilst tracking the player
	}
}
