using UnityEngine;

namespace Project
{
    public class PS : Shell
    {
        protected override void OnUpdate()
        {
            transform.position += transform.forward * ShellData.MoveSpeed * Time.deltaTime;
        }
    }
}
