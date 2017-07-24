package com.igorgrabarski;

import java.util.List;
import java.util.Map;

public class Main {

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

    public static void main(String[] args) {

        /*
         * USE BELOW METHODS AS EXAMPLES !!!
         */

        // For popular, top rated etc movies and tv
//        showListOfMovies();

//        showSingleMovie();

//        showSimilarOrRecommendedMovies();

//        getCreditsByMovieId();

//        getReviewsByMovieId();

//        getVideosByMovieId();

//        searchMovies();

//        searchPeople();

//        multiSearch();

//        getKeywords();

//        getPersonDetails();

//        getCreditsForPerson();

//        getTVSeason();

    }


    // **************************************************************************************************************
    public static void showListOfMovies() {

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

        System.out.println("Total pages: " + worker.getTotal_pages());
        System.out.println("Page: " + worker.getPage());
        System.out.println("Total results: " + worker.getTotal_results());
        System.out.println("***********************************************");
        System.out.println("***********************************************");
        System.out.println("***********************************************");

        // Movies and TV show have some different properties(title vs. name etc)
        for (Movie movie : movies) {
            // These properties are accessable from Popular, Top rated, upcoming and now playing movies
            System.out.println(movie.getVote_count());
            System.out.println(movie.getId());
            System.out.println(movie.isVideo());
            System.out.println(movie.getVote_average());
//            System.out.println(movie.getTitle());
            System.out.println(movie.getName());
            System.out.println(movie.getPopularity());
            System.out.println(movie.getPoster_path());
            System.out.println(movie.getOriginal_language());
            System.out.println(movie.getOriginal_title());
            System.out.println(movie.getBackdropPath());
            System.out.println(movie.isAdult());
            System.out.println(movie.getOverview());
            System.out.println(movie.getRelease_date());
            System.out.println("***********************************************");
        }
    }


    public static void showSingleMovie() {

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
        System.out.println("https://image.tmdb.org/t/p/w500" + movie.getBackdropPath());
        for (Genre genre : movie.getGenres()) {
            System.out.print(genre.getName());
            System.out.print(" , ");
        }
        System.out.println();
        System.out.println(movie.getHomepage());
        System.out.println(movie.getId());
        System.out.println(movie.getOriginal_language());
        System.out.println(movie.getOverview());
        System.out.println(movie.getPopularity());
        System.out.println("https://image.tmdb.org/t/p/w500" + movie.getPoster_path());
        for (ProductionCompany company : movie.getProduction_companies()) {
            System.out.print(company.getName());
            System.out.print(" , ");
        }
        System.out.println();
        System.out.println(movie.getStatus());
        System.out.println(movie.getVote_average());
        System.out.println(movie.getVote_count());


        // Specific for movies
//        System.out.println(movie.isAdult());
//        System.out.println(movie.getBudget());
//        System.out.println(movie.getImdb_id());
//        System.out.println(movie.getOriginal_title());
//        for(ProductionCountry country : movie.getProduction_countries()){
//            System.out.print(country.getName());
//            System.out.print(" , ");
//        }
//        System.out.println();
//        System.out.println(movie.getRelease_date());
//        System.out.println(movie.getRevenue());
//        System.out.println(movie.getRuntime());
//        for(SpokenLanguage language : movie.getSpoken_languages()){
//            System.out.print(language.getName());
//            System.out.print(" , ");
//        }
//        System.out.println();
//        System.out.println(movie.getTagline());
//        System.out.println(movie.getTitle());
//        System.out.println(movie.isVideo());


        // Specific for tv shows
        for (Crewman crewman : movie.getCreated_by()) {
            System.out.print(crewman.getName());
            System.out.print(" , ");
        }
        System.out.println();
        for (long runtime : movie.getEpisode_run_time()) {
            System.out.print(runtime);
            System.out.print(" , ");
        }
        System.out.println();
        System.out.println(movie.isIn_production());
        for (String language : movie.getLanguages()) {
            System.out.print(language);
            System.out.print(" , ");
        }
        System.out.println();
        System.out.println(movie.getLast_air_date());
        for (Network network : movie.getNetworks()) {
            System.out.print(network.getName());
            System.out.print(" , ");
        }
        System.out.println();
        System.out.println(movie.getNumber_of_episodes());
        System.out.println(movie.getNumber_of_seasons());
        for (String country : movie.getOrigin_country()) {
            System.out.print(country);
            System.out.print(" , ");
        }
        System.out.println();
        for (TvSeason season : movie.getSeasons()) {
            System.out.print(season.getSeason_number() + " - " + season.getAir_date());
            System.out.print(" , ");
        }
        System.out.println();
        System.out.println(movie.getType());
        System.out.println("************************************************************************");

    }


