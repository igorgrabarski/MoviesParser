using System;
using System.Collections.Generic;

namespace ya_move_it_parser_net
{
    public class Tv
    {
		private String backdrop_path;
		private List<Crewman> created_by;
        private List<long> episode_run_time;
		private String first_air_date;
		private List<Genre> genres;
		private String homepage;
		private long id;
		private bool in_production;
		private List<String> languages;
		private String last_air_date;
		private String name;
		private List<Network> networks;
		private long number_of_episodes;
		private long number_of_seasons;
		private List<String> origin_country;
		private String original_language;
		private String original_name;
		private String overview;
		private double popularity;
		private String poster_path;
		private List<ProductionCompany> productionCompanies;
		private List<TvSeason> seasons;
		private String status;
		private String type;
		private double vote_average;
		private long vote_count;

		private Credit credit;
		private List<String> external_ids;
		private List<Keyword> keywords;
		private List<Tv> recommended;
		private List<Tv> similar;
		private List<Video> videos;
		private List<Tv> latest;
		private List<Tv> airing_today;
		private List<Tv> on_the_air;
		private List<Tv> popular;
		private List<Tv> top_rated;

		// Used in combined object in credits for person
		private String character;
		private String creditId;
		private String department;
		private String job;

		private long page;
		private long total_results;
		private long total_pages;
		private String min_date;
		private String max_date;



		// *********************************** Getters and Setters ********************************************

		public String getBackdrop_path()
		{
			return backdrop_path;
		}

		public void setBackdrop_path(String backdrop_path)
		{
			this.backdrop_path = backdrop_path;
		}

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

		public String getOriginal_language()
		{
			return original_language;
		}

		public void setOriginal_language(String original_language)
		{
			this.original_language = original_language;
		}

		public String getOriginal_name()
		{
			return original_name;
		}

		public void setOriginal_name(String original_name)
		{
			this.original_name = original_name;
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

		public List<ProductionCompany> getProductionCompanies()
		{
			return productionCompanies;
		}

		public void setProductionCompanies(List<ProductionCompany> productionCompanies)
		{
			this.productionCompanies = productionCompanies;
		}

		public List<TvSeason> getSeasons()
		{
			return seasons;
		}

		public void setSeasons(List<TvSeason> seasons)
		{
			this.seasons = seasons;
		}

		public String getStatus()
		{
			return status;
		}

		public void setStatus(String status)
		{
			this.status = status;
		}

		public String getType()
		{
			return type;
		}

		public void setType(String type)
		{
			this.type = type;
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

		public List<String> getExternal_ids()
		{
			return external_ids;
		}

		public List<Keyword> getKeywords()
		{
			return keywords;
		}

		public List<Tv> getRecommended()
		{
			return recommended;
		}

		public List<Tv> getSimilar()
		{
			return similar;
		}

		public List<Video> getVideos()
		{
			return videos;
		}

		public List<Tv> getLatest()
		{
			return latest;
		}

		public List<Tv> getAiring_today()
		{
			return airing_today;
		}

		public List<Tv> getOn_the_air()
		{
			return on_the_air;
		}

		public List<Tv> getPopular()
		{
			return popular;
		}

		public List<Tv> getTop_rated()
		{
			return top_rated;
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
    }
}
