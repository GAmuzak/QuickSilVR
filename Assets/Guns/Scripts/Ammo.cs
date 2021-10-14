using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Text ammoCount;

    [SerializeField]
    private float maxAmmo;
    
    private float ammo;

    private void Start()
    {
        ammo = maxAmmo;
        ammoCount.text = ammo.ToString();
    }

    public void Shoot()
    {
        if (ammo > 0)
            ammo--;

        ammoCount.text = ammo.ToString();
    }
}
