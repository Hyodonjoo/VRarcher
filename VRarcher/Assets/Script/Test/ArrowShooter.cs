using UnityEngine;
using System.Collections;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float shootInterval = 0.5f;

    private void Start()
    {
        // Start the coroutine to shoot arrows automatically
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
        Debug.Log($"instanting object: {arrowPrefab.name}");
        Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
    }
}
