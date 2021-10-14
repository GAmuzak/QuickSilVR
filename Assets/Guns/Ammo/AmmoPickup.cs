using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    GameObject[] ammoBlock;

    Ammo gun;

    private void Start()
    {
        ammoBlock = GameObject.FindGameObjectsWithTag("Ammo Block");
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Ammo>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, GetClosestEnemy(ammoBlock).position) < 2f)
        {
            gun.ammo = 14;
            Destroy(GetClosestEnemy(ammoBlock).gameObject);
        }
    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin.transform;
    }
}
