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
        private bool SuperMode;
		private int SuperModeTime;
		private bool Stopped; 
		private bool IsDead;
		private Direction _dir;
		private Direction _nextDir;
        private Animator _animator;
		private RouterController _router;
		private int _score;
		
        public void Start()
        {
            _dir = Direction.Right;
            _animator = GetComponent<Animator>();
			_nextDir = Direction.None;
        }

        public float Speed;
        public int SuperModeTimeDefault;
		public GUIText ScoreText;
		
		public void UpdateScore()
		{
		ScoreText.text = "Score: " + _score;	
		}
		public void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag == "Router")
			{
				var router = other.gameObject.GetComponent<RouterController>();
				if(router.CanMove(_nextDir))
				{
					ChangeDirection(_nextDir);
					_nextDir = Direction.None;
					return;
				}
				if(!router.CanMove(_dir))
				{
					Stopped = true;
					_router = router;
					return;
				}
			}
			if(other.tag == "Teleport")
			{
				var teleport = other.gameObject.GetComponent<TeleportController>();
				transform.position = new Vector3(teleport.Distination.x, teleport.Distination.y, 0);
			}
			if(other.tag == "Food")
			{
				other.gameObject.active = false;
				_score+=10;
			}
			if(other.tag == "SuperFood")
			{
				other.gameObject.active = false;
				SuperMode = true;
				SuperModeTime = SuperModeTimeDefault;
				var monsters =  GameObject.FindGameObjectsWithTag("Monster");
				foreach(var monster in monsters)
				{
					var monsterController = monster.GetComponent<MonsterController>();
					monsterController.SetSuperMode(true);
				}
				_score+=50;
			}
			if(other.tag == "Monster" && !IsDead)
			{
				if(SuperMode) 
				{
					other.gameObject.active = false;
					_score+=100;
				}
				else
				{
					_animator.SetTrigger("IsDead");
					IsDead = true;
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
			SuperModeTime--;
			if(SuperModeTime == 0)
			{
				SuperMode = false;
				var monsters =  GameObject.FindGameObjectsWithTag("Monster");
				foreach(var monster in monsters)
				{
					var monsterController = monster.GetComponent<MonsterController>();
					monsterController.SetSuperMode(false);
				}
			}
			if(IsDead)
			{
				return;
			}
			var inputDir = GetDirectionFromInput();
            if(Stopped)
			{
				if(!_router.CanMove(inputDir))
				{
					return;
				}
				ChangeDirection(inputDir);
				Stopped = false;
			}
			else if (inputDir != Direction.None && _dir != inputDir)
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
			UpdateScore();
        }
    }
}

//Проблемы:
//Нет счета, кол-ва жизней
//Монстр не возвращается в жилище
//Не сделано жилище
//Кривые роутеры, текстуры
//Не расставлена еда
//