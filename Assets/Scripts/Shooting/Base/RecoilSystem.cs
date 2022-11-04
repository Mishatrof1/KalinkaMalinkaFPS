using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Project
{
    public class RecoilSystem : MonoBehaviour
    {
        public float recoilTime = 0.1f;
        public float recoilIntens = 10.0f;
        public float spreadAngle = 30.0f;
        public Transform Obj;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(Recoil());
            }
        }

        IEnumerator Recoil()
        {
            Vector3 vLook = Vector3.zero;

            Vector3 vSpread = Quaternion.AngleAxis(Random.Range(-spreadAngle, +spreadAngle), Obj.transform.forward) * Obj.transform.up;

            Vector3 vRight = Vector3.Cross(Obj.transform.forward, vSpread);

            float elapsedTime = 0.0f;

            while (true)
            {
                elapsedTime += Time.deltaTime;

                if (elapsedTime > recoilTime)
                {
                    if (elapsedTime > recoilTime * 2)
                    {
                        yield break;
                    }

                    vLook = Quaternion.AngleAxis(recoilIntens * Time.deltaTime, -vRight) * Obj.transform.forward;
                }
                else
                    vLook = Quaternion.AngleAxis(recoilIntens * Time.deltaTime, vRight) * Obj.transform.forward;

                Obj.transform.rotation = Quaternion.LookRotation(vLook);

                yield return null;
            }
        }
    }
}
