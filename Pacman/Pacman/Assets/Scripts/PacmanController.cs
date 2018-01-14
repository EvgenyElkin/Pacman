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
			if (horizontalInput == 1)
            {
                dir = Direction.Right;
            }
            if (verticalInput == -1)
            {
                dir = Direction.Down;
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
					case Direction.Right:
                        _animator.SetTrigger("IsRight");
                        break;
					case Direction.Down:
                        _animator.SetTrigger("IsDown");
                        break;
                }
				
            }
			var directionVector = Vector3.zero;
            switch (_dir)
            {
                case Direction.Left:
                    directionVector = Vector3.left;
                    break;
                case Direction.Up:
                    directionVector = Vector3.up;
                    break;
                case Direction.Right:
                    directionVector = Vector3.right;
                    break;
                case Direction.Down:
                    directionVector = Vector3.down;
                    break;
            }
            transform.position = Vector3.MoveTowards(transform.position, transform.position + directionVector, Speed * Time.deltaTime);
        }
    }
}
