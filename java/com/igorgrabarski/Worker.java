package com.igorgrabarski;

import com.sun.istack.internal.Nullable;
import org.apache.http.client.fluent.Content;
import org.apache.http.client.fluent.Request;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;
import java.util.*;


/**
 * Created by igorgrabarski on 2017-06-09.
 */
public class Worker {

    // *******************************************
    // Write your API_KEY below after '=' sign
    private final String API_KEY = "api_key=";
    // *******************************************
    private final String BASE_URL = "https://api.themoviedb.org/3/";
    private final String FILE_SIZE = "w500";
    private final String YOUTUBE_PREFIX = "https://www.youtube.com/watch?v=";

    private List<Movie> movies;
    private List<Tv> tvs;

    private long page;
    private long total_results;
    private long total_pages;

    private String url;
    private long movieId;
    private long personId;
    private long seasonNumber;
    private String query;
    private String searchYear;
    private String searchPrimaryReleaseYear;
    private String firstAirDateYear;

    // ************************************ Getters and setters ************************************************************
    public long getPage() {
        return page;
    }

    public void setPage(long page) {
        this.page = page;
    }

    public long getTotal_results() {
        return total_results;
    }

    public void setTotal_results(long total_results) {
        this.total_results = total_results;
    }

    public long getTotal_pages() {
        return total_pages;
    }

    public void setTotal_pages(long total_pages) {
        this.total_pages = total_pages;
    }

    public long getMovieId() {
        return movieId;
    }

    public void setMovieId(long movieId) {
        this.movieId = movieId;
    }


// *********************************************************************************************************************

    /***
     * Method downloads JSON containing the requested data
     * @param itemType  One of types of movies or TV shows - enum ItemType
     * @param page  Number of page to show
     * @return String with JSON data to parse
     */
    private String downloadMovies(ItemType itemType, long page) {
        String type;

        switch (itemType) {
            case MOVIE_POPULAR: {
                type = "movie/popular";
                break;
            }
            case MOVIE_NOW_PLAYING: {
                type = "movie/now_playing";
                break;
            }
            case MOVIE_TOP_RATED: {
                type = "movie/top_rated";
                break;
            }
            case MOVIE_UPCOMING: {
                type = "movie/upcoming";
                break;
            }
            case MOVIES_RECOMMENDED: {
                type = "movie/" + movieId + "/recommendations";
                break;
            }
            case MOVIES_SIMILAR: {
                type = "movie/" + movieId + "/similar";
                break;
            }
            case MOVIE_REVIEWS: {
                type = "movie/" + movieId + "/reviews";
                break;
            }
            case MOVIE_VIDEOS: {
                type = "movie/" + movieId + "/videos";
                break;
            }
            case MOVIE_CREDITS: {
                type = "movie/" + movieId + "/credits";
                break;
            }
            case MOVIE_KEYWORDS: {
                type = "movie/" + movieId + "/keywords";
                break;
            }
            case TV_AIRING_TODAY: {
                type = "tv/airing_today";
                break;
            }
            case TV_LATEST: {
                type = "tv/latest";
                break;
            }
            case TV_ON_THE_AIR: {
                type = "tv/on_the_air";
                break;
            }
            case TV_POPULAR: {
                type = "tv/popular";
                break;
            }
            case TV_TOP_RATED: {
                type = "tv/top_rated";
                break;
            }
            case TVS_RECOMMENDED: {
                type = "tv/" + movieId + "/recommendations";
                break;
            }
            case TVS_SIMILAR: {
                type = "tv/" + movieId + "/similar";
                break;
            }
            case TV_SEASON: {
                type = "tv/" + movieId + "/season/" + seasonNumber;
                break;
            }
            case TV_KEYWORDS: {
                type = "tv/" + movieId + "/keywords";
                break;
            }
            case TV_REVIEWS: {
                type = "tv/" + movieId + "/reviews";
                break;
            }
            case TV_VIDEOS: {
                type = "tv/" + movieId + "/videos";
                break;
            }
            case TV_CREDITS: {
                type = "tv/" + movieId + "/credits";
                break;
            }
            case MOVIE_SEARCH: {
                type = "search/movie";
                break;
            }
            case TV_SEARCH: {
                type = "search/tv";
                break;
            }
            case PERSON_SEARCH: {
                type = "search/person";
                break;
            }
            case MULTI_SEARCH: {
                type = "search/multi";
                break;
            }
            case PERSON_DETAILS: {
                type = "person/" + personId;
                break;
            }
            case PERSON_CREDITS_MOVIE: {
                type = "person/" + personId + "/movie_credits";
                break;
            }
            case PERSON_CREDITS_TV: {
                type = "person/" + personId + "/tv_credits";
                break;
            }
            case PERSON_CREDITS_COMBINED: {
                type = "person/" + personId + "/combined_credits";
                break;
            }
            default: {
                type = "movie/popular";
                break;
            }
        }

        // *************************************************************************
        // URL of JSON file
        url = BASE_URL + type + "?" + API_KEY + "&language=en-US&page=" + page;
        // *************************************************************************


        // If we want to search, include search query and parameters in url
        if (query != null && query.length() > 0) {
            url += "&query=" + query;

            if (searchYear != null && searchYear.length() > 0) {
                url += "&year=" + searchYear;
            }

            if (searchPrimaryReleaseYear != null && searchPrimaryReleaseYear.length() > 0) {
                url += "&primary_release_year=" + searchPrimaryReleaseYear;
            }

            if (firstAirDateYear != null && firstAirDateYear.length() > 0) {
                url += "&first_air_date_year=" + firstAirDateYear;
            }
        }

        // Make query and parameters null
        this.query = null;
        this.searchYear = null;
        this.searchPrimaryReleaseYear = null;
        this.firstAirDateYear = null;


        try {
            Content content = Request.Get(url).execute().returnContent();
            return content.asString();

        } catch (IOException e) {
            e.printStackTrace();
            return e.getMessage();
        }


    }

// *********************************************************************************************************************

