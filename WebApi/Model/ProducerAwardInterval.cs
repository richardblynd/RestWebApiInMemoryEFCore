namespace WebApi.Model
{
    public class ProducerAwardInterval
    {
        public string Producer { get; set; }

        public int Interval { get { return FollowingWin - PreviousWin; } }

        public int PreviousWin { get; set; }

        public int FollowingWin { get; set; }
    }
}
