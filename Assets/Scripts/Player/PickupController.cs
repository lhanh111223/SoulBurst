using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public GameObject[] Weapons;
    Vector3 offsetWeapon2Body;
    // Start is called before the first frame update
    void Start()
    {
        offsetWeapon2Body = new Vector3(0,-0.2f,0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPickupWeapon(int weapon)
    {
        // Delete current Weapon
        if (GetComponentInChildren<WeaponController>() != null)
        {
            Destroy(GetComponentInChildren<WeaponController>().gameObject);
        }

        // Set up offset 
        if (gameObject.name.Contains("PlayerKnight"))
        {
            offsetWeapon2Body = new Vector3(0, -0.6f, 0);
        }
        Instantiate(Weapons[weapon - 1], gameObject.transform.position + offsetWeapon2Body, Quaternion.identity, gameObject.transform);
    }
}
