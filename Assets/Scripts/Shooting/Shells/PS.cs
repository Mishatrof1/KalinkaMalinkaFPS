using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(Rigidbody))]
    public class PS : Shell
    {
        [SerializeField]private Rigidbody Rb;
        protected override void OnInitialize()
        {
            Rb = GetComponent<Rigidbody>();
            Rb.velocity = transform.forward * ShellData.MoveSpeed;
        }

        protected override void OnFixedUpdate()
        {
            RaycastHit hit;
            Debug.DrawLine(transform.position, transform.TransformDirection(transform.forward), Color.red, 0.5f);
            if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit,0.5f))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")) return;

                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                return;

            Destroy(gameObject);
        }
    }
}
