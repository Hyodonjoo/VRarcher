using UnityEngine;

public class Arrow : MonoBehaviour
{
	public float lifetime = 10f;
	private float lifeTimer;
	private bool hitTarget = false;

	public ArrowCollision arrowCollision;

	public void Start()
	{
		this.gameObject.SetActive(true);
		lifeTimer = lifetime;
		this.hitTarget = false;
	}

	public void Update()
	{
		if (!hitTarget)
		{
			lifeTimer -= Time.deltaTime;

			if (lifeTimer <= 0)
			{
				this.gameObject.SetActive(false);
			}
		}
	}

	public void OnArrowHitTarget(ArrowTarget target)
	{
		Debug.Log("hit a target");

		ScoreManager.Instance.AddScore(target);
		var rb = GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = true;
		}

		this.hitTarget = true;
	}
}