    public static void showSimilarOrRecommendedMovies() {

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

        System.out.println("Page: " + worker.getPage());
        System.out.println("Total results: " + worker.getTotal_results());
        System.out.println("Total pages: " + worker.getTotal_pages());
        System.out.println("*************************************************************************************");
        System.out.println("*************************************************************************************");
        System.out.println("*************************************************************************************");


        for (Movie movie : movies) {
            System.out.println("Title: " + movie.getTitle());
            System.out.println("Title for tv show : " + movie.getName());
            System.out.println("Backdrop path: " + movie.getBackdropPath());
            System.out.println("Budget: " + movie.getBudget() + "$");
            System.out.println("Homepage: " + movie.getHomepage());
            System.out.println("ID: " + movie.getId());
            System.out.println("IMDB ID: " + movie.getImdb_id());
            System.out.println("Original title: " + movie.getOriginal_title());
            System.out.println("Original title for tv show: " + movie.getOriginal_name());
            System.out.println("Overview: " + movie.getOverview());
            System.out.println("Popularity: " + movie.getPopularity());
            System.out.println("Vote average (1-10): " + movie.getVote_average());
            System.out.println("Vote count: " + movie.getVote_count());
            System.out.println("*************************************************************************************");
        }

    }

    public static void getCreditsByMovieId() {

        Worker worker = new Worker();

        // For movie credits use ItemType.MOVIE_CREDITS
//        Credit credit = worker.getCreditsForMovie(ItemType.MOVIE_CREDITS,297762);

        // For tv show credits use ItemType.TV_CREDITS
        Credit credit = worker.getCreditsForMovie(ItemType.TV_CREDITS, 57243);

        // Get cast - Actors
        List<Actor> cast = credit.getCast();
        for (Actor actor : cast) {
            System.out.println(actor.getCast_id());
            System.out.println(actor.getCharacter());
            System.out.println(actor.getCredit_id());
            System.out.println(actor.getGender());
            System.out.println(actor.getId());
            System.out.println(actor.getName());
            System.out.println(actor.getOrder());
            System.out.println("https://image.tmdb.org/t/p/w500" + actor.getProfile_path());
            System.out.println("*********************************************************");
        }

        System.out.println("*********************************************************");
        System.out.println("*********************************************************");
        System.out.println("*********************************************************");
        System.out.println("*********************************************************");
        System.out.println("*********************************************************");


        // Get crew - Directors, Producers, Photographers etc.
        List<Crewman> crew = credit.getCrew();
        for (Crewman crewman : crew) {
            System.out.println(crewman.getCredit_id());
            System.out.println(crewman.getDepartment());
            System.out.println(crewman.getGender());
            System.out.println(crewman.getId());
            System.out.println(crewman.getJob());
            System.out.println(crewman.getName());
            System.out.println("https://image.tmdb.org/t/p/w500" + crewman.getProfile_path());
            System.out.println("*********************************************************");
        }
    }





    public static void getReviewsByMovieId() {

        Worker worker = new Worker();

        // Only for Movies !!!!!!!!!!
        List<Review> reviews = worker.getMovieReviews(ItemType.MOVIE_REVIEWS, 297762);

        System.out.println("Page: " + worker.getPage());

        for (Review review : reviews) {
            System.out.println(review.getId());
            System.out.println(review.getAuthor());
            System.out.println(review.getContent());
            System.out.println(review.getUrl());
            System.out.println("*********************************************************************");
        }
    }

