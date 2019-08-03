using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedMovement = 9f;
    [SerializeField] Transform leftButton;
    [SerializeField] Transform rightButton;


    private Vector2 _positionToMove;
    private float _defaultYPosition;

    // Start is called before the first frame update
    void Start()
    {
        _defaultYPosition = transform.position.y;
        _positionToMove = new Vector2( transform.position.x, _defaultYPosition );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _positionToMove, speedMovement * Time.deltaTime);
    }

    public void OnLeftButton()
    {
        if (GameManager.isPlayerReady)
        {
            _positionToMove.x = -1;
        }
    }

    public void OnRightButton()
    {
        if (GameManager.isPlayerReady)
        {
            _positionToMove.x = 1;
        }
    }
}