    /***
     * Method downloads JSON containing the requested data for 1st page
     * @param itemType  One of types of movies or TV shows - enum ItemType
     * @return String with JSON data to parse
     */
    private String downloadMovies(ItemType itemType) {
        return downloadMovies(itemType, 1);
    }

// *********************************************************************************************************************

    /***
     * Download json for given movie id
     * @param itemType    One of ItemType items defining the movie type
     * @param id    Movie id as long
     * @return JSON as String
     */
    private String downloadSingleMovie(ItemType itemType, long id) {
        String url;
        if (itemType.equals(ItemType.MOVIE)) {
            url = BASE_URL + "movie/" + String.valueOf(id) + "?" + API_KEY + "&language=en-US";
        } else if (itemType.equals(ItemType.TV)) {
            url = BASE_URL + "tv/" + String.valueOf(id) + "?" + API_KEY + "&language=en-US";
        } else {
            throw new
                    IllegalArgumentException("Wrong ItemType parameter. PLease use either ItemType.MOVIE or ItemType.TV");
        }

        try {
            Content content = Request.Get(url).execute().returnContent();
            return content.asString();

        } catch (Exception e) {
            e.printStackTrace();
            return e.getMessage();
        }
    }


// *********************************************************************************************************************

    /***
     *  Parses movies data for given type and given page
     * @param itemType  One of ItemType items defining the movie type
     * @param page long representing the page number
     * @return list of movies
     */
    public List parseMovies(ItemType itemType, long page) {

        JSONObject initialObject = new JSONObject(downloadMovies(itemType, page));
        this.page = initialObject.optLong("page");
        this.total_results = initialObject.optLong("total_results");
        this.total_pages = initialObject.optLong("total_pages");
        JSONArray results = initialObject.getJSONArray("results");
        movies = new ArrayList<>();
        Movie movie;

        for (int i = 0; i < results.length(); i++) {
            movie = new Movie();

            // Properties common for both movies and tv shows
            movie.setBackdropPath(results.getJSONObject(i).optString("backdrop_path"));
            movie.setId(results.getJSONObject(i).optLong("id"));
            movie.setOriginal_language(results.getJSONObject(i).optString("original_language"));
            movie.setOverview(results.getJSONObject(i).optString("overview"));
            movie.setPopularity(results.getJSONObject(i).optDouble("popularity"));
            movie.setPoster_path(results.getJSONObject(i).optString("poster_path"));
            movie.setVote_average(results.getJSONObject(i).optDouble("vote_average"));
            movie.setVote_count(results.getJSONObject(i).optLong("vote_count"));


            // Parses properties for movies only!
            if (itemType.equals(ItemType.MOVIE_POPULAR) ||
                    itemType.equals(ItemType.MOVIE_TOP_RATED) ||
                    itemType.equals(ItemType.MOVIE_NOW_PLAYING) ||
                    itemType.equals(ItemType.MOVIE_UPCOMING) ||
                    itemType.equals(ItemType.MOVIES_SIMILAR) ||
                    itemType.equals(ItemType.MOVIES_RECOMMENDED) ||
                    itemType.equals(ItemType.MOVIE_SEARCH)) {
                movie.setVideo(results.getJSONObject(i).optBoolean("video"));
                movie.setTitle(results.getJSONObject(i).optString("title"));
                movie.setOriginal_title(results.getJSONObject(i).optString("original_title"));
                movie.setAdult(results.getJSONObject(i).optBoolean("adult"));
                movie.setRelease_date(results.getJSONObject(i).optString("release_date"));
            }
            // Parses properties for tv shows only!
            else if (itemType.equals(ItemType.TV_AIRING_TODAY) ||
                    itemType.equals(ItemType.TV_LATEST) ||
                    itemType.equals(ItemType.TV_POPULAR) ||
                    itemType.equals(ItemType.TV_ON_THE_AIR) ||
                    itemType.equals(ItemType.TV_TOP_RATED) ||
                    itemType.equals(ItemType.TVS_SIMILAR) ||
                    itemType.equals(ItemType.TVS_RECOMMENDED) ||
                    itemType.equals(ItemType.TV_SEARCH)) {
                movie.setFirst_air_date(results.getJSONObject(i).optString("first_air_date"));
                movie.setName(results.getJSONObject(i).optString("name"));
                movie.setOriginal_name(results.getJSONObject(i).optString("original_name"));

            } else {
                throw new IllegalArgumentException("Wrong ItemType argument");
            }


            movies.add(movie);
        }

        return movies;
    }


// *********************************************************************************************************************

    /***
     * Parses movies data for given type and 1st page
     * @param itemType  One of ItemType items defining the movie type
     * @return list of movies
     */
    public List parseMovies(ItemType itemType) {
        return parseMovies(itemType, 1);
    }


// *********************************************************************************************************************

