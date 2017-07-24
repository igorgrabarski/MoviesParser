package com.igorgrabarski;

import java.util.List;

/**
 * Created by igorgrabarski on 2017-06-09.
 */
public class Credit {


    private List<Actor> cast;
    private List<Crewman> crew;

    public List<Actor> getCast() {
        return cast;
    }

    public void setCast(List<Actor> cast) {
        this.cast = cast;
    }

    public List<Crewman> getCrew() {
        return crew;
    }

    public void setCrew(List<Crewman> crew) {
        this.crew = crew;
    }
}
