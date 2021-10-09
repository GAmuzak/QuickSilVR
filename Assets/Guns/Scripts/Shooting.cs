using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    public void Shoot()
    {
        GameObject temp = Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
