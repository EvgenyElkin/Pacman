using UnityEngine;
namespace Assets.Scripts
{
	public class RouterController : MonoBehaviour 
	{
		public bool CanUp;
		public bool CanDown;
		public bool CanRight;
		public bool CanLeft;
		public bool CanMove(Direction dir)
		{
			switch(dir)
			{
				case Direction.Up:
				return CanUp;
				case Direction.Down:
				return CanDown;
				case Direction.Right:
				return CanRight;
				case Direction.Left:
				return CanLeft;
			}
			return false;
		}	
	}	
}
