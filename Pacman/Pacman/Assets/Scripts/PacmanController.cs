using UnityEngine;

namespace Assets.Scripts
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down,
        None
    }

    public class PacmanController : MonoBehaviour
    {
        private Direction _dir;
        private Animator _animator;

        public void Start()
        {
            _dir = Direction.Right;
            _animator = GetComponent<Animator>();
        }

        public float Speed;
        

        public void Update()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");


            var dir = Direction.None;
            if (horizontalInput == -1)
            {
                dir = Direction.Left;
            }
            if (verticalInput == 1)
            {
                dir = Direction.Up;
            }

            if (dir != Direction.None && _dir != dir)
            {
                _dir = dir;
                switch (dir)
                {
                    case Direction.Left:
                        _animator.SetTrigger("IsLeft");
                        break;
                    case Direction.Up:
                        _animator.SetTrigger("IsUp");
                        break;
                }
            }


            //transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, Speed * Time.deltaTime);
        }
    }
}
