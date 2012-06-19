package com.emc.util;

import android.content.SharedPreferences;

import com.emc.EMCApplication;

public class PrefUtil
{
    public static String getString(String pref, String defaultValue)
    {
        SharedPreferences settings = EMCApplication.getContext().getSharedPreferences("global", 0);
        return settings.getString(pref, defaultValue);
    }

    public static boolean getBool(String pref, boolean defaultValue)
    {
        SharedPreferences settings = EMCApplication.getContext().getSharedPreferences("global", 0);
        return settings.getBoolean(pref, defaultValue);
    }

    public static void set(String pref, String value)
    {
        SharedPreferences settings = EMCApplication.getContext().getSharedPreferences("global", 0);
        SharedPreferences.Editor editor = settings.edit();
        editor.putString(pref, value);
        editor.commit();
    }

    public static void set(String pref, boolean value)
    {
        SharedPreferences settings = EMCApplication.getContext().getSharedPreferences("global", 0);
        SharedPreferences.Editor editor = settings.edit();
        editor.putBoolean(pref, value);
        editor.commit();
    }
}
