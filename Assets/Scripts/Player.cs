using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager _gameManager;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if ( _gameManager.playerHealth >= 1 )
            {
                _gameManager.playerHealth -= 1;
                _animator.SetTrigger("Hit");
            }
        }

        if ( collision.gameObject.tag.Equals("Coin") )
        {
            if ( GameManager.isPlayerReady )
            {
                AudioSource.PlayClipAtPoint(_gameManager.pointGainedSound, Camera.main.transform.position, 0.3f);
                _gameManager.playerScore += GameManager.pointPerCoin;

                Destroy( collision.gameObject );
            }
        }
    }
}
