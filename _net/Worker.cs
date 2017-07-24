using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Json;


namespace ya_move_it_parser_net
{
    public class Worker
    {
	//***********************************************
	// Write your API_KEY below after '=' sign
	private const String API_KEY = "api_key=";
	//*********************************************** 


    private const String BASE_URL = "https://api.themoviedb.org/3/";
    private const String YOUTUBE_PREFIX = "https://www.youtube.com/watch?v=";

    private List<Movie> movies;
	private List<Tv> tvs;

	private long page;
	private long total_results;
	private long total_pages;

	private String url;
	private long movieId;
	private long personId;
	private long genreId;
	private long seasonNumber;
	private String query;
	private String searchYear;
	private String searchPrimaryReleaseYear;
	private String firstAirDateYear;

		// ************************************ Getters and setters ************************************************************
		public long getPage()
		{
			return page;
		}

		public void setPage(long page)
		{
			this.page = page;
		}

		public long getTotal_results()
		{
			return total_results;
		}

		public void setTotal_results(long total_results)
		{
			this.total_results = total_results;
		}

		public long getTotal_pages()
		{
			return total_pages;
		}

		public void setTotal_pages(long total_pages)
		{
			this.total_pages = total_pages;
		}

		public long getMovieId()
		{
			return movieId;
		}

		public void setMovieId(long movieId)
		{
			this.movieId = movieId;
		}


		// *********************************************************************************************************************

		/***
		 * Method downloads JSON containing the requested data
		 * @param itemType  One of types of movies or TV shows - enum ItemType
		 * @param page  Number of page to show
		 * @return String with JSON data to parse
		 */
		private String downloadMovies(ItemType itemType, long page)
		{
			String type;

			switch (itemType)
			{
				case ItemType.MOVIE_POPULAR:
					{
						type = "movie/popular";
						break;
					}
				case ItemType.MOVIE_NOW_PLAYING:
					{
						type = "movie/now_playing";
						break;
					}
				case ItemType.MOVIE_TOP_RATED:
					{
						type = "movie/top_rated";
						break;
					}
				case ItemType.MOVIE_UPCOMING:
					{
						type = "movie/upcoming";
						break;
					}
				case ItemType.MOVIES_RECOMMENDED:
					{
						type = "movie/" + movieId + "/recommendations";
						break;
					}
				case ItemType.MOVIES_SIMILAR:
					{
						type = "movie/" + movieId + "/similar";
						break;
					}
				case ItemType.MOVIE_REVIEWS:
					{
						type = "movie/" + movieId + "/reviews";
						break;
					}
				case ItemType.MOVIE_VIDEOS:
					{
						type = "movie/" + movieId + "/videos";
						break;
					}
				case ItemType.MOVIE_CREDITS:
					{
						type = "movie/" + movieId + "/credits";
						break;
					}
				case ItemType.MOVIE_KEYWORDS:
					{
						type = "movie/" + movieId + "/keywords";
						break;
					}
				case ItemType.TV_AIRING_TODAY:
					{
						type = "tv/airing_today";
						break;
					}
				case ItemType.TV_LATEST:
					{
						type = "tv/latest";
						break;
					}
				case ItemType.TV_ON_THE_AIR:
					{
						type = "tv/on_the_air";
						break;
					}
				case ItemType.TV_POPULAR:
					{
						type = "tv/popular";
						break;
					}
				case ItemType.TV_TOP_RATED:
					{
						type = "tv/top_rated";
						break;
					}
				case ItemType.TVS_RECOMMENDED:
					{
						type = "tv/" + movieId + "/recommendations";
						break;
					}
				case ItemType.TVS_SIMILAR:
					{
						type = "tv/" + movieId + "/similar";
						break;
					}
				case ItemType.TV_SEASON:
					{
						type = "tv/" + movieId + "/season/" + seasonNumber;
						break;
					}
				case ItemType.TV_KEYWORDS:
					{
						type = "tv/" + movieId + "/keywords";
						break;
					}
				case ItemType.TV_REVIEWS:
					{
						type = "tv/" + movieId + "/reviews";
						break;
					}
				case ItemType.TV_VIDEOS:
					{
						type = "tv/" + movieId + "/videos";
						break;
					}
				case ItemType.TV_CREDITS:
					{
						type = "tv/" + movieId + "/credits";
						break;
					}
				case ItemType.MOVIE_SEARCH:
					{
						type = "search/movie";
						break;
					}
				case ItemType.TV_SEARCH:
					{
						type = "search/tv";
						break;
					}
				case ItemType.PERSON_SEARCH:
					{
						type = "search/person";
						break;
					}
				case ItemType.MULTI_SEARCH:
					{
						type = "search/multi";
						break;
					}
				case ItemType.PERSON_DETAILS:
					{
						type = "person/" + personId;
						break;
					}
				case ItemType.PERSON_CREDITS_MOVIE:
					{
						type = "person/" + personId + "/movie_credits";
						break;
					}
				case ItemType.PERSON_CREDITS_TV:
					{
						type = "person/" + personId + "/tv_credits";
						break;
					}
				case ItemType.PERSON_CREDITS_COMBINED:
					{
						type = "person/" + personId + "/combined_credits";
						break;
					}
				case ItemType.GENRE_MOVIES:
					{
						type = "genre/" + genreId + "/movies";
						break;
					}
				case ItemType.GENRES_OF_MOVIE:
					{
						type = "genre/movie/list";
						break;
					}
				default:
					{
						type = "movie/popular";
						break;
					}
			}

			// *************************************************************************
			// URL of JSON file
			url = BASE_URL + type + "?" + API_KEY + "&language=en-US&page=" + page;
			// *************************************************************************


			// If we want to search, include search query and parameters in url
            if (query != null && query.Length > 0)
			{
				url += "&query=" + query;

                if (searchYear != null && searchYear.Length > 0)
				{
					url += "&year=" + searchYear;
				}

                if (searchPrimaryReleaseYear != null && searchPrimaryReleaseYear.Length > 0)
				{
					url += "&primary_release_year=" + searchPrimaryReleaseYear;
				}

                if (firstAirDateYear != null && firstAirDateYear.Length > 0)
				{
					url += "&first_air_date_year=" + firstAirDateYear;
				}
			}

			// Make query and parameters null
			this.query = null;
			this.searchYear = null;
			this.searchPrimaryReleaseYear = null;
			this.firstAirDateYear = null;


			try
			{
                // Implement file download

                WebClient client = new WebClient();

                return new StreamReader(client.OpenRead(url)).ReadToEnd();

			}
			catch (IOException e)
			{

                return e.Message;
			}


		}

