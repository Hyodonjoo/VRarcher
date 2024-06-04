using UnityEngine;
using System.Collections;

public class ArrowShooter : MonoBehaviour
{
	public GameObject arrowPrefab;
	public Transform arrowSpawnPoint;
	public float shootInterval = 0.5f;

	// ½î´Â ¹æÇâ
	public float rotationAngleX = 0f;
	public float rotationAngleY = 0f;
	public float rotationAngleZ = 0f;

	public float arrowSpeed = 20f;

	private void Start()
	{
		StartCoroutine(ShootArrows());
	}

	private IEnumerator ShootArrows()
	{
		while (true)
		{
			ShootArrow();
			yield return new WaitForSeconds(shootInterval);
		}
	}

	private void ShootArrow()
	{
		//Quaternion rotation = transform.rotation * Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ);
		GameObject arrowInstance = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowPrefab.transform.rotation);

		Rigidbody rb = arrowInstance.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.velocity = this.gameObject.transform.forward * arrowSpeed;
		}
	}
}