    /***
     * Parses json for single movie
     * @param itemType  One of ItemType items defining the movie type
     * @param id  Movie id
     * @return Movie object with details
     */
    public Movie parseSingleMovie(ItemType itemType, long id) {

        Movie movie = new Movie();
        JSONObject initialObject = new JSONObject(downloadSingleMovie(itemType, id));

        // ********************************************************************************************************
        // ********************* Properties common for both movies and tv shows ***********************************
        // ********************************************************************************************************
        movie.setBackdropPath(initialObject.optString("backdrop_path"));
        movie.setHomepage(initialObject.optString("homepage"));
        movie.setId(initialObject.optLong("id"));
        movie.setOriginal_language(initialObject.optString("original_language"));
        movie.setOverview(initialObject.optString("overview"));
        movie.setPopularity(initialObject.optDouble("popularity"));
        movie.setPoster_path(initialObject.optString("poster_path"));
        movie.setStatus(initialObject.optString("status"));
        movie.setVote_average(initialObject.optDouble("vote_average"));
        movie.setVote_count(initialObject.optLong("vote_count"));

        // ************************** Set genres ***************************
        JSONArray genresArray = initialObject.optJSONArray("genres");
        List<Genre> genres = new ArrayList<>();
        Genre genre;
        for (int j = 0; j < genresArray.length(); j++) {
            genre = new Genre();
            genre.setId(genresArray.getJSONObject(j).optLong("id"));
            genre.setName(genresArray.getJSONObject(j).optString("name"));
            genres.add(genre);
        }
        movie.setGenres(genres);


        // ************************** Set production companies ***************************
        JSONArray companiesArray = initialObject.optJSONArray("production_companies");
        List<ProductionCompany> companies = new ArrayList<>();
        ProductionCompany company;
        for (int j = 0; j < companiesArray.length(); j++) {
            company = new ProductionCompany();
            company.setId(companiesArray.getJSONObject(j).optLong("id"));
            company.setName(companiesArray.getJSONObject(j).optString("name"));
            companies.add(company);
        }
        movie.setProduction_companies(companies);


        // ********************************************************************************************************
        // ***************************** Parses properties for movies only! ***************************************
        // ********************************************************************************************************
        if (itemType.equals(ItemType.MOVIE)) {
            movie.setAdult(initialObject.optBoolean("adult"));
            movie.setCollectionId(initialObject.optLong("belongs_to_collection"));
            movie.setBudget(initialObject.optLong("budget"));
            movie.setImdb_id(initialObject.optString("imdb_id"));
            movie.setOriginal_title(initialObject.optString("original_title"));

            // ************************** Set production countries ***************************
            JSONArray countriesArray = initialObject.optJSONArray("production_countries");
            List<ProductionCountry> countries = new ArrayList<>();
            ProductionCountry country;
            for (int j = 0; j < countriesArray.length(); j++) {
                country = new ProductionCountry();
                country.setIso_3166_1(countriesArray.getJSONObject(j).optString("iso_3166_1"));
                country.setName(countriesArray.getJSONObject(j).optString("name"));
                countries.add(country);
            }
            movie.setProduction_countries(countries);
            movie.setRelease_date(initialObject.optString("release_date"));
            movie.setRevenue(initialObject.optLong("revenue"));
            movie.setRuntime(initialObject.optLong("runtime"));

            // ************************** Set spoken languages ***************************
            JSONArray languagesArray = initialObject.optJSONArray("spoken_languages");
            List<SpokenLanguage> languages = new ArrayList<>();
            SpokenLanguage language;
            for (int j = 0; j < languagesArray.length(); j++) {
                language = new SpokenLanguage();
                language.setIso_639_1(languagesArray.getJSONObject(j).optString("iso_639_1"));
                language.setName(languagesArray.getJSONObject(j).optString("name"));
                languages.add(language);
            }
            movie.setSpoken_languages(languages);
            movie.setTagline(initialObject.optString("tagline"));
            movie.setTitle(initialObject.optString("title"));
            movie.setVideo(initialObject.optBoolean("video"));

        }
        // ********************************************************************************************************
        // ************************* Parses properties for tv shows only! *****************************************
        // ********************************************************************************************************
        else if (itemType.equals(ItemType.TV)) {

            // ************************** Set created by ***************************
            JSONArray createdByArray = initialObject.optJSONArray("created_by");
            List<Crewman> crew = new ArrayList<>();
            Crewman crewman;
            for (int i = 0; i < createdByArray.length(); i++) {
                crewman = new Crewman();
                crewman.setId(createdByArray.optJSONObject(i).optLong("id"));
                crewman.setName(createdByArray.optJSONObject(i).optString("name"));
                crewman.setGender(createdByArray.optJSONObject(i).optInt("gender"));
                crewman.setProfile_path(createdByArray.optJSONObject(i).optString("profile_path"));
                crew.add(crewman);
            }
            movie.setCreated_by(crew);

            // ************************** Set episode runtime ***************************
            JSONArray episodesArray = initialObject.optJSONArray("episode_run_time");
            List<Long> episodesRuntime = new ArrayList<>();
            for (int i = 0; i < episodesArray.length(); i++) {
                episodesRuntime.add(episodesArray.optLong(i));
            }
            movie.setEpisode_run_time(episodesRuntime);

            movie.setIn_production(initialObject.optBoolean("in_production"));


            // ************************** Set languages ***************************
            JSONArray languagesArray = initialObject.optJSONArray("languages");
            List<String> languages = new ArrayList<>();
            for (int i = 0; i < languagesArray.length(); i++) {
                languages.add(languagesArray.optString(i));
            }
            movie.setLanguages(languages);

            movie.setLast_air_date(initialObject.optString("last_air_date"));


            // ************************** Set networks ***************************
            JSONArray networksArray = initialObject.optJSONArray("networks");
            List<Network> networks = new ArrayList<>();
            Network network;
            for (int i = 0; i < networksArray.length(); i++) {
                network = new Network();
                network.setId(createdByArray.optJSONObject(i).optLong("id"));
                network.setName(createdByArray.optJSONObject(i).optString("name"));
                networks.add(network);
            }
            movie.setNetworks(networks);


            movie.setNumber_of_episodes(initialObject.optLong("number_of_episodes"));
            movie.setNumber_of_seasons(initialObject.optLong("number_of_seasons"));

            // ************************** Set origin countries ***************************
            JSONArray countriesArray = initialObject.optJSONArray("origin_country");
            List<String> countries = new ArrayList<>();
            for (int i = 0; i < languagesArray.length(); i++) {
                countries.add(countriesArray.optString(i));
            }
            movie.setOrigin_country(countries);


            // ************************** Set seasons ***************************
            JSONArray seasonsArray = initialObject.optJSONArray("seasons");
            List<TvSeason> seasons = new ArrayList<>();
            TvSeason season;
            for (int i = 0; i < seasonsArray.length(); i++) {
                season = new TvSeason();
                season.setAir_date(seasonsArray.optJSONObject(i).optString("air_date"));
                season.setEpisode_count(seasonsArray.optJSONObject(i).optLong("episode_count"));
                season.setId(seasonsArray.optJSONObject(i).optLong("id"));
                season.setPoster_path(seasonsArray.optJSONObject(i).optString("poster_path"));
                season.setSeason_number(seasonsArray.optJSONObject(i).optLong("season_number"));
                seasons.add(season);
            }
            movie.setSeasons(seasons);

            movie.setType(initialObject.optString("type"));


        } else {
            throw new IllegalArgumentException("Wrong ItemType argument");
        }

        return movie;
    }


// *********************************************************************************************************************

