using Gameplay.Animals.Sheep;
using UnityEngine;

public class YardController : MonoBehaviour
{
    private SheepManager _sheepManager;

    public void Init(SheepManager sheepManager)
    {
        _sheepManager = sheepManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sheepManager.PlayerEnteredYard();
        }
    }
}
