using Snake.Scripts.Enum;

namespace Snake.Scripts
{
    public class GameState
    {
        public int Rows { get; }
        public int Columns { get; }

        public GridValue[,] Grid {  get; }
        public Direction Dir { get; private set; }

        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        private readonly LinkedList<Position> snakePositions = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int r, int c)
        {
            Rows = r;
            Columns = c;

            Grid = new GridValue[Rows, Columns];
            Dir = Direction.Right;

            AddSnake();
            AddFood();
        }

        private void AddSnake()
        {
            int r = Rows / 2;

            for (int c = 1; c <= 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePositions.AddFirst(new Position(r, c));
            }
        }

        private IEnumerable<Position> EmptyPositions()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Grid[r, c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPositions());

            if(empty.Count == 0)
            {
                return;
            }

            Position pos = empty[random.Next(0, empty.Count)];
            Grid[pos.Row, pos.Column] = GridValue.Food;
        }
    }
}
