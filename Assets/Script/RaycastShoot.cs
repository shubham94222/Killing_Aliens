using UnityEngine;
using UnityEngine.UI;

public class RaycastShoot : MonoBehaviour
{
    public float range = 100f;
    public Image targetUI;
    public ParticleSystem hitImpact;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(10);

                    if (enemy.GetCurrentHealth() <= 0)
                    {
                        Destroy(enemy.gameObject);
                    }
                }

                targetUI.rectTransform.position = Camera.main.WorldToScreenPoint(hit.point);

                Instantiate(hitImpact, hit.point, Quaternion.identity);

                Destroy(hitImpact.gameObject, hitImpact.main.duration);
            }
        }
    }
}