    /***
     * Retrieves list of recommended movies for given movie id and page number
     * @param itemType    MOVIES_SIMILAR or TVS_SIMILAR
     * @param id    Movie id as long
     * @param page  Page number as long
     * @return List of Movie objects
     */
    public List<Movie> getRecommendedMovies(ItemType itemType, long id, long page) {
        this.movieId = id;
        return parseMovies(itemType, page);
    }


// *********************************************************************************************************************

    /***
     * Retrieves list of recommended movies for given movie id and first page
     * @param itemType    MOVIES_SIMILAR or TVS_SIMILAR
     * @param id    Movie id as long
     * @return List of Movie objects
     */
    public List<Movie> getRecommendedMovies(ItemType itemType, long id) {
        this.movieId = id;
        return parseMovies(itemType);
    }


// *********************************************************************************************************************

    /***
     * Retrieves list of similar movies for given movie id and given page number
     * @param itemType    MOVIES_SIMILAR or TVS_SIMILAR
     * @param id    Movie id as long
     * @param page  Page number as long
     * @return List of Movie objects
     */
    public List<Movie> getSimilarMovies(ItemType itemType, long id, long page) {
        this.movieId = id;

        return parseMovies(itemType, page);
    }


// *********************************************************************************************************************

    /***
     * Retrieves list of similar movies for given movie id and first page
     * @param itemType    MOVIES_SIMILAR or TVS_SIMILAR
     * @param id    Movie id as long
     * @return List of Movie objects
     */
    public List<Movie> getSimilarMovies(ItemType itemType, long id) {
        this.movieId = id;
        return parseMovies(itemType);
    }


// *********************************************************************************************************************

    /***
     * Retrieves list of reviews for given movie id and first page
     * @param id    Movie id as long
     * @return List of Review objects
     */
    public List<Review> getMovieReviews(ItemType itemType, long id) {
        this.movieId = id;
        List<Review> reviews = new ArrayList<>();
        JSONObject initialObject = new JSONObject(downloadMovies(itemType));
        this.page = initialObject.optLong("page");
        JSONArray reviewsArray = initialObject.optJSONArray("results");

        Review review;

        for (int i = 0; i < reviewsArray.length(); i++) {
            review = new Review();
            review.setId(reviewsArray.optJSONObject(i).optString("id"));
            review.setAuthor(reviewsArray.optJSONObject(i).optString("author"));
            review.setContent(reviewsArray.optJSONObject(i).optString("content"));
            review.setUrl(reviewsArray.optJSONObject(i).optString("url"));
            reviews.add(review);
        }
        return reviews;
    }


// *********************************************************************************************************************

    /***
     * Retrieves list of videos for given movie id and first page
     * @param id    Movie id as long
     * @return List of Video objects
     */
    public List<Video> getMovieVideos(ItemType itemType, long id) {
        this.movieId = id;
        List<Video> videos = new ArrayList<>();
        JSONObject initialObject = new JSONObject(downloadMovies(itemType));
        JSONArray videosArray = initialObject.optJSONArray("results");

        Video video;

        for (int i = 0; i < videosArray.length(); i++) {
            video = new Video();
            video.setId(videosArray.optJSONObject(i).optString("id"));
            video.setIso_639_1(videosArray.optJSONObject(i).optString("iso_639_1"));
            video.setIso_3166_1(videosArray.optJSONObject(i).optString("iso_3166_1"));
            video.setName(videosArray.optJSONObject(i).optString("name"));
            video.setKey(YOUTUBE_PREFIX + videosArray.optJSONObject(i).optString("key"));
            video.setSite(videosArray.optJSONObject(i).optString("site"));
            video.setSize(videosArray.optJSONObject(i).optLong("size"));
            video.setType(videosArray.optJSONObject(i).optString("type"));
            videos.add(video);
        }
        return videos;
    }


// *********************************************************************************************************************