    public static void getVideosByMovieId() {


        Worker worker = new Worker();

        // For movie videos use ItemType.MOVIE_VIDEOS
//        List<Video> videos = worker.getMovieVideos(ItemType.MOVIE_VIDEOS,297762);

        // For tv shows videos use ItemType.TV_VIDEOS
        List<Video> videos = worker.getMovieVideos(ItemType.TV_VIDEOS, 57243);

        for (Video video : videos) {
            System.out.println(video.getId());
            System.out.println(video.getIso_639_1());
            System.out.println(video.getIso_3166_1());
            System.out.println(video.getKey());
            System.out.println(video.getName());
            System.out.println(video.getSite());
            System.out.println(video.getSize());
            System.out.println(video.getType());
            System.out.println("*********************************************************************");
        }
    }


    // Search for both movies and tv shows
    public static void searchMovies() {
        Worker worker = new Worker();

        // For movies use ItemType.MOVIE_SEARCH
        // Search with query, year, primary release year and set the desired page of results
//        List<Movie> movies = worker.searchForMovies(ItemType.MOVIE_SEARCH,"strong");

        // For movies use ItemType.MOVIE_SEARCH
        // Search with query, first air year and set the desired page of results
        List<Movie> movies = worker.searchForMovies(ItemType.TV_SEARCH, "strong");

        for (Movie movie : movies) {

            // For movies
            System.out.println(movie.getTitle());

            // For tv shows
//            System.out.println(movie.getName());
        }
    }

    // Search for people
    public static void searchPeople() {

        Worker worker = new Worker();

        List<Person> people = worker.searchForPeople("bruce");
        System.out.println("Total pages: " + worker.getTotal_pages());
        System.out.println("Total results: " + worker.getTotal_results());
        System.out.println("Page: " + worker.getPage());
        System.out.println("**************************************************************");

        for (Person person : people) {
            System.out.println(person.getName());

            // Movies / tv show person took a part in
            for (Movie movie : person.getKnown_for()) {
                System.out.println(movie.getMediaType() + " - " +
                        movie.getTitle() + " - " +
                        movie.getName() + " - " +
                        movie.getPoster_path());
            }
            System.out.println("**************************************************************");
        }
    }


    // Search combining people, movies and tv shows
    public static void multiSearch(){

        Worker worker = new Worker();

        List mixedResults = worker.searchMulti("Brad");

        // Identify people by class Person
        for(Object result : mixedResults){
            if(result instanceof Person){
                System.out.println("Person: " + ((Person) result).getName());
            }
            // Identify movie or tv by media_type
            else if(result instanceof Movie){
                if(((Movie) result).getMediaType().equals("movie")){
                    System.out.println("Movie: " + ((Movie) result).getTitle());
                }
                else {
                    System.out.println("TV: " + ((Movie) result).getName());
                }
            }
        }

    }


    public static void getKeywords(){

        Worker worker = new Worker();

        // Use MOVIE_KEYWORDS for movies
        List<Keyword> keywords = worker.getKeywordsForMovie(ItemType.MOVIE_KEYWORDS, 297762);


        // Use TV_KEYWORDS for tv shows
//        List<Keyword> keywords = worker.getKeywordsForMovie(ItemType.TV_KEYWORDS, 57243);

        for(Keyword keyword : keywords){
            System.out.println(keyword.getId() + " - " + keyword.getName());
        }
    }


    public static void getPersonDetails(){

        Worker worker = new Worker();

        Person person = worker.getPersonDetails(62);

        System.out.println(person.getName());
        for(String alias : person.getAlso_known_as()){
            System.out.print(alias);
            System.out.println(" , ");
        }
        System.out.println();

        System.out.println(person.getBiography());
        System.out.println(person.getBirthday());
        System.out.println(person.getDeathday());
        System.out.println(person.getGender());
        System.out.println(person.getHomepage());
        System.out.println(person.getId());
        System.out.println(person.getImdb_id());
        System.out.println(person.getPlace_of_birth());
        System.out.println(person.getPopularity());
        System.out.println(person.getProfile_path());
    }

