using System;
using System.Collections;
using System.Collections.Generic;
using ya_move_it_parser_net;

namespace ya_move_it_parser_net
{
    public class Program
    {

        // YouTube prefix:
        // https://www.youtube.com/watch?v=

        // Image prefix:
        // https://image.tmdb.org/t/p/w500

        // Poster image sizes:
        // w92, w154, w185, w342, w500, w780, original

        // Backdrop image sizes:
        // w300, w780, w1280, original

        // Profile image sizes:
        // w45, w185, w632, original

        // Still path image sizes:
        // w92, w185, w300, original

        public static void Main(string[] args)
        {
			/*
        * USE BELOW METHODS AS EXAMPLES !!!
        */

			// For popular, top rated etc movies and tv
			//showListOfMovies();

			//showSingleMovie();

			//showSimilarOrRecommendedMovies();

		    //getCreditsByMovieId();

            //getCreditsForPerson();

			//getReviewsByMovieId();

			//getVideosByMovieId();

			//searchMovies();

			//searchPeople();

			//multiSearch();

			//getKeywords();

			//getPersonDetails();

			//getTVSeason();

	        //getMoviesByGenreId();

	        //getListOfGenres();
		}



        // **************************************************************************************************************
        public static void showListOfMovies()
        {

            Worker worker = new Worker();

            /*  Get list of movies / TV shows
              * Allowed types:
              * ItemType.MOVIE_NOW_PLAYING
              * ItemType.MOVIE_POPULAR
              * ItemType.MOVIE_TOP_RATED
              * ItemType.MOVIE_UPCOMING
              * ItemType.TV_AIRING_TODAY
              * ItemType.TV_LATEST
              * ItemType.TV_ON_THE_AIR
              * ItemType.TV_POPULAR
              * ItemType.TV_TOP_RATED   */

            /* Use default method - shows the first page
             * or
             * use method with page parameter for specific page */

            List<Movie> movies = worker.parseMovies(ItemType.TV_AIRING_TODAY);

            Console.WriteLine("Total pages: " + worker.getTotal_pages());
            Console.WriteLine("Page: " + worker.getPage());
            Console.WriteLine("Total results: " + worker.getTotal_results());
            Console.WriteLine("***********************************************");
            Console.WriteLine("***********************************************");
            Console.WriteLine("***********************************************");

            // Movies and TV show have some different properties(title vs. name etc)
            foreach (Movie movie in movies)
            {
                // These properties are accessable from Popular, Top rated, upcoming and now playing movies
                Console.WriteLine(movie.getVote_count());
                Console.WriteLine(movie.getId());
                Console.WriteLine(movie.isVideo());
                Console.WriteLine(movie.getVote_average());
                //            Console.WriteLine(movie.getTitle());
                Console.WriteLine(movie.getName());
                Console.WriteLine(movie.getPopularity());
                Console.WriteLine(movie.getPoster_path());
                Console.WriteLine(movie.getOriginal_language());
                Console.WriteLine(movie.getOriginal_title());
                Console.WriteLine(movie.getBackdropPath());
                Console.WriteLine(movie.IsAdult());
                Console.WriteLine(movie.getOverview());
                Console.WriteLine(movie.getRelease_date());
                Console.WriteLine("***********************************************");
            }
        }


