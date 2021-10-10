using UnityEngine;
using System.Collections;

public class GunRecoil : MonoBehaviour
{
    public void Recoil()
    {
        GetComponent<Animator>().Play("Recoil", -1, 0f);
    }


}
