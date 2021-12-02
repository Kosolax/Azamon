using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploTrap : MonoBehaviour
{
    private GameManager GameManager;

    public float ExplosiveForce;

    public float ExplosionRadius;

    public float UpwardModifier;

    public ParticleSystem Ps;

    public MeshCollider MeshCollider;

    public MeshRenderer MeshRenderer;

    public MeshCollider MeshColliderTrigger;

    public AudioSource ExplosionSound;

    private void Awake()
    {
        if (this.GameManager == null)
        {
            this.GameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GameManager.MissionLose();
            this.MeshCollider.enabled = false;
            this.MeshRenderer.enabled = false;
            this.MeshColliderTrigger.enabled = false;
            Ps.Play();
            this.ExplosionSound.Play();
            GameObject DeadBody = other.gameObject.GetComponent<Player>().DeadBody;
            if (DeadBody != null)
            {
                Rigidbody[] rigidbodies;
                rigidbodies = DeadBody.GetComponentsInChildren<Rigidbody>();

                foreach (var child in rigidbodies)
                {
                    child.AddExplosionForce(this.ExplosiveForce, this.gameObject.transform.parent.transform.position, this.ExplosionRadius, this.UpwardModifier, ForceMode.Impulse);
                }
            }
            Destroy(this.gameObject.transform.parent.gameObject, 3f);
        }
    }
}
