using UnityEngine;

public class Arrow : MonoBehaviour
{
	public float lifetime = 10f;
	private float lifeTimer;

	private void Start()
	{
		lifeTimer = lifetime;
	}

	private void Update()
	{
		lifeTimer -= Time.deltaTime;

		if (lifeTimer <= 0)
		{
			Destroy(gameObject);
		}
	}
}
