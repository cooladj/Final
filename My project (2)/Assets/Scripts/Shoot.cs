using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int counter;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    [SerializeField] private Camera mainCamera;
    public GameObject[] shootLocations;

    private WaitForSeconds shootDuration = new WaitForSeconds(0.07f);
    private LineRenderer laserLine;
    private float nextFire;
    public GameObject AudioManagerGameObject;
    private AudioManger audioManager;

    private void Awake()
    {
        audioManager = AudioManagerGameObject.GetComponent<AudioManger>();
    }

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (counter >= shootLocations.Length)
        {
            counter = 0;
        }

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = mainCamera.nearClipPlane;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            RaycastHit hit;
            Vector3 shootPosition = shootLocations[counter].transform.position;

            laserLine.SetPosition(0, shootPosition);
            Ray ray = new Ray(shootPosition, worldPosition - shootPosition);

            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                if (hit.collider.gameObject.TryGetComponent<RockToPlayer>(out RockToPlayer rockToPlayer))
                {
                    Debug.Log("Asteroid hit");
                    audioManager.Play("AsteroidBreak");
                    rockToPlayer.BreakRock();
                }
            }
            else
            {
                laserLine.SetPosition(1, ray.origin + ray.direction * weaponRange);
            }

            counter++;
        }
    }

    private IEnumerator ShotEffect()
    {
        audioManager.Play("Shooting");
        laserLine.enabled = true;
        yield return shootDuration;
        laserLine.enabled = false;
    }
}
