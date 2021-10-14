using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    GameObject[] ammoBlock;

    Ammo gun;

    [SerializeField]
    private Material red;

    private void Start()
    {
        ammoBlock = GameObject.FindGameObjectsWithTag("Ammo Block");
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Ammo>();
    }

    private void Update()
    {
        if (ammoBlock.Length != 0 && GetClosestEnemy(ammoBlock) && gun.ammo < 14)
        {
            if (Vector3.Distance(transform.position, GetClosestEnemy(ammoBlock).position) < 2f && 
                GetClosestEnemy(ammoBlock).GetComponent<MeshRenderer>().material.color == Color.blue)
            {
                gun.ammo = 14;
                gun.ammoCount.text = gun.ammo.ToString();
                GetClosestEnemy(ammoBlock).GetComponent<MeshRenderer>().material = red;
            }
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
