package com.igorgrabarski;

/**
 * Created by igorgrabarski on 2017-06-09.
 */
public enum Gender {

    MALE(2),
    FEMALE(1),
    UNDEFINED(0);

    int value;

    Gender(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }

}
