using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting : MonoBehaviour
{
    public GameObject LaserBulletPrefab;
    public GameObject GunCylinder;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton))
        {
            GameObject LaserBullet = Instantiate(LaserBulletPrefab, GunCylinder.transform.position, Quaternion.identity);
          
        }
    }
}
