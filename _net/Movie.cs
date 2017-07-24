using System;
using System.Collections.Generic;

namespace ya_move_it_parser_net
{
    public class Movie
    {
		private bool isAdult;
		private String backdropPath;
		private long collectionId;
		private long budget;
		private List<Genre> genres;
		private String homepage;
		private long id;
		private String mediaType;
		private String imdb_id;
		private String original_language;
		private String original_title;
		private String overview;
		private double popularity;
		private String poster_path;
		private List<ProductionCompany> production_companies;
		private List<ProductionCountry> production_countries;
		private String release_date;
		private long revenue;
		private long runtime;
		private List<SpokenLanguage> spoken_languages;
		private String status;
		private String tagline;
		private String title;
		private bool video;
		private double vote_average;
		private long vote_count;
		private Credit credit;
		private List<Keyword> keywords;
		private List<Video> videos;
		private List<Movie> recommendedMovies;
		private List<Movie> similardMovies;
		private List<Review> reviews;
		private List<MoviesList> listsMovieBelongsTo;
		private Movie latest;
		private List<Movie> now_playing;
		private List<Movie> popular;
		private List<Movie> top_rated;
		private List<Movie> upcoming;

		// Used for combined object in credits for person
		private String character;
		private String creditId;
		private String department;
		private String job;

		private long page;
		private long total_results;
		private long total_pages;
		private String min_date;
		private String max_date;

		// Specific for TV shows
		private List<Crewman> created_by;
        private List<long> episode_run_time;
		private String first_air_date;
		private bool in_production;
		private List<String> languages;
		private String last_air_date;
		private String name;
		private List<Network> networks;
		private long number_of_episodes;
		private long number_of_seasons;
		private List<String> origin_country;
		private String original_name;
		private List<TvSeason> seasons;
		private String type;

		// *********************************** Getters and Setters ********************************************
		public bool IsAdult()
		{
			return isAdult;
		}

		public void setAdult(bool adult)
		{
			isAdult = adult;
		}

		public String getBackdropPath()
		{
			return backdropPath;
		}

		public void setBackdropPath(String backdropPath)
		{
			this.backdropPath = backdropPath;
		}

		public long getCollectionId()
		{
			return collectionId;
		}

		public void setCollectionId(long collectionId)
		{
			this.collectionId = collectionId;
		}

		public long getBudget()
		{
			return budget;
		}

		public void setBudget(long budget)
		{
			this.budget = budget;
		}

		public List<Genre> getGenres()
		{
			return genres;
		}

		public void setGenres(List<Genre> genres)
		{
			this.genres = genres;
		}

		public String getHomepage()
		{
			return homepage;
		}

		public void setHomepage(String homepage)
		{
			this.homepage = homepage;
		}

		public long getId()
		{
			return id;
		}

		public void setId(long id)
		{
			this.id = id;
		}

		public String getMediaType()
		{
			return mediaType;
		}

		public void setMediaType(String mediaType)
		{
			this.mediaType = mediaType;
		}

		public String getImdb_id()
		{
			return imdb_id;
		}

		public void setImdb_id(String imdb_id)
		{
			this.imdb_id = imdb_id;
		}

		public String getOriginal_language()
		{
			return original_language;
		}

		public void setOriginal_language(String original_language)
		{
			this.original_language = original_language;
		}

		public String getOriginal_title()
		{
			return original_title;
		}

		public void setOriginal_title(String original_title)
		{
			this.original_title = original_title;
		}

		public String getOverview()
		{
			return overview;
		}

		public void setOverview(String overview)
		{
			this.overview = overview;
		}

		public double getPopularity()
		{
			return popularity;
		}

		public void setPopularity(double popularity)
		{
			this.popularity = popularity;
		}

		public String getPoster_path()
		{
			return poster_path;
		}

		public void setPoster_path(String poster_path)
		{
			this.poster_path = poster_path;
		}

		public List<ProductionCompany> getProduction_companies()
		{
			return production_companies;
		}

		public void setProduction_companies(List<ProductionCompany> production_companies)
		{
			this.production_companies = production_companies;
		}

		public List<ProductionCountry> getProduction_countries()
		{
			return production_countries;
		}

		public void setProduction_countries(List<ProductionCountry> production_countries)
		{
			this.production_countries = production_countries;
		}

		public String getRelease_date()
		{
			return release_date;
		}

		public void setRelease_date(String release_date)
		{
			this.release_date = release_date;
		}

		public long getRevenue()
		{
			return revenue;
		}

		public void setRevenue(long revenue)
		{
			this.revenue = revenue;
		}

		public long getRuntime()
		{
			return runtime;
		}

		public void setRuntime(long runtime)
		{
			this.runtime = runtime;
		}

		public List<SpokenLanguage> getSpoken_languages()
		{
			return spoken_languages;
		}

		public void setSpoken_languages(List<SpokenLanguage> spoken_languages)
		{
			this.spoken_languages = spoken_languages;
		}

