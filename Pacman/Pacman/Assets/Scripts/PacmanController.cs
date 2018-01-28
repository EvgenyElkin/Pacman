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
        private bool CanMove = true;
		private Direction _dir;
		private Direction _nextDir;
        private Animator _animator;

        public void Start()
        {
            _dir = Direction.Right;
            _animator = GetComponent<Animator>();
			_nextDir = Direction.None;
        }

        public float Speed;
        
		public void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag == "Router")
			{
				var router = other.gameObject.GetComponent<RouterController>();
				if(!router.CanMove(_dir))
				{
					CanMove = false;
				}
			}
		}
		private Direction GetReverseDirection(Direction dir)
		{
			switch(dir)
			{
				case Direction.Up:
					return Direction.Down;
				case Direction.Down:
					return Direction.Up;
				case Direction.Right:
					return Direction.Left;
				case Direction.Left:
					return Direction.Right;
				case Direction.None:
					return Direction.None;
			}
			return Direction.None;
		}
		private Direction GetDirectionFromInput()
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
			return dir;
		}
        
		public void ChangeDirection(Direction dir)
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
		
		public void Update()
        {
            if(!CanMove)
			{
				return;
			}
			var inputDir = GetDirectionFromInput();

            if (inputDir != Direction.None && _dir != inputDir)
            {
                var reverseDir = GetReverseDirection(_dir);
				if(inputDir == reverseDir)
				{
					ChangeDirection(inputDir);
				}
				else
				{
					_nextDir = inputDir;
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
