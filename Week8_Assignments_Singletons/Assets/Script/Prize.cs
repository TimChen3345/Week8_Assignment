using UnityEngine;

public class Prize : MonoBehaviour
{
    public int positionRange = 6;
    void OnCollisionEnter(Collision other)
    {
        GameManager.instance.score++;
        
        transform.position = new Vector3(
            Random.Range(-positionRange, positionRange),
            Random.Range(positionRange, positionRange));
    }
}    
