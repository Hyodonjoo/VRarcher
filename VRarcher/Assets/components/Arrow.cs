using UnityEngine;

public class Arrow : MonoBehaviour
{
	public float lifetime = 10f;
	private float lifeTimer;

	public ArrowCollision arrowCollision;

	public void Start()
	{
		lifeTimer = lifetime;
	}

	public void Update()
	{
		lifeTimer -= Time.deltaTime;

		if (lifeTimer <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void OnArrowHitTarget(ArrowTarget target)
	{
		ScoreManager.Instance.AddScore(target);
	}
}
