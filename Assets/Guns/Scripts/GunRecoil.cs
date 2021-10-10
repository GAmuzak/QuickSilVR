using UnityEngine;
using System.Collections;

public class GunRecoil : MonoBehaviour
{
    [SerializeField] private float moveBack = .01f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float muzzleImpactDelay;

    private Vector3 newPos;
    private Vector3 startPos;
    private float timeElapsed;

    private void Start()
    {
        newPos = startPos = transform.localPosition;
    }

    private void Update()
    {
        // transform.localPosition = Vector3.Slerp(transform.localPosition, newPos, speed * Time.deltaTime);
        //
        // // if (1>2)
        // // {
        // //     newPos = startPos + Vector3.right * moveBack;
        // //     StartCoroutine(Delay());
        // // }
    }

    public void Recoil()
    {
        newPos = startPos + Vector3.right * moveBack;
        StartCoroutine(Delay());
        StartCoroutine(RecoilSlerpCoroutine());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(muzzleImpactDelay);
        newPos = startPos;
    }

    private IEnumerator RecoilSlerpCoroutine()
    {
        timeElapsed = 0;
        float totalTime = speed * Time.deltaTime;
        if (timeElapsed < totalTime)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, newPos, speed * Time.deltaTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}
