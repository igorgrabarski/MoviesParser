package com.igorgrabarski;

import java.util.List;

/**
 * Created by igorgrabarski on 2017-06-09.
 */
public class TvEpisode{

    private List<Crewman> crew;
    private String air_date;
    private long episode_number;
    private List<Actor> guest_stars;
    private String name;
    private String overview;
    private long id;
    private double production_code;
    private long season_number;
    private String still_path;
    private double vote_average;
    private long vote_count;

    public List<Crewman> getCrew() {
        return crew;
    }

    public void setCrew(List<Crewman> crew) {
        this.crew = crew;
    }

    public String getAir_date() {
        return air_date;
    }

    public void setAir_date(String air_date) {
        this.air_date = air_date;
    }

    public long getEpisode_number() {
        return episode_number;
    }

    public void setEpisode_number(long episode_number) {
        this.episode_number = episode_number;
    }

    public List<Actor> getGuest_stars() {
        return guest_stars;
    }

    public void setGuest_stars(List<Actor> guest_stars) {
        this.guest_stars = guest_stars;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getOverview() {
        return overview;
    }

    public void setOverview(String overview) {
        this.overview = overview;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public double getProduction_code() {
        return production_code;
    }

    public void setProduction_code(double production_code) {
        this.production_code = production_code;
    }

    public long getSeason_number() {
        return season_number;
    }

    public void setSeason_number(long season_number) {
        this.season_number = season_number;
    }

    public String getStill_path() {
        return still_path;
    }

    public void setStill_path(String still_path) {
        this.still_path = still_path;
    }

    public double getVote_average() {
        return vote_average;
    }

    public void setVote_average(double vote_average) {
        this.vote_average = vote_average;
    }

    public long getVote_count() {
        return vote_count;
    }

    public void setVote_count(long vote_count) {
        this.vote_count = vote_count;
    }
}
