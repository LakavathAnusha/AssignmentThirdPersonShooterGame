using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deva : MonoBehaviour
{
    public Transform Reticle;
    Transform crossTop;
    Transform crossBottom;
    Transform crossLeft;
    Transform crossRight;
    float reticleStartPoint;
    //[Range(10f, 25f)]
    public float size;
    public float restiSize;
    public float maxSize;
    public float speed;
    private float currentSize;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        reticleStartPoint = Random.Range(10f, 25f);
        crossTop = Reticle.FindChild("Cross/Top").transform;
        crossBottom = Reticle.FindChild("Cross/Bottom").transform;
        crossLeft = Reticle.FindChild("Cross/Left").transform;
        crossRight = Reticle.FindChild("Cross/Right").transform;

    }
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Reticle.transform.position = Vector3.Lerp(Reticle.transform.position, screenPosition, speed * Time.deltaTime);
       // Reticle.transform.position = Vector3.Lerp(Reticle.transform.position, maxSize, speed * Time.deltaTime);
    }
    public void ApplyScale(float scale)
    {
        crossTop.localPosition = new Vector3(0, reticleStartPoint + scale, 0);
        crossBottom.localPosition = new Vector3(0, -reticleStartPoint - scale, 0);
        crossLeft.localPosition = new Vector3(-reticleStartPoint - scale, 0, 0);
        crossRight.localPosition = new Vector3(reticleStartPoint + scale, 0, 0);
    }
}
