using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
	public class MonsterController : MonoBehaviour 
	{
		private Direction _dir;
		private Animator _animator;
		private System.Random _rand;
		public float Speed;
			
		
		public void Start()
		{
			_dir = Direction.Right;
			_animator = GetComponent<Animator>();
			_rand = new System.Random();
		}
			
		private Direction GetNewDirection(RouterController router)
		{	
			var dirs = new List<Direction>();
			var allDirs = new[]
			{
				Direction.Left,
				Direction.Up,
				Direction.Right,
				Direction.Down
			};
			foreach(var dir in allDirs)
			{
				if(router.CanMove(dir))
				{
					dirs.Add(dir);
				}
			}
			return dirs[_rand.Next(dirs.Count)];
		}
		public void ChangeDirection(Direction dir)
		{
			 _dir = dir;
			switch (dir)
			{
				case Direction.Left:
					_animator.SetInteger("MoveDirection", 1);
					_animator.SetBool("SuperMode", false);
					break;
				case Direction.Up:
					_animator.SetInteger("MoveDirection", 2);
					_animator.SetBool("SuperMode", false);
					break;
				case Direction.Right:
					_animator.SetInteger("MoveDirection", 3);
					_animator.SetBool("SuperMode", false);
					break;
				case Direction.Down:
					_animator.SetInteger("MoveDirection", 4);
					_animator.SetBool("SuperMode", false);
					break;
					
			}
		}
		public void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag == "Router")
			{
				var router = other.gameObject.GetComponent<RouterController>();
				_dir = GetNewDirection(router);
				return;
			}
			if(other.tag == "Teleport")
			{
				var teleport = other.gameObject.GetComponent<TeleportController>();
				transform.position = new Vector3(teleport.Distination.x, teleport.Distination.y, 0);
			}
		}
		public void Update()
		{
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
