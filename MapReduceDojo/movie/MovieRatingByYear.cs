using System;
using System.Collections.Generic;

namespace MapReduceDojo.movie
{
    public class MovieRatingByYear : IMapperReducer<Movie> {

        public static readonly Char TAB_SEPARATOR = '\t';

        public void Map(IEmitter<Movie> movieEmitter, String data) {

            Movie movie = BuildMovie(data);
            // need movies mapped to their release date
        }

        public void Reduce(IEmitter<Movie> movieEmitter, String key, List<Movie> movies) {

            // Find the highest rated movie for the year
        }

        private Movie BuildMovie(String record) {
            String[] fields = record.Split(TAB_SEPARATOR);
            return new Movie(fields[2],
                Convert.ToSingle(fields[1]),
                Convert.ToInt32(fields[0]),
                Convert.ToInt32(fields[3]));
        }
    }
}
