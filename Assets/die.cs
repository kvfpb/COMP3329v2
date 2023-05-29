using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
	// public GameObject destroyedVersion;	// Reference to the shattered version of the object

	// If the player clicks on the object
	public void Destroy ()
	// void OnMouseDown ()
	{
		// Spawn a shattered object
		// Instantiate(destroyedVersion, transform.position, transform.rotation);
		// Remove the current object
		Destroy(gameObject);
	}
}
