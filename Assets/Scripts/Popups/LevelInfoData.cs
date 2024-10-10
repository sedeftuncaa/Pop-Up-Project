namespace Popups
{
    public class LevelInfoData
    {
        //it can be specified

        public int LevelNumber { get; set; }

        public int Stars { get; set; }

        public int Score { get; set; }


        public LevelInfoData(int levelNumber,int stars,int score)
        {
            LevelNumber = levelNumber;
            Stars = stars;
            Score = score;
        }
    }
}