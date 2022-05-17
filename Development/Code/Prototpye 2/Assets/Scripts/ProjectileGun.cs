using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileGun : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //gun stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //reference 
    public Camera fpsCamera;
    public Transform attackPoint;

    //bug fixing
    public bool allowInvoke = true;

    //animation
    public bool isFiring = false;
    public GameObject pistol;

    //text
    public GameObject reloadDone;

    public Button backButton;

    GameManager gameManager;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Start()
    {
        backButton = backButton.GetComponent<Button>();
        backButton.onClick.AddListener(onBackButtonClick);

        gameManager = GameObject.Find("GameManagerPersistent").GetComponent<GameManager>();
    }

    private void Update()
    {
        MyInput();
    }

    void onBackButtonClick()
    {
        bullet.SetActive(false);
    }

    private void MyInput()
    {
        if (gameManager.keyboard == true)
        {
            if (gameManager.mouse == true)
            {
                if (allowButtonHold) shooting = Input.GetButton("Fire1");
                else shooting = Input.GetButtonDown("Fire1");
            }
            else if (gameManager.mouse == false)
            {
                if (allowButtonHold) shooting = Input.GetKey(gameManager.shoot);
                else shooting = Input.GetKeyDown(gameManager.shoot);
            }
        }
        if (gameManager.controller == true )
        {
            if (allowButtonHold) shooting = Input.GetButton("Fire1");
            else shooting = Input.GetButtonDown("Fire1");
        }

        //reloading
        if (Input.GetButtonDown("Reload") && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        bullet.SetActive(true);
        if (isFiring == false)
        {
            StartCoroutine(FireThePistol());
        }

        readyToShoot = false;

        //find the exact hit position using a raycast
        Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //just a point far away from the player

        //calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCamera.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        //invoke resetShot function (if not already invoked)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        //allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
        if (reloading == false)
        {
            StartCoroutine(ReloadDoneText());
        }
    }
    
    IEnumerator ReloadDoneText()
    {
        reloadDone.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        reloadDone.SetActive(false);
    }

    IEnumerator FireThePistol()
    {
        isFiring = true;
        pistol.GetComponent<Animator>().Play("FirePistol");
        yield return new WaitForSeconds(0.25f);
        pistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }

}
