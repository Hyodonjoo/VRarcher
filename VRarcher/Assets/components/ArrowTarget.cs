using UnityEngine;

public class ArrowTarget : MonoBehaviour, IScore
{
    public int scoreValue = 1;
    public bool disableOnHit = true;

    public int GetScore()
	{
        return scoreValue;
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (this.disableOnHit)
		{
            this.gameObject.SetActive(false);
		}
    }
}
