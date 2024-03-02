using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public float fireDelta = 0.1f;
    public float animationDuration = 1f;

    public float nextFire = 0.1f;
    private GameObject newProjectile;
    private float myTime = 0.0f;

    public float shotDistance = 6f;

    void Update()
    {
        //Pew Pew
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

            //Start Repeat
            StartCoroutine(AnimateProjectile(newProjectile));

            nextFire = nextFire - myTime;
            myTime = 0.0f;
        }
    }

    // Animation
    IEnumerator AnimateProjectile(GameObject projectile)
    {
        float elapsedTime = 0;
        Vector3 startPosition = projectile.transform.position;
        Vector3 endPosition = startPosition + transform.forward * shotDistance;

        //Fire direction im looking

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            projectile.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / animationDuration));
            yield return null;
        }

        Destroy(projectile);
    }
}