        public static void showSingleMovie()
        {

            Worker worker = new Worker();

            /*  Get details for particular movie or tv show id
             * Allowed types:
             * ItemType.MOVIE
             * ItemType.TV  */

            // Check for movie - comment the tv specific below (lines 260 - 294) !!!
            //        Movie movie = worker.parseSingleMovie(ItemType.MOVIE, 297762);


            // Check for tv - comment the movie specific below (lines 237 - 256) !!!
            Movie movie = worker.parseSingleMovie(ItemType.TV, 57243);

            // Common for movies and tv shows
            Console.WriteLine("https://image.tmdb.org/t/p/w500" + movie.getBackdropPath());
            foreach (Genre genre in movie.getGenres())
            {
                Console.WriteLine(genre.getName());
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            Console.WriteLine(movie.getHomepage());
            Console.WriteLine(movie.getId());
            Console.WriteLine(movie.getOriginal_language());
            Console.WriteLine(movie.getOverview());
            Console.WriteLine(movie.getPopularity());
            Console.WriteLine("https://image.tmdb.org/t/p/w500" + movie.getPoster_path());
            foreach (ProductionCompany company in movie.getProduction_companies())
            {
                Console.WriteLine(company.getName());
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            Console.WriteLine(movie.getStatus());
            Console.WriteLine(movie.getVote_average());
            Console.WriteLine(movie.getVote_count());


            // Specific for movies
            //        Console.WriteLine(movie.isAdult());
            //        Console.WriteLine(movie.getBudget());
            //        Console.WriteLine(movie.getImdb_id());
            //        Console.WriteLine(movie.getOriginal_title());
            //        for(ProductionCountry country : movie.getProduction_countries()){
            //            System.out.print(country.getName());
            //            System.out.print(" , ");
            //        }
            //        Console.WriteLine();
            //        Console.WriteLine(movie.getRelease_date());
            //        Console.WriteLine(movie.getRevenue());
            //        Console.WriteLine(movie.getRuntime());
            //        for(SpokenLanguage language : movie.getSpoken_languages()){
            //            System.out.print(language.getName());
            //            System.out.print(" , ");
            //        }
            //        Console.WriteLine();
            //        Console.WriteLine(movie.getTagline());
            //        Console.WriteLine(movie.getTitle());
            //        Console.WriteLine(movie.isVideo());


            // Specific for tv shows
            foreach (Crewman crewman in movie.getCreated_by())
            {
                Console.WriteLine(crewman.getName());
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            foreach (long runtime in movie.getEpisode_run_time())
            {
                Console.WriteLine(runtime);
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            Console.WriteLine(movie.isIn_production());
            foreach (String language in movie.getLanguages())
            {
                Console.WriteLine(language);
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            Console.WriteLine(movie.getLast_air_date());
            foreach (Network network in movie.getNetworks())
            {
                Console.WriteLine(network.getName());
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            Console.WriteLine(movie.getNumber_of_episodes());
            Console.WriteLine(movie.getNumber_of_seasons());
            foreach (String country in movie.getOrigin_country())
            {
                Console.WriteLine(country);
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            foreach (TvSeason season in movie.getSeasons())
            {
                Console.WriteLine(season.getSeason_number() + " - " + season.getAir_date());
                Console.WriteLine(" , ");
            }
            Console.WriteLine();
            Console.WriteLine(movie.getType());
            Console.WriteLine("************************************************************************");

        }


        public static void showSimilarOrRecommendedMovies()
        {

            Worker worker = new Worker();

            // For similar movies use ItemType.MOVIES_SIMILAR
            //        List<Movie> movies = worker.getSimilarMovies(ItemType.MOVIES_SIMILAR,297762, 2);


            // For similar tv shows use ItemType.TVS_SIMILAR
            //        List<Movie> movies = worker.getSimilarMovies(ItemType.TVS_SIMILAR,57243);


            // For recommended movies use ItemType.MOVIES_RECOMMENDED
            //        List<Movie> movies = worker.getSimilarMovies(ItemType.MOVIES_RECOMMENDED,297762, 2);


            // For similar tv shows use ItemType.TVS_RECOMMENDED
            List<Movie> movies = worker.getSimilarMovies(ItemType.TVS_RECOMMENDED, 57243);

            // Don't forget to use properties specific for movie or tv show !!!

            Console.WriteLine("Page: " + worker.getPage());
            Console.WriteLine("Total results: " + worker.getTotal_results());
            Console.WriteLine("Total pages: " + worker.getTotal_pages());
            Console.WriteLine("*************************************************************************************");
            Console.WriteLine("*************************************************************************************");
            Console.WriteLine("*************************************************************************************");


            foreach (Movie movie in movies)
            {
                Console.WriteLine("Title: " + movie.getTitle());
                Console.WriteLine("Title for tv show : " + movie.getName());
                Console.WriteLine("Backdrop path: " + movie.getBackdropPath());
                Console.WriteLine("Budget: " + movie.getBudget() + "$");
                Console.WriteLine("Homepage: " + movie.getHomepage());
                Console.WriteLine("ID: " + movie.getId());
                Console.WriteLine("IMDB ID: " + movie.getImdb_id());
                Console.WriteLine("Original title: " + movie.getOriginal_title());
                Console.WriteLine("Original title for tv show: " + movie.getOriginal_name());
                Console.WriteLine("Overview: " + movie.getOverview());
                Console.WriteLine("Popularity: " + movie.getPopularity());
                Console.WriteLine("Vote average (1-10): " + movie.getVote_average());
                Console.WriteLine("Vote count: " + movie.getVote_count());
                Console.WriteLine("*************************************************************************************");
            }

        }

        public static void getCreditsByMovieId()
        {

            Worker worker = new Worker();

            // For movie credits use ItemType.MOVIE_CREDITS
            Credit credit = worker.getCreditsForMovie(ItemType.MOVIE_CREDITS,297762);

            // For tv show credits use ItemType.TV_CREDITS
            //Credit credit = worker.getCreditsForMovie(ItemType.TV_CREDITS, 57243);

            // Get cast - Actors
            List<Actor> cast = credit.getCast();
            foreach (Actor actor in cast)
            {
                Console.WriteLine(actor.getCharacter());
                Console.WriteLine(actor.getCredit_id());
                Console.WriteLine(actor.getGender());
                Console.WriteLine(actor.getId());
                Console.WriteLine(actor.getName());
                Console.WriteLine(actor.getOrder());
                Console.WriteLine("https://image.tmdb.org/t/p/w500" + actor.getProfile_path());
                Console.WriteLine("*********************************************************");
            }

            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");
            Console.WriteLine("*********************************************************");


            // Get crew - Directors, Producers, Photographers etc.
            List<Crewman> crew = credit.getCrew();
            foreach (Crewman crewman in crew)
            {
                Console.WriteLine(crewman.getCredit_id());
                Console.WriteLine(crewman.getDepartment());
                Console.WriteLine(crewman.getGender());
                Console.WriteLine(crewman.getId());
                Console.WriteLine(crewman.getJob());
                Console.WriteLine(crewman.getName());
                Console.WriteLine("https://image.tmdb.org/t/p/w500" + crewman.getProfile_path());
                Console.WriteLine("*********************************************************");
            }
        }





        public static void getReviewsByMovieId()
        {

            Worker worker = new Worker();

            // Only for Movies !!!!!!!!!!
            List<Review> reviews = worker.getMovieReviews(ItemType.MOVIE_REVIEWS, 297762);

            Console.WriteLine("Page: " + worker.getPage());

            foreach (Review review in reviews)
            {
                Console.WriteLine(review.getId());
                Console.WriteLine(review.getAuthor());
                Console.WriteLine(review.getContent());
                Console.WriteLine(review.getUrl());
                Console.WriteLine("*********************************************************************");
            }
        }

        public static void getVideosByMovieId()
        {


            Worker worker = new Worker();

            // For movie videos use ItemType.MOVIE_VIDEOS
            //        List<Video> videos = worker.getMovieVideos(ItemType.MOVIE_VIDEOS,297762);

            // For tv shows videos use ItemType.TV_VIDEOS
            List<Video> videos = worker.getMovieVideos(ItemType.TV_VIDEOS, 57243);

            foreach (Video video in videos)
            {
                Console.WriteLine(video.getId());
                Console.WriteLine(video.getIso_639_1());
                Console.WriteLine(video.getIso_3166_1());
                Console.WriteLine(video.getKey());
                Console.WriteLine(video.getName());
                Console.WriteLine(video.getSite());
                Console.WriteLine(video.getSize());
                Console.WriteLine(video.getType());
                Console.WriteLine("*********************************************************************");
            }
        }


        // Search for both movies and tv shows
        public static void searchMovies()
        {
            Worker worker = new Worker();

            // For movies use ItemType.MOVIE_SEARCH
            // Search with query, year, primary release year and set the desired page of results
            List<Movie> movies = worker.searchForMovies(ItemType.MOVIE_SEARCH,"strong");

            // For movies use ItemType.MOVIE_SEARCH
            // Search with query, first air year and set the desired page of results
            //List<Movie> movies = worker.searchForMovies(ItemType.TV_SEARCH, "bill");

            foreach (Movie movie in movies)
            {

                // For movies
                Console.WriteLine(movie.getTitle());

                // For tv shows
                //            Console.WriteLine(movie.getName());
            }
        }

        // Search for people
        public static void searchPeople()
        {

            Worker worker = new Worker();

            List<Person> people = worker.searchForPeople("bruce");
            Console.WriteLine("Total pages: " + worker.getTotal_pages());
            Console.WriteLine("Total results: " + worker.getTotal_results());
            Console.WriteLine("Page: " + worker.getPage());
            Console.WriteLine("**************************************************************");

            foreach (Person person in people)
            {
                Console.WriteLine(person.getName());

                // Movies / tv show person took a part in
                foreach (Movie movie in person.getKnown_for())
                {
                    Console.WriteLine(movie.getMediaType() + " - " +
                            movie.getTitle() + " - " +
                            movie.getName() + " - " +
                            movie.getPoster_path());
                }
                Console.WriteLine("**************************************************************");
            }
        }


        // Search combining people, movies and tv shows
        public static void multiSearch()
        {

            Worker worker = new Worker();

            ArrayList mixedResults = worker.searchMulti("Brad");

            // Identify people by class Person
            foreach (Object result in mixedResults)
            {
                if (result is ya_move_it_parser_net.Person)
                {
                    Console.WriteLine("Person: " + ((Person)result).getName());
                }
                // Identify movie or tv by media_type
                else if (result is ya_move_it_parser_net.Movie)
                {
                    if (((Movie)result).getMediaType().Equals("movie"))
                    {
                        Console.WriteLine("Movie: " + ((Movie)result).getTitle());
                    }
                    else
                    {
                        Console.WriteLine("TV: " + ((Movie)result).getName());
                    }
                }
            }

        }


        public static void getKeywords()
        {

            Worker worker = new Worker();

            // Use MOVIE_KEYWORDS for movies
            List<Keyword> keywords = worker.getKeywordsForMovie(ItemType.MOVIE_KEYWORDS, 297762);


            // Use TV_KEYWORDS for tv shows
            //        List<Keyword> keywords = worker.getKeywordsForMovie(ItemType.TV_KEYWORDS, 57243);

            foreach (Keyword keyword in keywords)
            {
                Console.WriteLine(keyword.getId() + " - " + keyword.getName());
            }
        }


        public static void getPersonDetails()
        {

            Worker worker = new Worker();

            Person person = worker.getPersonDetails(62);

            Console.WriteLine(person.getName());
            foreach (String alias in person.getAlso_known_as())
            {
                Console.WriteLine(alias);
                Console.WriteLine(" , ");
            }
            Console.WriteLine();

            Console.WriteLine(person.getBiography());
            Console.WriteLine(person.getBirthday());
            Console.WriteLine(person.getDeathday());
            Console.WriteLine(person.getGender());
            Console.WriteLine(person.getHomepage());
            Console.WriteLine(person.getId());
            Console.WriteLine(person.getImdb_id());
            Console.WriteLine(person.getPlace_of_birth());
            Console.WriteLine(person.getPopularity());
            Console.WriteLine(person.getProfile_path());
        }

        public static void getCreditsForPerson()
        {

            Worker worker = new Worker();

            // Use PERSON_CREDITS_MOVIE for movies actor had a part in
            //        Map results = worker.getCreditsForPerson(ItemType.PERSON_CREDITS_MOVIE, 62);

            // Use PERSON_CREDITS_TV for tv shows actor had a part in
            Dictionary<String, List<Movie>> results = worker.getCreditsForPerson(ItemType.PERSON_CREDITS_TV, 62);



            List<Movie> cast = (List<Movie>)results["cast"];

            List<Movie> crew = (List<Movie>)results["crew"];

            // In Movies
            //        Console.WriteLine("CAST IN MOVIES");
            //        for(Movie movie : cast){
            //            Console.WriteLine(movie.getCharacter());
            //            Console.WriteLine(movie.getCreditId());
            //            Console.WriteLine(movie.getTitle());
            //            Console.WriteLine(movie.getPoster_path());
            //            Console.WriteLine(movie.getRelease_date());
            //            Console.WriteLine("*********************************************************************");
            //        }
            //
            //        Console.WriteLine("*********************************************************************");
            //        Console.WriteLine("*********************************************************************");
            //        Console.WriteLine("*********************************************************************");
            //
            //
            //        Console.WriteLine("CREW IN MOVIES");
            //        for(Movie movie : crew){
            //            Console.WriteLine(movie.getCreditId());
            //            Console.WriteLine(movie.getDepartment());
            //            Console.WriteLine(movie.getJob());
            //            Console.WriteLine(movie.getPoster_path());
            //            Console.WriteLine(movie.getRelease_date());
            //            Console.WriteLine(movie.getTitle());
            //            Console.WriteLine("*********************************************************************");
            //        }



            // On TV
            Console.WriteLine("CAST ON TV");
            foreach (Movie movie in cast)
            {
                Console.WriteLine(movie.getCharacter());
                Console.WriteLine(movie.getCreditId());
                Console.WriteLine(movie.getName());
                Console.WriteLine(movie.getPoster_path());
                Console.WriteLine(movie.getFirst_air_date());
                Console.WriteLine("*********************************************************************");
            }

            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");


            Console.WriteLine("CREW ON TV");
            foreach (Movie movie in crew)
            {
                Console.WriteLine(movie.getCreditId());
                Console.WriteLine(movie.getDepartment());
                Console.WriteLine(movie.getJob());
                Console.WriteLine(movie.getPoster_path());
                Console.WriteLine(movie.getFirst_air_date());
                Console.WriteLine(movie.getName());
                Console.WriteLine("*********************************************************************");
            }
        }

        public static void getTVSeason()
        {
            Worker worker = new Worker();

            // Arguments are: tv_id and season_number
            TvSeason season = worker.getSeasonInfo(57243, 1);

            Console.WriteLine("SEASON DATA");
            Console.WriteLine(season.get_id());
            Console.WriteLine(season.getAir_date());
            Console.WriteLine(season.getId());
            Console.WriteLine(season.getName());
            Console.WriteLine(season.getOverview());
            Console.WriteLine(season.getPoster_path());
            Console.WriteLine(season.getSeason_number());
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("*********************************************************************");

            Console.WriteLine("EPISODES");

            List<TvEpisode> episodes = season.getEpisodes();
            foreach (TvEpisode episode in episodes)
            {
                Console.WriteLine(episode.getAir_date());
                Console.WriteLine(episode.getEpisode_number());
                Console.WriteLine(episode.getName());
                Console.WriteLine(episode.getOverview());
                Console.WriteLine(episode.getId());
                Console.WriteLine(episode.getProduction_code());
                Console.WriteLine(episode.getSeason_number());
                Console.WriteLine(episode.getStill_path());
                Console.WriteLine(episode.getVote_average());
                Console.WriteLine(episode.getVote_count());

                // Get episode crew
                List<Crewman> crew = episode.getCrew();
                Console.WriteLine("CREW:");
                foreach (Crewman crewman in crew)
                {
                    Console.WriteLine(crewman.getName() + " - " +
                crewman.getDepartment() + " - " +
                crewman.getJob() + " - " +
                crewman.getProfile_path());
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                }

                Console.WriteLine("--------------------------------------");

                // Get episode guest stars
                List<Actor> guestStars = episode.getGuest_stars();
                Console.WriteLine("GUEST STARS:");
                foreach (Actor actor in guestStars)
                {
                    Console.WriteLine(actor.getName() + " - " +
                        actor.getCharacter() + " - " +
                        actor.getCredit_id() + " - " +
                        actor.getProfile_path());
                    Console.WriteLine();
                    Console.WriteLine("=============================");
                }


                Console.WriteLine("*********************************************************************");
            }
        }

        public static void getMoviesByGenreId()
        {

            Worker worker = new Worker();

            List<Movie> movies = worker.getMoviesByGenre(28);

            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.getTitle());
                Console.WriteLine(movie.getOverview());
                Console.WriteLine(movie.getVote_average());
                Console.WriteLine("***********************************************");
            }
        }


        public static void getListOfGenres()
        {
            Worker worker = new Worker();
            List<Genre> genres = worker.getListOfGenres();

            foreach (Genre genre in genres)
            {
                Console.WriteLine(genre.getId() + " - " + genre.getName());
                Console.WriteLine();
            }

        }

    }


}