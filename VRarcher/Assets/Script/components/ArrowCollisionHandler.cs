using UnityEngine;

public class ArrowCollisionHandler : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		ArrowTarget target = collision.gameObject.GetComponent<ArrowTarget>();
		if (target != null)
		{
			if (ScoreManager.Instance != null)
			{
				ScoreManager.Instance.AddScore(target.scoreValue);
			}

			Destroy(target.gameObject);
			Destroy(gameObject);
		}
	}
}
