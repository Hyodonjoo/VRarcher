using UnityEngine;

public class Arrow : MonoBehaviour
{
	public float speed = 20f;
	public float lifetime = 10f;

	private Rigidbody rb;
	private float lifeTimer;

	public bool destroyOnHit = true;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		rb.velocity = transform.forward * speed;
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
