using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ArrowTarget target = other.gameObject.GetComponent<ArrowTarget>();
        if (target != null)
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(target.scoreValue);
            }

            if (target.destroyOnHit)
            {
                Destroy(target.gameObject);
            }

            Arrow arrow = GetComponentInParent<Arrow>();
            if (arrow != null)
            {
                Destroy(arrow.gameObject);
            }
        }
    }
}
