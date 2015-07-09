using System;

namespace MapReduceDojo.movie
{
    public class Movie
    {

        private readonly String _name;
        private readonly float _oneToTenRating;
        private readonly int _voteCount;
        private readonly int _releaseYear;

        public Movie(String name,
            float oneToTenRating,
            int voteCount,
            int releaseYear) {
            _name = name.Trim();
            _oneToTenRating = oneToTenRating;
            _voteCount = voteCount;
            _releaseYear = releaseYear;
            }

        public string Name
        {
            get { return _name; }
        }

        public float OneToTenRating
        {
            get { return _oneToTenRating; }
        }

        public int VoteCount
        {
            get { return _voteCount; }
        }

        public int ReleaseYear
        {
            get { return _releaseYear;  }
        }

        public override String ToString() {
            return String.Format("{0}|year={1}|rating={2}|votes={3}",
                _name, _releaseYear, _oneToTenRating, _voteCount);
        }

    }
}
