using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField] private float _range = 100.0f;
    [SerializeField] private float _damage = 10.0f;
    public Camera fpsCam;

    void Update(){
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, _range)){
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null){
                enemy.TakeDamage(_damage, hit);
            }
        }
    }
}
