using UnityEngine;

public class ArrowTarget : MonoBehaviour
{
    public int scoreValue = 1;
    public bool destroyOnHit = true;

    private void OnCollisionEnter(Collision collision)
    {
        ArrowTarget target = collision.gameObject.GetComponent<ArrowTarget>();
        if (target != null)
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(target.scoreValue);
            }

            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}