    /***
     * Retrieves Credit object containing crew and cast for the movie
     * @param itemType    MOVIE_CREDITS or TV_CREDITS
     * @param id    Movie id as long
     * @return Credit object
     */
    public Credit getCreditsForMovie(ItemType itemType, long id) {

        this.movieId = id;
        Credit credit = new Credit();
        List<Actor> cast = new ArrayList<>();
        List<Crewman> crew = new ArrayList<>();

        JSONObject initialObject = new JSONObject(downloadMovies(itemType));
        JSONArray castArray = initialObject.optJSONArray("cast");
        JSONArray crewArray = initialObject.optJSONArray("crew");
        Actor actor;
        Crewman crewman;

        // ******************************** Get cast *******************************************
        for (int i = 0; i < castArray.length(); i++) {
            actor = new Actor();
            actor.setCast_id(castArray.optJSONObject(i).optLong("cast_id"));
            actor.setCharacter(castArray.optJSONObject(i).optString("character"));
            actor.setCredit_id(castArray.optJSONObject(i).optString("credit_id"));
            actor.setGender(castArray.optJSONObject(i).optInt("gender"));
            actor.setId(castArray.optJSONObject(i).optLong("id"));
            actor.setName(castArray.optJSONObject(i).optString("name"));
            actor.setOrder(castArray.optJSONObject(i).optLong("order"));
            actor.setProfile_path(castArray.optJSONObject(i).optString("profile_path"));
            cast.add(actor);
        }


        // ******************************** Get crew *******************************************
        for (int i = 0; i < crewArray.length(); i++) {
            crewman = new Crewman();
            crewman.setCredit_id(crewArray.optJSONObject(i).optString("credit_id"));
            crewman.setDepartment(crewArray.optJSONObject(i).optString("department"));
            crewman.setGender(crewArray.optJSONObject(i).optInt("gender"));
            crewman.setId(crewArray.optJSONObject(i).optLong("id"));
            crewman.setJob(crewArray.optJSONObject(i).optString("job"));
            crewman.setName(crewArray.optJSONObject(i).optString("name"));
            crewman.setProfile_path(crewArray.optJSONObject(i).optString("profile_path"));
            crew.add(crewman);
        }

        credit.setCast(cast);
        credit.setCrew(crew);

        return credit;
    }


    /***
     * Retrieves Set of cast list and crew list  containing info about movie/tv and character that Actor plays
     * @param itemType    PERSON_CREDITS_MOVIE, PERSON_CREDITS_TV or PERSON_CREDITS_COMBINED
     * @param personId    Person id as long
     * @return Map  Hashmap of List of movies actor did cast and List of movies actor did crew
     */
    public Map getCreditsForPerson(ItemType itemType, long personId) {
        this.personId = personId;

        JSONObject initialObject = new JSONObject(downloadMovies(itemType));
        JSONArray castArray = initialObject.optJSONArray("cast");
        JSONArray crewArray = initialObject.optJSONArray("crew");

        //Map containing list for cast and crew
        Map<String,List<Movie>> results = new HashMap<>();

        Movie movie;

        // List containing movies and roles that actor played in
        List<Movie> moviesCast = new ArrayList<>();

        for (int i = 0; i < castArray.length(); i++) {
            movie = new Movie();
            movie.setCharacter(castArray.optJSONObject(i).optString("character"));
            movie.setCreditId(castArray.optJSONObject(i).optString("credit_id"));
            // Movie id
            movie.setId(castArray.optJSONObject(i).optLong("id"));
            movie.setPoster_path(castArray.optJSONObject(i).optString("poster_path"));

            if (itemType.equals(ItemType.PERSON_CREDITS_MOVIE)) {
                movie.setTitle(castArray.optJSONObject(i).optString("title"));
                movie.setOriginal_title(castArray.optJSONObject(i).optString("original_title"));
                movie.setRelease_date(castArray.optJSONObject(i).optString("release_date"));

            } else if (itemType.equals(ItemType.PERSON_CREDITS_TV)) {
                movie.setName(castArray.optJSONObject(i).optString("name"));
                movie.setOriginal_name(castArray.optJSONObject(i).optString("original_name"));
                movie.setFirst_air_date(castArray.optJSONObject(i).optString("first_air_date"));
            } else {
                throw
                        new IllegalArgumentException("Wrong argument. Please use PERSON_CREDITS_MOVIE, PERSON_CREDITS_TV or PERSON_CREDITS_COMBINED");
            }

            moviesCast.add(movie);

        }

        results.put("cast", moviesCast);

        // List containing movies and roles that actor commited administrative functions
        List<Movie> moviesCrew = new ArrayList<>();

        for (int i = 0; i < crewArray.length(); i++) {
            movie = new Movie();
            movie.setCreditId(crewArray.optJSONObject(i).optString("credit_id"));
            movie.setDepartment(crewArray.optJSONObject(i).optString("department"));
            // Movie id
            movie.setId(crewArray.optJSONObject(i).optLong("id"));
            movie.setJob(crewArray.optJSONObject(i).optString("job"));
            movie.setPoster_path(crewArray.optJSONObject(i).optString("poster_path"));

            if (itemType.equals(ItemType.PERSON_CREDITS_MOVIE)) {
                movie.setTitle(crewArray.optJSONObject(i).optString("title"));
                movie.setOriginal_title(crewArray.optJSONObject(i).optString("original_title"));
                movie.setRelease_date(crewArray.optJSONObject(i).optString("release_date"));

            } else if (itemType.equals(ItemType.PERSON_CREDITS_TV)) {
                movie.setName(crewArray.optJSONObject(i).optString("name"));
                movie.setOriginal_name(crewArray.optJSONObject(i).optString("original_name"));
                movie.setFirst_air_date(crewArray.optJSONObject(i).optString("first_air_date"));
            } else {
                throw
                        new IllegalArgumentException("Wrong argument. Please use PERSON_CREDITS_MOVIE, PERSON_CREDITS_TV or PERSON_CREDITS_COMBINED");
            }

            moviesCrew.add(movie);
        }

        results.put("crew", moviesCrew);

        return results;
    }


