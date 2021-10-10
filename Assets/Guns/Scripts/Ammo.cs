using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private float maxAmmo;

    [HideInInspector]
    public float ammo;

    public Text ammoCount;

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
