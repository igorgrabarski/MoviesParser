package com.igorgrabarski;

/**
 * Created by igorgrabarski on 2017-06-09.
 */
public class MoviesList {

    private String description;
    private long favourite_count;
    private long id;
    private long item_count;
    private String iso_639_1;
    private String list_type;
    private String name;
    private String poster_path;

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public long getFavourite_count() {
        return favourite_count;
    }

    public void setFavourite_count(long favourite_count) {
        this.favourite_count = favourite_count;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public long getItem_count() {
        return item_count;
    }

    public void setItem_count(long item_count) {
        this.item_count = item_count;
    }

    public String getIso_639_1() {
        return iso_639_1;
    }

    public void setIso_639_1(String iso_639_1) {
        this.iso_639_1 = iso_639_1;
    }

    public String getList_type() {
        return list_type;
    }

    public void setList_type(String list_type) {
        this.list_type = list_type;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPoster_path() {
        return poster_path;
    }

    public void setPoster_path(String poster_path) {
        this.poster_path = poster_path;
    }
}
