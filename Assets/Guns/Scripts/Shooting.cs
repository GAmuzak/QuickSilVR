using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public GameObject cube;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);

            Ray();
        }
    }

    private void Ray()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPos.position, -transform.right, out hit))
        {
            Instantiate(cube, hit.point, Quaternion.identity);
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);


    }

}
