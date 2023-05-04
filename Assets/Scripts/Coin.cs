using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.instance.CoinUpdate(1);
        Destroy(gameObject);
    }
}
