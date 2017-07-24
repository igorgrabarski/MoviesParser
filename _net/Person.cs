using System;
using System.Collections.Generic;

namespace ya_move_it_parser_net
{
    public class Person
    {
		private bool isAdult;
		private List<String> also_known_as;
		private List<Movie> known_for;
		private String biography;
		private String birthday;
		private String deathday;
		private int gender;
		private String homepage;
		private long id;
		private String imdb_id;
		private String name;
		private String place_of_birth;
		private double popularity;
		private String profile_path;
		private String mediaType;

		private Credit movie_credit;
		private Credit tv_credit;
		private Credit combined_credit;
		private List<String> external_ids;
		private Person latest;
		private List<Person> popular;

		private long page;
		private long total_results;
		private long total_pages;


		public bool IsAdult()
		{
			return isAdult;
		}

		public void setAdult(bool adult)
		{
			isAdult = adult;
		}

		public List<String> getAlso_known_as()
		{
			return also_known_as;
		}

		public void setAlso_known_as(List<String> also_known_as)
		{
			this.also_known_as = also_known_as;
		}

		public List<Movie> getKnown_for()
		{
			return known_for;
		}

		public void setKnown_for(List<Movie> known_for)
		{
			this.known_for = known_for;
		}

		public String getBiography()
		{
			return biography;
		}

		public void setBiography(String biography)
		{
			this.biography = biography;
		}

		public String getBirthday()
		{
			return birthday;
		}

		public void setBirthday(String birthday)
		{
			this.birthday = birthday;
		}

		public String getDeathday()
		{
			return deathday;
		}

		public void setDeathday(String deathday)
		{
			this.deathday = deathday;
		}

		public int getGender()
		{
			return gender;
		}

		public void setGender(int gender)
		{
			this.gender = gender;
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

		public String getImdb_id()
		{
			return imdb_id;
		}

		public void setImdb_id(String imdb_id)
		{
			this.imdb_id = imdb_id;
		}

		public String getName()
		{
			return name;
		}

		public void setName(String name)
		{
			this.name = name;
		}

		public String getPlace_of_birth()
		{
			return place_of_birth;
		}

		public void setPlace_of_birth(String place_of_birth)
		{
			this.place_of_birth = place_of_birth;
		}

		public double getPopularity()
		{
			return popularity;
		}

		public void setPopularity(double popularity)
		{
			this.popularity = popularity;
		}

		public String getProfile_path()
		{
			return profile_path;
		}

		public void setProfile_path(String profile_path)
		{
			this.profile_path = profile_path;
		}


		public Credit getMovie_credit()
		{
			return movie_credit;
		}

		public Credit getTv_credit()
		{
			return tv_credit;
		}

		public Credit getCombined_credit()
		{
			return combined_credit;
		}

		public List<String> getExternal_ids()
		{
			return external_ids;
		}

		public Person getLatest()
		{
			return latest;
		}

		public List<Person> getPopular()
		{
			return popular;
		}

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

		public String getMediaType()
		{
			return mediaType;
		}

		public void setMediaType(String mediaType)
		{
			this.mediaType = mediaType;
		}
    }
}
