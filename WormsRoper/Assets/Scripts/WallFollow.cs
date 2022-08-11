using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollow : MonoBehaviour
{
	public GameObject Player;

    private void FixedUpdate()
    {
		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, Player.transform.position.y, transform.position.z), 0.5f);
    }
}