    // ********************************************* SEARCH ******************************************************

    /***
     * Search for movies or tv shows
     * @param query String query
     * @param year  String year of the movies to search
     * @param primary_release_year  String year of primary release of the movies to search
     * @param page  long page number
     * @return list of Movie objects as result of search
     */
    public List<Movie> searchForMovies(ItemType itemType, String query, @Nullable String year, @Nullable String primary_release_year, long page) {
        this.query = query;
        if (itemType.equals(ItemType.MOVIE_SEARCH)) {
            this.searchYear = year;
            this.searchPrimaryReleaseYear = primary_release_year;
            return parseMovies(ItemType.MOVIE_SEARCH, page);
        } else if (itemType.equals(ItemType.TV_SEARCH)) {
            this.firstAirDateYear = primary_release_year;
            return parseMovies(ItemType.TV_SEARCH, page);
        } else {
            throw new IllegalArgumentException("Wrong parameter. Please use MOVIE_SEARCH or TV_SEARCH as parameter");
        }

    }

    /***
     * Search for movies  or tv shows - only 1st page is displayed
     * @param query String query
     * @param year  String year of the movies to search
     * @param primary_release_year  String year of primary release of the movies to search
     * @return list of Movie objects as result of search
     */
    public List<Movie> searchForMovies(ItemType itemType, String query, String year, String primary_release_year) {
        return searchForMovies(itemType, query, year, primary_release_year, 1);
    }


    /***
     * Search for movies  or tv shows
     * @param query String query
     * @param year  String year of the movies to search
     * @param page  long page number
     * @return list of Movie objects as result of search
     */
    public List<Movie> searchForMovies(ItemType itemType, String query, String year, long page) {
        return searchForMovies(itemType, query, year, null, page);
    }


    /***
     * Search for movies  or tv shows - only 1st page is displayed
     * @param query String query
     * @param year  String year of the movies to search
     * @return list of Movie objects as result of search
     */
    public List<Movie> searchForMovies(ItemType itemType, String query, String year) {
        return searchForMovies(itemType, query, year, null, 1);
    }


    /***
     * Search for movies  or tv shows
     * @param query String query
     * @param page  long page number
     * @return list of Movie objects as result of search
     */
    public List<Movie> searchForMovies(ItemType itemType, String query, long page) {
        return searchForMovies(itemType, query, null, null, page);
    }


    /***
     * Search for movies  or tv shows - only 1st page is displayed
     * @param query String query
     * @return list of Movie objects as result of search
     */
    public List<Movie> searchForMovies(ItemType itemType, String query) {
        return searchForMovies(itemType, query, null, null, 1);
    }


    /***
     * Search for people by name
     * @param query String query
     * @param page long page of results
     * @return list of Person objects
     */
    public List<Person> searchForPeople(String query, long page) {
        this.query = query;

        JSONObject initialObject = new JSONObject(downloadMovies(ItemType.PERSON_SEARCH));
        this.page = initialObject.optLong("page");
        this.total_results = initialObject.optLong("total_results");
        this.total_pages = initialObject.optLong("total_pages");
        JSONArray peopleArray = initialObject.optJSONArray("results");

        List<Person> people = new ArrayList<>();
        Person person;

        for (int i = 0; i < peopleArray.length(); i++) {
            person = new Person();
            person.setPopularity(peopleArray.optJSONObject(i).optDouble("popularity"));
            person.setId(peopleArray.optJSONObject(i).optLong("id"));
            person.setProfile_path(peopleArray.optJSONObject(i).optString("profile_path"));
            person.setName(peopleArray.optJSONObject(i).optString("name"));

            JSONArray knownForArray = peopleArray.optJSONObject(i).optJSONArray("known_for");
            List<Movie> knownForMovies = new ArrayList<>();
            Movie movie;
            for (int j = 0; j < knownForArray.length(); j++) {
                movie = new Movie();

                movie.setMediaType(knownForArray.optJSONObject(j).optString("media_type"));
                movie.setVote_average(knownForArray.optJSONObject(j).optDouble("vote_average"));
                movie.setVote_count(knownForArray.optJSONObject(j).optLong("vote_count"));
                movie.setId(knownForArray.optJSONObject(j).optLong("id"));
                movie.setVideo(knownForArray.optJSONObject(j).optBoolean("video"));
                movie.setPopularity(knownForArray.optJSONObject(j).optDouble("popularity"));
                movie.setPoster_path(knownForArray.optJSONObject(j).optString("poster_path"));
                movie.setOriginal_language(knownForArray.optJSONObject(j).optString("original_language"));
                movie.setBackdropPath(knownForArray.optJSONObject(j).optString("backdrop_path"));
                movie.setOverview(knownForArray.optJSONObject(j).optString("overview"));

                if (movie.getMediaType().equals("movie")) {
                    movie.setTitle(knownForArray.optJSONObject(j).optString("title"));
                    movie.setOriginal_title(knownForArray.optJSONObject(j).optString("original_title"));
                    movie.setRelease_date(knownForArray.optJSONObject(j).optString("release_date"));
                } else if (movie.getMediaType().equals("tv")) {
                    movie.setName(knownForArray.optJSONObject(j).optString("name"));
                    movie.setOriginal_name(knownForArray.optJSONObject(j).optString("original_name"));
                    movie.setFirst_air_date(knownForArray.optJSONObject(j).optString("first_air_date"));
                } else {
                    throw new IllegalArgumentException("Wrong media_type. Allowed movie or tv only");
                }
                knownForMovies.add(movie);
            }
            person.setKnown_for(knownForMovies);

            people.add(person);
        }

        return people;
    }


