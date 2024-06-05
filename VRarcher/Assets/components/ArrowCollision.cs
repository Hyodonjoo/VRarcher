using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private Arrow parentArrow;

	public void Awake()
	{
        parentArrow = GetComponentInParent<Arrow>();
	}

	private void OnTriggerEnter(Collider other)
    {
        ArrowTarget target = other.gameObject.GetComponent<ArrowTarget>();
        if (target != null)
        {
            parentArrow.OnArrowHitTarget(target);
        }
    }
}
