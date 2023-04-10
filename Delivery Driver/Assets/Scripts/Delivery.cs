using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer carSpriteRenderer;

    private void Start()
    {
        carSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage) {
            Debug.Log("Package picked up");

            hasPackage = true;
            carSpriteRenderer.color = hasPackageColor;

            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("CustomerChecker") && hasPackage)
        {
            Debug.Log("Package delivered");

            hasPackage = false;
            carSpriteRenderer.color = noPackageColor;
        }
    }
}