		// *********************************************************************************************************************

		/***
		 * Method downloads JSON containing the requested data for 1st page
		 * @param itemType  One of types of movies or TV shows - enum ItemType
		 * @return String with JSON data to parse
		 */
		private String downloadMovies(ItemType itemType)
		{
			return downloadMovies(itemType, 1);
		}

		// *********************************************************************************************************************

		/***
		 * Download json for given movie id
		 * @param itemType    One of ItemType items defining the movie type
		 * @param id    Movie id as long
		 * @return JSON as String
		 */
		private String downloadSingleMovie(ItemType itemType, long id)
		{
			String url;
			if (itemType.Equals(ItemType.MOVIE))
			{
                url = BASE_URL + "movie/" + id.ToString() + "?" + API_KEY + "&language=en-US";
			}
			else if (itemType.Equals(ItemType.TV))
			{
                url = BASE_URL + "tv/" + id.ToString() + "?" + API_KEY + "&language=en-US";
			}
			else
			{
				throw new 
						ArgumentException("Wrong ItemType parameter. PLease use either ItemType.MOVIE or ItemType.TV");
			}

			try
			{
				WebClient client = new WebClient();

				return new StreamReader(client.OpenRead(url)).ReadToEnd();

			}
			catch (Exception e)
			{

                return e.Message;
			}
		}


		// *********************************************************************************************************************

		/***
		 *  Parses movies data for given type and given page
		 * @param itemType  One of ItemType items defining the movie type
		 * @param page long representing the page number
		 * @return list of movies
		 */
		public List<Movie> parseMovies(ItemType itemType, long page)
		{
            JsonValue initialObject = JsonValue.Parse(downloadMovies(itemType, page));

            this.page = initialObject["page"];
			this.total_results = initialObject["total_results"];
			this.total_pages = initialObject["total_pages"];
            var results = initialObject["results"];
			movies = new List<Movie>();
			Movie movie;

            for (int i = 0; i < results.Count; i++)
			{
				movie = new Movie();

				// Properties common for both movies and tv shows
				movie.setBackdropPath(results[i]["backdrop_path"]);
				movie.setId(results[i]["id"]);
				movie.setOriginal_language(results[i]["original_language"]);
				movie.setOverview(results[i]["overview"]);
				movie.setPopularity(results[i]["popularity"]);
				movie.setPoster_path(results[i]["poster_path"]);
				movie.setVote_average(results[i]["vote_average"]);
				movie.setVote_count(results[i]["vote_count"]);


				// Parses properties for movies only!
				if (itemType.Equals(ItemType.MOVIE_POPULAR) ||
						itemType.Equals(ItemType.MOVIE_TOP_RATED) ||
						itemType.Equals(ItemType.MOVIE_NOW_PLAYING) ||
						itemType.Equals(ItemType.MOVIE_UPCOMING) ||
						itemType.Equals(ItemType.MOVIES_SIMILAR) ||
						itemType.Equals(ItemType.MOVIES_RECOMMENDED) ||
						itemType.Equals(ItemType.MOVIE_SEARCH) ||
						itemType.Equals(ItemType.GENRE_MOVIES))
				{
					movie.setVideo(results[i]["video"]);
					movie.setTitle(results[i]["title"]);
					movie.setOriginal_title(results[i]["original_title"]);
					movie.setAdult(results[i]["adult"]);
					movie.setRelease_date(results[i]["release_date"]);
				}
				// Parses properties for tv shows only!
				else if (itemType.Equals(ItemType.TV_AIRING_TODAY) ||
						itemType.Equals(ItemType.TV_LATEST) ||
						itemType.Equals(ItemType.TV_POPULAR) ||
						itemType.Equals(ItemType.TV_ON_THE_AIR) ||
						itemType.Equals(ItemType.TV_TOP_RATED) ||
						itemType.Equals(ItemType.TVS_SIMILAR) ||
						itemType.Equals(ItemType.TVS_RECOMMENDED) ||
						itemType.Equals(ItemType.TV_SEARCH))
				{
					movie.setFirst_air_date(results[i]["first_air_date"]);
					movie.setName(results[i]["name"]);
					movie.setOriginal_name(results[i]["original_name"]);

				}
				else
				{
					throw new ArgumentException("Wrong ItemType argument");
				}

				movies.Add(movie);
			}

			return movies;
		}


