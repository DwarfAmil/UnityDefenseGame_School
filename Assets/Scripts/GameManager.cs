using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int coin;

    [SerializeField] private TextMeshProUGUI _coinText;
    
    private void Awake()
    {
        instance = new GameManager();
    }

    private void Update()
    {
        _coinText.text = coin.ToString();
    }

    public void CoinUpdate(int num)
    {
        coin += num;
    }
}
