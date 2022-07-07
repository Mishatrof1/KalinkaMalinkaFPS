using UnityEngine;

namespace Project
{
    public class PS : Shell
    {
        protected override void OnInitialize()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * ShellData.MoveSpeed;
        }

        protected override void OnFixedUpdate()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                return;

            Destroy(gameObject);
        }
    }
}