		// *********************************************************************************************************************

		/***
		 * Parses movies data for given type and 1st page
		 * @param itemType  One of ItemType items defining the movie type
		 * @return list of movies
		 */
		public List<Movie> parseMovies(ItemType itemType)
		{
			return parseMovies(itemType, 1);
		}


		// *********************************************************************************************************************

		/***
		 * Parses json for single movie
		 * @param itemType  One of ItemType items defining the movie type
		 * @param id  Movie id
		 * @return Movie object with details
		 */
		public Movie parseSingleMovie(ItemType itemType, long id)
		{

			Movie movie = new Movie();
            var initialObject = JsonValue.Parse(downloadSingleMovie(itemType, id));

			// ********************************************************************************************************
			// ********************* Properties common for both movies and tv shows ***********************************
			// ********************************************************************************************************
			movie.setBackdropPath(initialObject["backdrop_path"]);
			movie.setHomepage(initialObject["homepage"]);
			movie.setId(initialObject["id"]);
			movie.setOriginal_language(initialObject["original_language"]);
			movie.setOverview(initialObject["overview"]);
			movie.setPopularity(initialObject["popularity"]);
			movie.setPoster_path(initialObject["poster_path"]);
			movie.setStatus(initialObject["status"]);
			movie.setVote_average(initialObject["vote_average"]);
			movie.setVote_count(initialObject["vote_count"]);

			// ************************** Set genres ***************************
            var genresArray = initialObject["genres"];
			List<Genre> genres = new List<Genre>();
			Genre genre;
            for (int j = 0; j < genresArray.Count; j++)
			{
				genre = new Genre();
				genre.setId(genresArray[j]["id"]);
				genre.setName(genresArray[j]["name"]);
				genres.Add(genre);
			}
			movie.setGenres(genres);


			// ************************** Set production companies ***************************
			var companiesArray = initialObject["production_companies"];
            List<ProductionCompany> companies = new List<ProductionCompany>();
			ProductionCompany company;
            for (int j = 0; j < companiesArray.Count; j++)
			{
				company = new ProductionCompany();
				company.setId(companiesArray[j]["id"]);
				company.setName(companiesArray[j]["name"]);
				companies.Add(company);
			}
			movie.setProduction_companies(companies);


			// ********************************************************************************************************
			// ***************************** Parses properties for movies only! ***************************************
			// ********************************************************************************************************
			if (itemType.Equals(ItemType.MOVIE))
			{
				movie.setAdult(initialObject["adult"]);
				movie.setCollectionId(initialObject["belongs_to_collection"]);
				movie.setBudget(initialObject["budget"]);
				movie.setImdb_id(initialObject["imdb_id"]);
				movie.setOriginal_title(initialObject["original_title"]);

				// ************************** Set production countries ***************************
				var countriesArray = initialObject["production_countries"];
                List<ProductionCountry> countries = new List<ProductionCountry>();
				ProductionCountry country;
                for (int j = 0; j < countriesArray.Count; j++)
				{
					country = new ProductionCountry();
					country.setIso_3166_1(countriesArray[j]["iso_3166_1"]);
					country.setName(countriesArray[j]["name"]);
					countries.Add(country);
				}
				movie.setProduction_countries(countries);
				movie.setRelease_date(initialObject["release_date"]);
				movie.setRevenue(initialObject["revenue"]);
				movie.setRuntime(initialObject["runtime"]);

				// ************************** Set spoken languages ***************************
				var languagesArray = initialObject["spoken_languages"];
                List<SpokenLanguage> languages = new List<SpokenLanguage>();
				SpokenLanguage language;
                for (int j = 0; j < languagesArray.Count; j++)
				{
					language = new SpokenLanguage();
					language.setIso_639_1(languagesArray[j]["iso_639_1"]);
					language.setName(languagesArray[j]["name"]);
					languages.Add(language);
				}
				movie.setSpoken_languages(languages);
				movie.setTagline(initialObject["tagline"]);
				movie.setTitle(initialObject["title"]);
				movie.setVideo(initialObject["video"]);

			}
			// ********************************************************************************************************
			// ************************* Parses properties for tv shows only! *****************************************
			// ********************************************************************************************************
			else if (itemType.Equals(ItemType.TV))
			{

				// ************************** Set created by ***************************
				var createdByArray = initialObject["created_by"];
                List<Crewman> crew = new List<Crewman>();
				Crewman crewman;
                for (int i = 0; i < createdByArray.Count; i++)
				{
					crewman = new Crewman();
					crewman.setId(createdByArray[i]["id"]);
					crewman.setName(createdByArray[i]["name"]);
					crewman.setGender(createdByArray[i]["gender"]);
					crewman.setProfile_path(createdByArray[i]["profile_path"]);
					crew.Add(crewman);
				}
				movie.setCreated_by(crew);

				// ************************** Set episode runtime ***************************
				var episodesArray = initialObject["episode_run_time"];
                List<long> episodesRuntime = new List<long>();
                for (int i = 0; i < episodesArray.Count; i++)
				{
					episodesRuntime.Add(episodesArray[i]);
				}
				movie.setEpisode_run_time(episodesRuntime);

				movie.setIn_production(initialObject["in_production"]);


				// ************************** Set languages ***************************
				var languagesArray = initialObject["languages"];
                List<String> languages = new List<String>();
                for (int i = 0; i < languagesArray.Count; i++)
				{
					languages.Add(languagesArray[i]);
				}
				movie.setLanguages(languages);

				movie.setLast_air_date(initialObject["last_air_date"]);


				// ************************** Set networks ***************************
				var networksArray = initialObject["networks"];
                List<Network> networks = new List<Network>();
				Network network;
                for (int i = 0; i < networksArray.Count; i++)
				{
					network = new Network();
					network.setId(createdByArray[i]["id"]);
					network.setName(createdByArray[i]["name"]);
					networks.Add(network);
				}
				movie.setNetworks(networks);


				movie.setNumber_of_episodes(initialObject["number_of_episodes"]);
				movie.setNumber_of_seasons(initialObject["number_of_seasons"]);

				// ************************** Set origin countries ***************************
				var countriesArray = initialObject["origin_country"];
                List<String> countries = new List<String>();
                for (int i = 0; i < languagesArray.Count; i++)
				{
					countries.Add(countriesArray[i]);
				}
				movie.setOrigin_country(countries);


				// ************************** Set seasons ***************************
				var seasonsArray = initialObject["seasons"];
                List<TvSeason> seasons = new List<TvSeason>();
				TvSeason season;
                for (int i = 0; i < seasonsArray.Count; i++)
				{
					season = new TvSeason();
					season.setAir_date(seasonsArray[i]["air_date"]);
					season.setEpisode_count(seasonsArray[i]["episode_count"]);
					season.setId(seasonsArray[i]["id"]);
					season.setPoster_path(seasonsArray[i]["poster_path"]);
					season.setSeason_number(seasonsArray[i]["season_number"]);
					seasons.Add(season);
				}
				movie.setSeasons(seasons);

				movie.setType(initialObject["type"]);


			}
			else
			{
				throw new ArgumentException("Wrong ItemType argument");
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
		public List<Movie> getRecommendedMovies(ItemType itemType, long id, long page)
		{
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
		public List<Movie> getRecommendedMovies(ItemType itemType, long id)
		{
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
		public List<Movie> getSimilarMovies(ItemType itemType, long id, long page)
		{
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
		public List<Movie> getSimilarMovies(ItemType itemType, long id)
		{
			this.movieId = id;
			return parseMovies(itemType);
		}


		// *********************************************************************************************************************

		/***
		 * Retrieves list of reviews for given movie id and first page
		 * @param id    Movie id as long
		 * @return List of Review objects
		 */
		public List<Review> getMovieReviews(ItemType itemType, long id)
		{
			this.movieId = id;
            List<Review> reviews = new List<Review>();
            JsonValue initialObject = JsonValue.Parse(downloadMovies(itemType));
			this.page = initialObject["page"];
			var reviewsArray = initialObject["results"];

			Review review;

            for (int i = 0; i < reviewsArray.Count; i++)
			{
				review = new Review();
				review.setId(reviewsArray[i]["id"]);
				review.setAuthor(reviewsArray[i]["author"]);
				review.setContent(reviewsArray[i]["content"]);
				review.setUrl(reviewsArray[i]["url"]);
				reviews.Add(review);
			}
			return reviews;
		}


		// *********************************************************************************************************************

		/***
		 * Retrieves list of videos for given movie id and first page
		 * @param id    Movie id as long
		 * @return List of Video objects
		 */
		public List<Video> getMovieVideos(ItemType itemType, long id)
		{
			this.movieId = id;
            List<Video> videos = new List<Video>();
            JsonValue initialObject = JsonValue.Parse(downloadMovies(itemType));
			var videosArray = initialObject["results"];

			Video video;

            for (int i = 0; i < videosArray.Count; i++)
			{
				video = new Video();
				video.setId(videosArray[i]["id"]);
				video.setIso_639_1(videosArray[i]["iso_639_1"]);
				video.setIso_3166_1(videosArray[i]["iso_3166_1"]);
				video.setName(videosArray[i]["name"]);
				video.setKey(YOUTUBE_PREFIX + videosArray[i]["key"]);
				video.setSite(videosArray[i]["site"]);
				video.setSize(videosArray[i]["size"]);
				video.setType(videosArray[i]["type"]);
				videos.Add(video);
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
		public Credit getCreditsForMovie(ItemType itemType, long id)
		{

			this.movieId = id;
			Credit credit = new Credit();
            List<Actor> cast = new List<Actor>();
            List<Crewman> crew = new List<Crewman>();

            JsonValue initialObject = JsonValue.Parse(downloadMovies(itemType));
			var castArray = initialObject["cast"];
			var crewArray = initialObject["crew"];
			Actor actor;
			Crewman crewman;

			// ******************************** Get cast *******************************************
            for (int i = 0; i < castArray.Count; i++)
			{
				actor = new Actor();
				actor.setCharacter(castArray[i]["character"]);
				actor.setCredit_id(castArray[i]["credit_id"]);
				actor.setGender(castArray[i]["gender"]);
				actor.setId(castArray[i]["id"]);
				actor.setName(castArray[i]["name"]);
				actor.setOrder(castArray[i]["order"]);
				actor.setProfile_path(castArray[i]["profile_path"]);
				cast.Add(actor);
			}


			// ******************************** Get crew *******************************************
            for (int i = 0; i < crewArray.Count; i++)
			{
				crewman = new Crewman();
				crewman.setCredit_id(crewArray[i]["credit_id"]);
				crewman.setDepartment(crewArray[i]["department"]);
				crewman.setGender(crewArray[i]["gender"]);
				crewman.setId(crewArray[i]["id"]);
				crewman.setJob(crewArray[i]["job"]);
				crewman.setName(crewArray[i]["name"]);
				crewman.setProfile_path(crewArray[i]["profile_path"]);
				crew.Add(crewman);
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
        public Dictionary<String, List<Movie>> getCreditsForPerson(ItemType itemType, long personId)
		{
			this.personId = personId;

            JsonValue initialObject = JsonValue.Parse(downloadMovies(itemType));
			var castArray = initialObject["cast"];
			var crewArray = initialObject["crew"];

			//Map containing list for cast and crew
			Dictionary<String, List<Movie>> results = new Dictionary<string, List<Movie>>();

			Movie movie;

			// List containing movies and roles that actor played in
            List<Movie> moviesCast = new List<Movie>();

            for (int i = 0; i < castArray.Count; i++)
			{
				movie = new Movie();
				movie.setCharacter(castArray[i]["character"]);
				movie.setCreditId(castArray[i]["credit_id"]);
				// Movie id
				movie.setId(castArray[i]["id"]);
				movie.setPoster_path(castArray[i]["poster_path"]);

				if (itemType.Equals(ItemType.PERSON_CREDITS_MOVIE))
				{
					movie.setTitle(castArray[i]["title"]);
					movie.setOriginal_title(castArray[i]["original_title"]);
					movie.setRelease_date(castArray[i]["release_date"]);

				}
				else if (itemType.Equals(ItemType.PERSON_CREDITS_TV))
				{
					movie.setName(castArray[i]["name"]);
					movie.setOriginal_name(castArray[i]["original_name"]);
					movie.setFirst_air_date(castArray[i]["first_air_date"]);
				}
				else
				{
					throw
							new ArgumentException("Wrong argument. Please use PERSON_CREDITS_MOVIE, PERSON_CREDITS_TV or PERSON_CREDITS_COMBINED");
				}

				moviesCast.Add(movie);

			}

            results["cast"] = moviesCast;

			// List containing movies and roles that actor commited administrative functions
            List<Movie> moviesCrew = new List<Movie>();

            for (int i = 0; i < crewArray.Count; i++)
			{
				movie = new Movie();
				movie.setCreditId(crewArray[i]["credit_id"]);
				movie.setDepartment(crewArray[i]["department"]);
				// Movie id
				movie.setId(crewArray[i]["id"]);
				movie.setJob(crewArray[i]["job"]);
				movie.setPoster_path(crewArray[i]["poster_path"]);

				if (itemType.Equals(ItemType.PERSON_CREDITS_MOVIE))
				{
					movie.setTitle(crewArray[i]["title"]);
					movie.setOriginal_title(crewArray[i]["original_title"]);
					movie.setRelease_date(crewArray[i]["release_date"]);

				}
				else if (itemType.Equals(ItemType.PERSON_CREDITS_TV))
				{
					movie.setName(crewArray[i]["name"]);
					movie.setOriginal_name(crewArray[i]["original_name"]);
					movie.setFirst_air_date(crewArray[i]["first_air_date"]);
				}
				else
				{
					throw
							new ArgumentException("Wrong argument. Please use PERSON_CREDITS_MOVIE, PERSON_CREDITS_TV or PERSON_CREDITS_COMBINED");
				}

				moviesCrew.Add(movie);
			}

            results["crew"] = moviesCrew;

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
		public List<Movie> searchForMovies(ItemType itemType, String query, String year,String primary_release_year, long page)
		{
			this.query = query;
			if (itemType.Equals(ItemType.MOVIE_SEARCH))
			{
				this.searchYear = year;
				this.searchPrimaryReleaseYear = primary_release_year;
				return parseMovies(ItemType.MOVIE_SEARCH, page);
			}
			else if (itemType.Equals(ItemType.TV_SEARCH))
			{
				this.firstAirDateYear = primary_release_year;
				return parseMovies(ItemType.TV_SEARCH, page);
			}
			else
			{
				throw new ArgumentException("Wrong parameter. Please use MOVIE_SEARCH or TV_SEARCH as parameter");
			}

		}

		/***
		 * Search for movies  or tv shows - only 1st page is displayed
		 * @param query String query
		 * @param year  String year of the movies to search
		 * @param primary_release_year  String year of primary release of the movies to search
		 * @return list of Movie objects as result of search
		 */
		public List<Movie> searchForMovies(ItemType itemType, String query, String year, String primary_release_year)
		{
			return searchForMovies(itemType, query, year, primary_release_year, 1);
		}


		/***
		 * Search for movies  or tv shows
		 * @param query String query
		 * @param year  String year of the movies to search
		 * @param page  long page number
		 * @return list of Movie objects as result of search
		 */
		public List<Movie> searchForMovies(ItemType itemType, String query, String year, long page)
		{
			return searchForMovies(itemType, query, year, null, page);
		}


		/***
		 * Search for movies  or tv shows - only 1st page is displayed
		 * @param query String query
		 * @param year  String year of the movies to search
		 * @return list of Movie objects as result of search
		 */
		public List<Movie> searchForMovies(ItemType itemType, String query, String year)
		{
			return searchForMovies(itemType, query, year, null, 1);
		}


		/***
		 * Search for movies  or tv shows
		 * @param query String query
		 * @param page  long page number
		 * @return list of Movie objects as result of search
		 */
		public List<Movie> searchForMovies(ItemType itemType, String query, long page)
		{
			return searchForMovies(itemType, query, null, null, page);
		}


		/***
		 * Search for movies  or tv shows - only 1st page is displayed
		 * @param query String query
		 * @return list of Movie objects as result of search
		 */
		public List<Movie> searchForMovies(ItemType itemType, String query)
		{
			return searchForMovies(itemType, query, null, null, 1);
		}


		/***
		 * Search for people by name
		 * @param query String query
		 * @param page long page of results
		 * @return list of Person objects
		 */
		public List<Person> searchForPeople(String query, long page)
		{
			this.query = query;

            JsonValue initialObject = JsonValue.Parse(downloadMovies(ItemType.PERSON_SEARCH));
			this.page = initialObject["page"];
			this.total_results = initialObject["total_results"];
			this.total_pages = initialObject["total_pages"];
			var peopleArray = initialObject["results"];

            List<Person> people = new List<Person>();
			Person person;

            for (int i = 0; i < peopleArray.Count; i++)
			{
				person = new Person();
				person.setPopularity(peopleArray[i]["popularity"]);
				person.setId(peopleArray[i]["id"]);
				person.setProfile_path(peopleArray[i]["profile_path"]);
				person.setName(peopleArray[i]["name"]);

				var knownForArray = peopleArray[i]["known_for"];
                List<Movie> knownForMovies = new List<Movie>();
				Movie movie;
                for (int j = 0; j < knownForArray.Count; j++)
				{
					movie = new Movie();

					movie.setMediaType(knownForArray[j]["media_type"]);
					movie.setVote_average(knownForArray[j]["vote_average"]);
					movie.setVote_count(knownForArray[j]["vote_count"]);
					movie.setId(knownForArray[j]["id"]);
					movie.setPopularity(knownForArray[j]["popularity"]);
					movie.setPoster_path(knownForArray[j]["poster_path"]);
					movie.setOriginal_language(knownForArray[j]["original_language"]);
					movie.setBackdropPath(knownForArray[j]["backdrop_path"]);
					movie.setOverview(knownForArray[j]["overview"]);

					if (movie.getMediaType().Equals("movie"))
					{
						movie.setTitle(knownForArray[j]["title"]);
						movie.setOriginal_title(knownForArray[j]["original_title"]);
						movie.setRelease_date(knownForArray[j]["release_date"]);
					}
					else if (movie.getMediaType().Equals("tv"))
					{
						movie.setName(knownForArray[j]["name"]);
						movie.setOriginal_name(knownForArray[j]["original_name"]);
						movie.setFirst_air_date(knownForArray[j]["first_air_date"]);
					}
					else
					{
						throw new ArgumentException("Wrong media_type. Allowed movie or tv only");
					}
					knownForMovies.Add(movie);
				}
				person.setKnown_for(knownForMovies);

				people.Add(person);
			}

			return people;
		}


		/***
		 * Search for people by name - return 1st page only
		 * @param query String query
		 * @return list of Person objects
		 */
		public List<Person> searchForPeople(String query)
		{
			return searchForPeople(query, 1);
		}


		/***
		 * Search for people, movies and tv shows in bundle
		 * @param query String query
		 * @param page  long page number
		 * @return Mixed list of Person and Movie objects
		 */
		public ArrayList searchMulti(String query, long page)
		{

			this.query = query;

            JsonValue initialObject = JsonValue.Parse(downloadMovies(ItemType.MULTI_SEARCH));
			this.page = initialObject["page"];
			this.total_results = initialObject["total_results"];
			this.total_pages = initialObject["total_pages"];
			ArrayList results = new ArrayList();
			Movie movie;
			Person person;
			String mediaType;

			var mixedArray = initialObject["results"];

            for (int i = 0; i < mixedArray.Count; i++)
			{
				mediaType = mixedArray[i]["media_type"];

				switch (mediaType)
				{
					case "movie":
						{
							movie = new Movie();
							movie.setId(mixedArray[i]["id"]);
							movie.setVote_count(mixedArray[i]["vote_count"]);
							movie.setVote_average(mixedArray[i]["vote_average"]);
							movie.setTitle(mixedArray[i]["title"]);
							movie.setPopularity(mixedArray[i]["popularity"]);
							movie.setPoster_path(mixedArray[i]["poster_path"]);
							movie.setOriginal_language(mixedArray[i]["original_language"]);
							movie.setOriginal_title(mixedArray[i]["original_title"]);
							movie.setBackdropPath(mixedArray[i]["backdrop_path"]);
							movie.setOverview(mixedArray[i]["overview"]);
							movie.setRelease_date(mixedArray[i]["release_date"]);
							movie.setMediaType("movie");

							results.Add(movie);
							break;
						}
					case "tv":
						{
							movie = new Movie();
							movie.setOriginal_name(mixedArray[i]["original_name"]);
							movie.setId(mixedArray[i]["id"]);
							movie.setName(mixedArray[i]["name"]);
							movie.setVote_count(mixedArray[i]["vote_count"]);
							movie.setVote_average(mixedArray[i]["vote_average"]);
							movie.setPoster_path(mixedArray[i]["poster_path"]);
							movie.setFirst_air_date(mixedArray[i]["first_air_date"]);
							movie.setPopularity(mixedArray[i]["popularity"]);
							movie.setOriginal_language(mixedArray[i]["original_language"]);
							movie.setBackdropPath(mixedArray[i]["backdrop_path"]);
							movie.setOverview(mixedArray[i]["overview"]);
							movie.setMediaType("tv");

							results.Add(movie);
							break;
						}
					case "person":
						{
							person = new Person();
							person.setPopularity(mixedArray[i]["popularity"]);
							person.setId(mixedArray[i]["id"]);
							person.setProfile_path(mixedArray[i]["profile_path"]);
							person.setName(mixedArray[i]["name"]);
							person.setMediaType("person");

							results.Add(person);
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
		public ArrayList searchMulti(String query)
		{
			return searchMulti(query, 1);
		}


		/***
		 * Retrieves list of Keyword objcects associated with movie/tv show
		 * @param itemType MOVIE or TV
		 * @param id long movie id
		 * @return List of Keyword objects
		 */
		public List<Keyword> getKeywordsForMovie(ItemType itemType, long id)
		{

			this.movieId = id;
            JsonValue initialObject = JsonValue.Parse(downloadMovies(itemType));
			JsonArray keywordsArray;
			if (itemType.Equals(ItemType.TV_KEYWORDS))
			{
				keywordsArray = (System.Json.JsonArray)initialObject["results"];
			}
			else
			{
				keywordsArray = (System.Json.JsonArray)initialObject["keywords"];
			}

            List<Keyword> keywords = new List<Keyword>();
			Keyword keyword;

            for (int i = 0; i < keywordsArray.Count; i++)
			{
				keyword = new Keyword();
				keyword.setId(keywordsArray[i]["id"]);
				keyword.setName(keywordsArray[i]["name"]);
				keywords.Add(keyword);
			}
			return keywords;
		}


		/***
		 * Retrieves person details by person id
		 * @param id    long person id
		 * @return Person object with properties
		 */
		public Person getPersonDetails(long id)
		{
			this.personId = id;
            JsonValue initialObject = JsonValue.Parse(downloadMovies(ItemType.PERSON_DETAILS));
			Person person = new Person();
			var aliasesArray = initialObject["also_known_as"];
			List<String> aliases = new List<String>();

            for (int i = 0; i < aliasesArray.Count; i++)
			{
				aliases.Add(aliasesArray[i]);
			}

			person.setAlso_known_as(aliases);

			person.setBiography(initialObject["biography"]);
			person.setBirthday(initialObject["birthday"]);
			person.setDeathday(initialObject["deathday"]);
			person.setGender(initialObject["gender"]);
			person.setHomepage(initialObject["homepage"]);
			person.setId(initialObject["id"]);
			person.setImdb_id(initialObject["imdb_id"]);
			person.setName(initialObject["name"]);
			person.setPlace_of_birth(initialObject["place_of_birth"]);
			person.setPopularity(initialObject["popularity"]);
			person.setProfile_path(initialObject["profile_path"]);

			return person;
		}

		/***
		 * Retrieves data for particular season
		 * @param movieId   long tv show id
		 * @param seasonNumber  long number of season
		 * @return TvSeason object
		 */
		public TvSeason getSeasonInfo(long movieId, long seasonNumber)
		{

			this.movieId = movieId;
			this.seasonNumber = seasonNumber;

            JsonValue initialObject = JsonValue.Parse(downloadMovies(ItemType.TV_SEASON));
			TvSeason season = new TvSeason();

			season.set_id(initialObject["_id"]);
			season.setId(initialObject["id"]);
			season.setAir_date(initialObject["air_date"]);
			season.setName(initialObject["name"]);
			season.setOverview(initialObject["overview"]);
			season.setPoster_path(initialObject["poster_path"]);
			season.setSeason_number(initialObject["season_number"]);

			// ******************************** Iterate through episodes *******************************
			var episodesArray = initialObject["episodes"];
            List<TvEpisode> episodes = new List<TvEpisode>();
			TvEpisode episode;

            for (int i = 0; i < episodesArray.Count; i++)
			{

				episode = new TvEpisode();
				episode.setAir_date(episodesArray[i]["air_date"]);
				episode.setEpisode_number(episodesArray[i]["episode_number"]);
				//Episode name
				episode.setName(episodesArray[i]["name"]);
				episode.setOverview(episodesArray[i]["overview"]);
				// Episode id
				episode.setId(episodesArray[i]["id"]);
				episode.setSeason_number(episodesArray[i]["season_number"]);
				episode.setStill_path(episodesArray[i]["still_path"]);
				episode.setVote_average(episodesArray[i]["vote_average"]);
				episode.setVote_count(episodesArray[i]["vote_count"]);

				// ************************* Iterate through crew people ********************************
				var crewArray = episodesArray[i]["crew"];
                List<Crewman> crew = new List<Crewman>();
				Crewman crewman;

                for (int j = 0; j < crewArray.Count; j++)
				{
					crewman = new Crewman();

					crewman.setCredit_id(crewArray[j]["credit_id"]);
					crewman.setDepartment(crewArray[j]["department"]);
                    var genderVar = crewArray[j]["gender"];
                    if(genderVar != null){
                        crewman.setGender(genderVar);
                    }
					// Person id
					crewman.setId(crewArray[j]["id"]);
					crewman.setJob(crewArray[j]["job"]);
					crewman.setName(crewArray[j]["name"]);
                    var pathVar = crewArray[j]["profile_path"];
                    if(pathVar != null){
                        crewman.setProfile_path(pathVar);
                    }
					
					// Add person to crew
					crew.Add(crewman);
				}

				// Add crew to episode
				episode.setCrew(crew);
				// ************************* End iterate through crew people ********************************


				// ************************* Iterate through guest stars ********************************
				var actorArray = episodesArray[i]["guest_stars"];
                List<Actor> guestStars = new List<Actor>();
				Actor actor;

                for (int j = 0; j < actorArray.Count; j++)
				{

					actor = new Actor();
					actor.setCharacter(actorArray[j]["character"]);
					actor.setCredit_id(actorArray[j]["credit_id"]);
                    var genderVar = actorArray[j]["gender"];
					if (genderVar != null)
					{
                        actor.setGender(genderVar);
					}

					// Person id
					actor.setId(actorArray[j]["id"]);
					actor.setName(actorArray[j]["name"]);
					actor.setOrder(actorArray[j]["order"]);
                    var pathVar = actorArray[j]["profile_path"];
					if (pathVar != null)
					{
                        actor.setProfile_path(pathVar);
					}
				


					// Add actor to guest stars
					guestStars.Add(actor);

				}

				// Add guest stars to episode
				episode.setGuest_stars(guestStars);



				// Add episode to episodes
				episodes.Add(episode);
			}

			// *********************** End iterate through episodes *****************************************

			// Add episodes to season
			season.setEpisodes(episodes);

			return season;

		}


		/***
		 *  Retrieves list of movies for particular genre (category)
		 * @param genreId   Genre ID
		 * @param page  Page number
		 * @return  List of Movie objects
		 */
		public List<Movie> getMoviesByGenre(long genreId, long page)
		{
			this.genreId = genreId;
			return parseMovies(ItemType.GENRE_MOVIES, page);
		}


		/***
		 *  Retrieves list of movies for particular genre (category) for 1st page
		 * @param genreId   Genre ID
		 * @return  List of Movie objects
		 */
		public List<Movie> getMoviesByGenre(long genreId)
		{
			this.genreId = genreId;
			return getMoviesByGenre(genreId, 1);
		}


		/***
		 * Retrieves updated list of genres (categories) for movies
		 * @return  List of Genre objects
		 */
		public List<Genre> getListOfGenres()
		{
			List<Genre> genres = new List<Genre>();
            JsonValue initialObject = JsonValue.Parse(downloadMovies(ItemType.GENRES_OF_MOVIE));
			var genresArray = initialObject["genres"];
			Genre genre;

            for (int i = 0; i < genresArray.Count; i++)
			{
				genre = new Genre();
				genre.setId(genresArray[i]["id"]);
				genre.setName(genresArray[i]["name"]);
				genres.Add(genre);
			}
			return genres;
		}
    }
}
