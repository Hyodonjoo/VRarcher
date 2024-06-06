using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private Arrow_1 parentArrow;

	public void Awake()
	{
        parentArrow = GetComponentInParent<Arrow_1>();
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
