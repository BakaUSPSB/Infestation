using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spraycan : MonoBehaviour


{
    private FPSController _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 600;
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_input.shoot){
            Shoot();
            _input.shoot = false;
        }
    }
    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab,bulletPoint.transform.position,transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed);
        Destroy(bullet,1);
    }
}
