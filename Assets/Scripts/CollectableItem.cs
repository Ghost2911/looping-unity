using System.Collections;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    private Vector3 targetPosition;
    private BoxCollider _collider;
    public float lootSpeed = 5f;
    public float lootRange = 5f;

    void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.enabled = false;
        targetPosition = transform.position + RandomVector(-lootRange, lootRange);
        GetComponentInChildren<SpriteRenderer>().sprite = icon;
        StartCoroutine(LootMove());
    }

    IEnumerator LootMove()
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, lootSpeed * Time.deltaTime);
            yield return null;
        }
        _collider.enabled = true;
        yield return new WaitForSeconds(1f);
        GetComponentInChildren<Animator>().enabled = false;
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        return new Vector3(x, 0, y);
    }
}