    /***
     * Search for people by name - return 1st page only
     * @param query String query
     * @return list of Person objects
     */
    public List<Person> searchForPeople(String query) {
        return searchForPeople(query, 1);
    }


    /***
     * Search for people, movies and tv shows in bundle
     * @param query String query
     * @param page  long page number
     * @return Mixed list of Person and Movie objects
     */
    public List searchMulti(String query, long page) {

        this.query = query;

        JSONObject initialObject = new JSONObject(downloadMovies(ItemType.MULTI_SEARCH));
        this.page = initialObject.optLong("page");
        this.total_results = initialObject.optLong("total_results");
        this.total_pages = initialObject.optLong("total_pages");
        List results = new ArrayList();
        Movie movie;
        Person person;
        String mediaType;

        JSONArray mixedArray = initialObject.optJSONArray("results");

        for (int i = 0; i < mixedArray.length(); i++) {
            mediaType = mixedArray.optJSONObject(i).optString("media_type");

            switch (mediaType) {
                case "movie": {
                    movie = new Movie();
                    movie.setId(mixedArray.optJSONObject(i).optLong("id"));
                    movie.setVote_count(mixedArray.optJSONObject(i).optLong("vote_count"));
                    movie.setVote_average(mixedArray.optJSONObject(i).optDouble("vote_average"));
                    movie.setTitle(mixedArray.optJSONObject(i).optString("title"));
                    movie.setPopularity(mixedArray.optJSONObject(i).optDouble("popularity"));
                    movie.setPoster_path(mixedArray.optJSONObject(i).optString("poster_path"));
                    movie.setOriginal_language(mixedArray.optJSONObject(i).optString("original_language"));
                    movie.setOriginal_title(mixedArray.optJSONObject(i).optString("original_title"));
                    movie.setBackdropPath(mixedArray.optJSONObject(i).optString("backdrop_path"));
                    movie.setOverview(mixedArray.optJSONObject(i).optString("overview"));
                    movie.setRelease_date(mixedArray.optJSONObject(i).optString("release_date"));
                    movie.setMediaType("movie");

                    results.add(movie);
                    break;
                }
                case "tv": {
                    movie = new Movie();
                    movie.setOriginal_name(mixedArray.optJSONObject(i).optString("original_name"));
                    movie.setId(mixedArray.optJSONObject(i).optLong("id"));
                    movie.setName(mixedArray.optJSONObject(i).optString("name"));
                    movie.setVote_count(mixedArray.optJSONObject(i).optLong("vote_count"));
                    movie.setVote_average(mixedArray.optJSONObject(i).optDouble("vote_average"));
                    movie.setPoster_path(mixedArray.optJSONObject(i).optString("poster_path"));
                    movie.setFirst_air_date(mixedArray.optJSONObject(i).optString("first_air_date"));
                    movie.setPopularity(mixedArray.optJSONObject(i).optDouble("popularity"));
                    movie.setOriginal_language(mixedArray.optJSONObject(i).optString("original_language"));
                    movie.setBackdropPath(mixedArray.optJSONObject(i).optString("backdrop_path"));
                    movie.setOverview(mixedArray.optJSONObject(i).optString("overview"));
                    movie.setMediaType("tv");

                    results.add(movie);
                    break;
                }
                case "person": {
                    person = new Person();
                    person.setPopularity(mixedArray.optJSONObject(i).optDouble("popularity"));
                    person.setId(mixedArray.optJSONObject(i).optLong("id"));
                    person.setProfile_path(mixedArray.optJSONObject(i).optString("profile_path"));
                    person.setName(mixedArray.optJSONObject(i).optString("name"));
                    person.setMediaType("person");

                    results.add(person);
                    break;
                }
            }


        }
        return results;

    }


    /***
     * Search for people, movies and tv shows in bundle - 1st page
     * @param query String query
     * @return Mixed list of Person and Movie objects
     */
    public List searchMulti(String query) {
        return searchMulti(query, 1);
    }


    /***
     * Retrieves list of Keyword objcects associated with movie/tv show
     * @param itemType MOVIE or TV
     * @param id long movie id
     * @return List of Keyword objects
     */
    public List<Keyword> getKeywordsForMovie(ItemType itemType, long id) {

        this.movieId = id;
        JSONObject initialObject = new JSONObject(downloadMovies(itemType));
        JSONArray keywordsArray;
        if (itemType.equals(ItemType.TV_KEYWORDS)) {
            keywordsArray = initialObject.optJSONArray("results");
        } else {
            keywordsArray = initialObject.optJSONArray("keywords");
        }

        List<Keyword> keywords = new ArrayList<>();
        Keyword keyword;

        for (int i = 0; i < keywordsArray.length(); i++) {
            keyword = new Keyword();
            keyword.setId(keywordsArray.optJSONObject(i).optLong("id"));
            keyword.setName(keywordsArray.optJSONObject(i).optString("name"));
            keywords.add(keyword);
        }
        return keywords;
    }