    public static void getCreditsForPerson(){

        Worker worker = new Worker();

        // Use PERSON_CREDITS_MOVIE for movies actor had a part in
//        Map results = worker.getCreditsForPerson(ItemType.PERSON_CREDITS_MOVIE, 62);

        // Use PERSON_CREDITS_TV for tv shows actor had a part in
        Map results = worker.getCreditsForPerson(ItemType.PERSON_CREDITS_TV, 62);


        List<Movie> cast = (List<Movie>) results.get("cast");

        List<Movie> crew = (List<Movie>) results.get("crew");

        // In Movies
//        System.out.println("CAST IN MOVIES");
//        for(Movie movie : cast){
//            System.out.println(movie.getCharacter());
//            System.out.println(movie.getCreditId());
//            System.out.println(movie.getTitle());
//            System.out.println(movie.getPoster_path());
//            System.out.println(movie.getRelease_date());
//            System.out.println("*********************************************************************");
//        }
//
//        System.out.println("*********************************************************************");
//        System.out.println("*********************************************************************");
//        System.out.println("*********************************************************************");
//
//
//        System.out.println("CREW IN MOVIES");
//        for(Movie movie : crew){
//            System.out.println(movie.getCreditId());
//            System.out.println(movie.getDepartment());
//            System.out.println(movie.getJob());
//            System.out.println(movie.getPoster_path());
//            System.out.println(movie.getRelease_date());
//            System.out.println(movie.getTitle());
//            System.out.println("*********************************************************************");
//        }



        // On TV
        System.out.println("CAST ON TV");
        for(Movie movie : cast){
            System.out.println(movie.getCharacter());
            System.out.println(movie.getCreditId());
            System.out.println(movie.getName());
            System.out.println(movie.getPoster_path());
            System.out.println(movie.getFirst_air_date());
            System.out.println("*********************************************************************");
        }

        System.out.println("*********************************************************************");
        System.out.println("*********************************************************************");
        System.out.println("*********************************************************************");


        System.out.println("CREW ON TV");
        for(Movie movie : crew){
            System.out.println(movie.getCreditId());
            System.out.println(movie.getDepartment());
            System.out.println(movie.getJob());
            System.out.println(movie.getPoster_path());
            System.out.println(movie.getFirst_air_date());
            System.out.println(movie.getName());
            System.out.println("*********************************************************************");
        }
    }

    public static void getTVSeason(){
        Worker worker = new Worker();

        TvSeason season = worker.getSeasonInfo(57243,1);

        System.out.println("SEASON DATA");
        System.out.println(season.get_id());
        System.out.println(season.getAir_date());
        System.out.println(season.getId());
        System.out.println(season.getName());
        System.out.println(season.getOverview());
        System.out.println(season.getPoster_path());
        System.out.println(season.getSeason_number());
        System.out.println("*********************************************************************");
        System.out.println("*********************************************************************");
        System.out.println("*********************************************************************");

        System.out.println("EPISODES");

        List<TvEpisode> episodes = season.getEpisodes();
        for(TvEpisode episode : episodes){
            System.out.println(episode.getAir_date());
            System.out.println(episode.getEpisode_number());
            System.out.println(episode.getName());
            System.out.println(episode.getOverview());
            System.out.println(episode.getId());
            System.out.println(episode.getProduction_code());
            System.out.println(episode.getSeason_number());
            System.out.println(episode.getStill_path());
            System.out.println(episode.getVote_average());
            System.out.println(episode.getVote_count());

            // Get episode crew
            List<Crewman> crew = episode.getCrew();
            System.out.println("CREW:");
            for (Crewman crewman : crew) {
                System.out.print(crewman.getName() + " - " +
                crewman.getDepartment() + " - " +
                crewman.getJob() + " - " +
                crewman.getProfile_path());
                System.out.println();
                System.out.println("=============================");
            }

            System.out.println("--------------------------------------");

            // Get episode guest stars
            List<Actor> guestStars = episode.getGuest_stars();
            System.out.println("GUEST STARS:");
            for (Actor actor : guestStars) {
                System.out.print(actor.getName() + " - " +
                        actor.getCharacter() + " - " +
                        actor.getCredit_id() + " - " +
                        actor.getProfile_path());
                System.out.println();
                System.out.println("=============================");
            }


            System.out.println("*********************************************************************");
        }
    }

}
