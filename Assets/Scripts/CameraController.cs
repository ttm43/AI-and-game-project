using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    [Header("SmoothSpeed and Clamp size")]
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float minX, minY, maxX, maxY;

    [Header("Camera Shake")]
    private Vector3 shakeActive;
    private float shakeAmplify;

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 pos = target.position;
        pos.z = -10;
        transform.position = pos;
    }

    private void LateUpdate()
    {
      
    }

    private void CameraClamp()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY),
                                         -10);
    }

    //OPTIONAL_02 Camera Shake
    public void CameraShake(float _amount)
    {
        shakeAmplify = _amount;
    }

    //OPTIONAL_01 Camera Shake 
    public IEnumerator CameraShakeCo(float _maxTime, float _amount)
    {
        Vector3 originalPos = transform.localPosition;
        float shakeTime = 0.0f;

        while(shakeTime < _maxTime)
        {
            float x = Random.Range(-1f, 1f) * _amount;
            float y = Random.Range(-1f, 1f) * _amount;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            shakeTime += Time.deltaTime;

            yield return new WaitForSeconds(0f);
        }
    }
}