		public String getStatus()
		{
			return status;
		}

		public void setStatus(String status)
		{
			this.status = status;
		}

		public String getTagline()
		{
			return tagline;
		}

		public void setTagline(String tagline)
		{
			this.tagline = tagline;
		}

		public String getTitle()
		{
			return title;
		}

		public void setTitle(String title)
		{
			this.title = title;
		}

		public bool isVideo()
		{
			return video;
		}

		public void setVideo(bool video)
		{
			this.video = video;
		}

		public double getVote_average()
		{
			return vote_average;
		}

		public void setVote_average(double vote_average)
		{
			this.vote_average = vote_average;
		}

		public long getVote_count()
		{
			return vote_count;
		}

		public void setVote_count(long vote_count)
		{
			this.vote_count = vote_count;
		}

		public List<Movie> getPopular()
		{
			return popular;
		}

		public List<Movie> getTop_rated()
		{
			return top_rated;
		}

		public String getCharacter()
		{
			return character;
		}

		public void setCharacter(String character)
		{
			this.character = character;
		}

		public String getCreditId()
		{
			return creditId;
		}

		public void setCreditId(String creditId)
		{
			this.creditId = creditId;
		}

		// Getters and setters specific for TV shows

		public List<Crewman> getCreated_by()
		{
			return created_by;
		}

		public void setCreated_by(List<Crewman> created_by)
		{
			this.created_by = created_by;
		}

        public List<long> getEpisode_run_time()
		{
			return episode_run_time;
		}

        public void setEpisode_run_time(List<long> episode_run_time)
		{
			this.episode_run_time = episode_run_time;
		}

		public String getFirst_air_date()
		{
			return first_air_date;
		}

		public void setFirst_air_date(String first_air_date)
		{
			this.first_air_date = first_air_date;
		}

		public bool isIn_production()
		{
			return in_production;
		}

		public void setIn_production(bool in_production)
		{
			this.in_production = in_production;
		}

		public List<String> getLanguages()
		{
			return languages;
		}

		public void setLanguages(List<String> languages)
		{
			this.languages = languages;
		}

		public String getLast_air_date()
		{
			return last_air_date;
		}

		public void setLast_air_date(String last_air_date)
		{
			this.last_air_date = last_air_date;
		}

		public String getName()
		{
			return name;
		}

		public void setName(String name)
		{
			this.name = name;
		}

		public List<Network> getNetworks()
		{
			return networks;
		}

		public void setNetworks(List<Network> networks)
		{
			this.networks = networks;
		}

		public long getNumber_of_episodes()
		{
			return number_of_episodes;
		}

		public void setNumber_of_episodes(long number_of_episodes)
		{
			this.number_of_episodes = number_of_episodes;
		}

		public long getNumber_of_seasons()
		{
			return number_of_seasons;
		}

		public void setNumber_of_seasons(long number_of_seasons)
		{
			this.number_of_seasons = number_of_seasons;
		}

		public List<String> getOrigin_country()
		{
			return origin_country;
		}

		public void setOrigin_country(List<String> origin_country)
		{
			this.origin_country = origin_country;
		}

		public String getOriginal_name()
		{
			return original_name;
		}

		public void setOriginal_name(String original_name)
		{
			this.original_name = original_name;
		}

		public List<TvSeason> getSeasons()
		{
			return seasons;
		}

		public void setSeasons(List<TvSeason> seasons)
		{
			this.seasons = seasons;
		}

		public String getType()
		{
			return type;
		}

		public void setType(String type)
		{
			this.type = type;
		}

		public String getDepartment()
		{
			return department;
		}

		public void setDepartment(String department)
		{
			this.department = department;
		}

		public String getJob()
		{
			return job;
		}

		public void setJob(String job)
		{
			this.job = job;
		}

		// ******************************** Implement all these methods **********************************

		public Credit getCredit()
		{
			return credit;
		}

		public List<Keyword> getKeywords()
		{
			return keywords;
		}

		public List<Video> getVideos()
		{
			return videos;
		}

		public List<Movie> getRecommendedMovies()
		{
			return recommendedMovies;
		}

		public List<Movie> getSimilarMovies()
		{
			return similardMovies;
		}

		public List<Review> getReviews()
		{
			return reviews;
		}

		public List<MoviesList> getListsMovieBelongsTo()
		{
			return listsMovieBelongsTo;
		}

		public Movie getLatest()
		{
			return latest;
		}

		public List<Movie> getNow_playing()
		{
			return now_playing;
		}

		public List<Movie> getUpcoming()
		{
			return upcoming;
		}

		// ************************************** Service parameters **********************************

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

		public String getMin_date()
		{
			return min_date;
		}

		public void setMin_date(String min_date)
		{
			this.min_date = min_date;
		}

		public String getMax_date()
		{
			return max_date;
		}

		public void setMax_date(String max_date)
		{
			this.max_date = max_date;
		}

        public static implicit operator List<object>(Movie v)
        {
            throw new NotImplementedException();
        }
    }
}
