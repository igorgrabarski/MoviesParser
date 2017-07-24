package com.igorgrabarski;

import java.util.List;

/**
 * Created by igorgrabarski on 2017-06-09.
 */
public class TvSeason {

    private String _id;
    private String air_date;
    private long episode_count;
    private long id;
    private String poster_path;
    private long season_number;
    private String name;
    private String overview;
    private List<TvEpisode> episodes;

    public String get_id() {
        return _id;
    }

    public void set_id(String _id) {
        this._id = _id;
    }

    public String getAir_date() {
        return air_date;
    }

    public void setAir_date(String air_date) {
        this.air_date = air_date;
    }

    public long getEpisode_count() {
        return episode_count;
    }

    public void setEpisode_count(long episode_count) {
        this.episode_count = episode_count;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getPoster_path() {
        return poster_path;
    }

    public void setPoster_path(String poster_path) {
        this.poster_path = poster_path;
    }

    public long getSeason_number() {
        return season_number;
    }

    public void setSeason_number(long season_number) {
        this.season_number = season_number;
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

    public List<TvEpisode> getEpisodes() {
        return episodes;
    }

    public void setEpisodes(List<TvEpisode> episodes) {
        this.episodes = episodes;
    }
}
