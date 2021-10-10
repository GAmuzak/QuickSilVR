using UnityEngine;
using System.Collections;

public class GunRecoil : MonoBehaviour
{
    Vector3 newPos;
    Vector3 startPos;

    public float moveBack = .01f;
    public float speed = 10f;

    private void Start()
    {
        newPos = startPos = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, newPos, speed * Time.deltaTime);

        // if (Input.GetMouseButtonDown(0))
        // {
        //     newPos = startPos + Vector3.right * moveBack;
        //     StartCoroutine(Delay());
        // }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.1f);
        newPos = startPos;
    }

}