    /***
     * Retrieves person details by person id
     * @param id    long person id
     * @return Person object with properties
     */
    public Person getPersonDetails(long id) {
        this.personId = id;
        JSONObject initialObject = new JSONObject(downloadMovies(ItemType.PERSON_DETAILS));
        Person person = new Person();
        JSONArray aliasesArray = initialObject.optJSONArray("also_known_as");
        List<String> aliases = new ArrayList<>();

        for (int i = 0; i < aliasesArray.length(); i++) {
            aliases.add(aliasesArray.optString(i));
        }

        person.setAlso_known_as(aliases);

        person.setBiography(initialObject.optString("biography"));
        person.setBirthday(initialObject.optString("birthday"));
        person.setDeathday(initialObject.optString("deathday"));
        person.setGender(initialObject.optInt("gender"));
        person.setHomepage(initialObject.optString("homepage"));
        person.setId(initialObject.optLong("id"));
        person.setImdb_id(initialObject.optString("imdb_id"));
        person.setName(initialObject.optString("name"));
        person.setPlace_of_birth(initialObject.optString("place_of_birth"));
        person.setPopularity(initialObject.optDouble("popularity"));
        person.setProfile_path(initialObject.optString("profile_path"));

        return person;
    }

    /***
     * Retrieves data for particular season
     * @param movieId   long tv show id
     * @param seasonNumber  long number of season
     * @return TvSeason object
     */
    public TvSeason getSeasonInfo(long movieId, long seasonNumber){

        this.movieId = movieId;
        this.seasonNumber = seasonNumber;

        JSONObject initialObject = new JSONObject(downloadMovies(ItemType.TV_SEASON));
        TvSeason season = new TvSeason();

        season.set_id(initialObject.optString("_id"));
        season.setId(initialObject.optLong("id"));
        season.setAir_date(initialObject.optString("air_date"));
        season.setName(initialObject.optString("name"));
        season.setOverview(initialObject.optString("overview"));
        season.setPoster_path(initialObject.optString("poster_path"));
        season.setSeason_number(initialObject.optLong("season_number"));

        // ******************************** Iterate through episodes *******************************
        JSONArray episodesArray = initialObject.optJSONArray("episodes");
        List<TvEpisode> episodes = new ArrayList<>();
        TvEpisode episode;

        for (int i = 0; i < episodesArray.length(); i++) {

            episode = new TvEpisode();
            episode.setAir_date(episodesArray.optJSONObject(i).optString("air_date"));
            episode.setEpisode_number(episodesArray.optJSONObject(i).optLong("episode_number"));
            //Episode name
            episode.setName(episodesArray.optJSONObject(i).optString("name"));
            episode.setOverview(episodesArray.optJSONObject(i).optString("overview"));
            // Episode id
            episode.setId(episodesArray.optJSONObject(i).optLong("id"));
            episode.setProduction_code(episodesArray.optJSONObject(i).optDouble("production_code"));
            episode.setSeason_number(episodesArray.optJSONObject(i).optLong("season_number"));
            episode.setStill_path(episodesArray.optJSONObject(i).optString("still_path"));
            episode.setVote_average(episodesArray.optJSONObject(i).optDouble("vote_average"));
            episode.setVote_count(episodesArray.optJSONObject(i).optLong("vote_count"));

            // ************************* Iterate through crew people ********************************
            JSONArray crewArray = episodesArray.optJSONObject(i).optJSONArray("crew");
            List<Crewman> crew = new ArrayList<>();
            Crewman crewman;

            for (int j = 0; j < crewArray.length(); j++) {
                crewman = new Crewman();

                crewman.setCredit_id(crewArray.optJSONObject(j).optString("credit_id"));
                crewman.setDepartment(crewArray.optJSONObject(j).optString("department"));
                crewman.setGender(crewArray.optJSONObject(j).optInt("gender"));
                // Person id
                crewman.setId(crewArray.optJSONObject(j).optLong("id"));
                crewman.setJob(crewArray.optJSONObject(j).optString("job"));
                crewman.setName(crewArray.optJSONObject(j).optString("name"));
                crewman.setProfile_path(crewArray.optJSONObject(j).optString("profile_path"));

                // Add person to crew
                crew.add(crewman);
            }

            // Add crew to episode
            episode.setCrew(crew);
            // ************************* End iterate through crew people ********************************


            // ************************* Iterate through guest stars ********************************
            JSONArray actorArray = episodesArray.optJSONObject(i).optJSONArray("guest_stars");
            List<Actor> guestStars = new ArrayList<>();
            Actor actor;

            for (int j = 0; j < actorArray.length(); j++) {

                actor = new Actor();
                actor.setCharacter(actorArray.optJSONObject(j).optString("character"));
                actor.setCredit_id(actorArray.optJSONObject(j).optString("credit_id"));
                actor.setGender(actorArray.optJSONObject(j).optInt("gender"));
                // Person id
                actor.setId(actorArray.optJSONObject(j).optLong("id"));
                actor.setName(actorArray.optJSONObject(j).optString("name"));
                actor.setOrder(actorArray.optJSONObject(j).optLong("order"));
                actor.setProfile_path(actorArray.optJSONObject(j).optString("profile_path"));


                // Add actor to guest stars
                guestStars.add(actor);

            }

            // Add guest stars to episode
            episode.setGuest_stars(guestStars);



            // Add episode to episodes
            episodes.add(episode);
        }

        // *********************** End iterate through episodes *****************************************

        // Add episodes to season
        season.setEpisodes(episodes);

        return season;

    }
}
