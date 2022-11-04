using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Project
{
    public class RecoilSystem : MonoBehaviour
    {
        private Vector3 currentRotation;
        private Vector3 targerRotation;

        [SerializeField]
        private float recoinlX;
        [SerializeField]
        private float recoinlY;
        [SerializeField]
        private float recoinlZ;

        [SerializeField] private float snapiness;
        [SerializeField] private float returnSeed;


        [SerializeField] private CinemachineRecomposer CinemachineRecomposer;

        private void Start()
        {
            
        }

        private void Update()
        {
            targerRotation = Vector3.Lerp(targerRotation, Vector3.zero, returnSeed * Time.deltaTime);
            currentRotation = Vector3.Slerp(currentRotation, targerRotation, snapiness * Time.fixedDeltaTime);
            //transform.localRotation = Quaternion.Euler(currentRotation);
            CinemachineRecomposer.m_Pan = currentRotation.y;
            CinemachineRecomposer.m_Tilt = currentRotation.x;

            if (Input.GetMouseButton(0))
                RecoilFire();
        }

        public void RecoilFire()
        {
            targerRotation += new Vector3(recoinlX, Random.Range(-recoinlY, recoinlY), Random.Range(-recoinlZ, recoinlZ));
           
        }
    }
}
