using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    struct XPositionsScreen
    {
        public const float MinorXPos = -1;
        public const float MaxXPos = 1;
    }

    [SerializeField] List<GameObject> cars;

    private float _timer;
    private int _carToInstantiate = default(int);
    private int _maxRange;
    private List<int> pos;

    // Start is called before the first frame update
    void Start()
    {
        _timer = GameManager.delayTime;
        _maxRange = cars.Count;

        pos = new List<int>();
        pos.Add( (int)XPositionsScreen.MinorXPos );
        pos.Add( (int)XPositionsScreen.MaxXPos );
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        _carToInstantiate = Random.Range( 0, _maxRange );

        if ( _timer <= 0 && GameManager.isPlayerReady )
        {
            Instantiate( cars[_carToInstantiate], new Vector2( pos[Random.Range(0, 2) ], 
                transform.position.y ), transform.rotation );

            _timer = GameManager.delayTime;
        }
    }
}
