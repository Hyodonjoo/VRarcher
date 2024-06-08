using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public Transform tip;

    private Rigidbody _rigidBody;
    private bool _inAir = false;
    private Vector3 _lastPosition = Vector3.zero;

    private ParticleSystem _particleSystem;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();


        PullInteraction.PullActionReleased += Release;        
        Stop();

    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= Release;
    }

    private void Release(float value)
    {
        PullInteraction.PullActionReleased -= Release;
        gameObject.transform.parent = null;
        _inAir = true;
        SetPhysics(true);

        Vector3 force = transform.forward * value * speed;
        _rigidBody.AddForce(force, ForceMode.Impulse);

        StartCoroutine(RotateWithVelocity());

        _lastPosition = tip.position;

        _particleSystem.Play();
        _trailRenderer.emitting = true;
    }

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();
        while (_inAir)
        {
            Quaternion newRotation = Quaternion.LookRotation(_rigidBody.velocity, transform.up);
            transform.rotation = newRotation;
            yield return null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.layer != 8)
        {
            if(collision.transform.TryGetComponent(out Rigidbody body) )
            {
                _rigidBody.interpolation = RigidbodyInterpolation.None;
                transform.parent = collision.transform;
                body.AddForce(_rigidBody.velocity, ForceMode.Impulse);
            }
            Stop();
        }
    }
    private void Stop()
    {
        _inAir = false;
        SetPhysics(false);

        _particleSystem.Stop();
        _trailRenderer.emitting = false;
    }
    private void SetPhysics(bool usePhyscis)
    {
        _rigidBody.useGravity = usePhyscis;
        _rigidBody.isKinematic = !usePhyscis;
    }


}
