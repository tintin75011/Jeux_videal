using UnityEngine;

public class follow_camera : MonoBehaviour
{
	public GameObject player;
	public float time_Offset;
	public Vector3 pos_Offset;

	private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + pos_Offset, ref velocity, time_Offset); // SmoothDamp() allow to move an abject from left argument to right argument
    }
}
