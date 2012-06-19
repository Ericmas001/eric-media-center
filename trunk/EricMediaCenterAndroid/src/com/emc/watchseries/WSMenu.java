package com.emc.watchseries;

import java.net.URLEncoder;

import org.json.JSONArray;
import org.json.JSONException;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.SearchView;
import android.widget.Toast;

import com.emc.R;
import com.emc.util.ContactWebservice;
import com.emc.util.PrefUtil;

public class WSMenu implements SearchView.OnQueryTextListener
{

    static String[] letters = null;
    static String[] genres = null;
    Activity m_activity;
    ProgressDialog dialog;

    public WSMenu(Activity activity)
    {
        m_activity = activity;
    }

    public void inflateMenu(Menu menu)
    {
        MenuInflater inflater = m_activity.getMenuInflater();
        inflater.inflate(R.menu.watchseriesmenu, menu);
        ((SearchView) menu.findItem(R.id.ws_menu_search).getActionView()).setOnQueryTextListener(this);

        if (PrefUtil.getBool("isAGuest", false))
            menu.removeItem(R.id.ws_menu_disconnect);
        else
            menu.removeItem(R.id.ws_menu_connect);
    }

    public void performMenuItem(MenuItem item)
    {
        switch (item.getItemId())
        {
            case R.id.ws_menu_bpop:
                fetchList("http://emc.ericmas001.com/WatchSeries/GetPopulars");
                break;
            case R.id.ws_menu_bletter:
                pickALetter();
                break;
            case R.id.ws_menu_bgenre:
                pickAGenre();
                break;
            case R.id.ws_menu_connect:
            case R.id.ws_menu_disconnect:
                PrefUtil.set("isAGuest", false);
                Intent intent = new Intent();
                intent.setClass(m_activity, WSLoginActivity.class);
                m_activity.startActivity(intent);
                break;
        }
    }

    public void pickALetter()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(m_activity);
        builder.setTitle("Pick a letter");
        final String[] items = getLetters();
        if (items != null && items.length > 0)
        {
            builder.setItems(items, new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int item)
                {
                    fetchList("http://emc.ericmas001.com/WatchSeries/GetLetter/" + items[item]);
                }
            });
            AlertDialog alert = builder.create();
            alert.show();
        }
    }

    public String[] getLetters()
    {
        if (WSMenu.letters == null)
        {
            dialog = new ProgressDialog(m_activity);
            dialog.setCancelable(false);
            dialog.setMessage("Getting Letters ...");
            dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
            dialog.show();
            ContactWebservice.CallWS(m_activity, "onPostExecuteLetters", "http://emc.ericmas001.com/WatchSeries/AvailableLetters", this);
        }
        return WSMenu.letters;
    }

    public void onPostExecuteLetters(String result, Exception exception)
    {
        if (result != null)
        {
            JSONArray json;
            try
            {
                json = new JSONArray(result);
                WSMenu.letters = new String[json.length()];
                for (int i = 0; i < json.length(); ++i)
                {
                    WSMenu.letters[i] = json.getString(i);
                }
            }
            catch (JSONException e)
            {
                Toast.makeText(m_activity, e.toString(), Toast.LENGTH_LONG).show();
            }
        }
        else
            Toast.makeText(m_activity, exception.toString(), Toast.LENGTH_LONG).show();
        dialog.cancel();
        pickALetter();
    }

    public void pickAGenre()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(m_activity);
        builder.setTitle("Pick a genre");
        final String[] items = getGenres();
        if (items != null && items.length > 0)
        {
            builder.setItems(items, new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int item)
                {
                    fetchList("http://emc.ericmas001.com/WatchSeries/GetGenre/" + items[item]);
                }
            });
            AlertDialog alert = builder.create();
            alert.show();
        }
    }

    public String[] getGenres()
    {
        if (WSMenu.genres == null)
        {
            dialog = new ProgressDialog(m_activity);
            dialog.setCancelable(false);
            dialog.setMessage("Getting Genres ...");
            dialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
            dialog.show();
            ContactWebservice.CallWS(m_activity, "onPostExecuteGenres", "http://emc.ericmas001.com/WatchSeries/AvailableGenres", this);
        }
        return WSMenu.genres;
    }

    public void onPostExecuteGenres(String result, Exception exception)
    {
        if (result != null)
        {
            JSONArray json;
            try
            {
                json = new JSONArray(result);
                WSMenu.genres = new String[json.length()];
                for (int i = 0; i < json.length(); ++i)
                {
                    WSMenu.genres[i] = json.getString(i);
                }
            }
            catch (JSONException e)
            {
                Toast.makeText(m_activity, e.toString(), Toast.LENGTH_LONG).show();
            }
        }
        else
            Toast.makeText(m_activity, exception.toString(), Toast.LENGTH_LONG).show();
        dialog.cancel();
        pickAGenre();
    }

    public boolean onQueryTextSubmit(String query)
    {
        if (query.length() > 0)
            fetchList("http://emc.ericmas001.com/WatchSeries/Search/" + URLEncoder.encode(query.trim()).replace("+", "%20"));
        return true;
    }

    public boolean onQueryTextChange(String newText)
    {
        // TODO Auto-generated method stub
        return true;
    }

    public void fetchList(String url)
    {
        if (m_activity.getClass() == WSSelectSerieActivity.class)
            ((WSSelectSerieActivity) m_activity).populate(url);
        else
        {
            Intent intent = new Intent();
            intent.setClass(m_activity, WSSelectSerieActivity.class);
            Bundle b = new Bundle();
            b.putString("url", url);
            intent.putExtras(b);
            m_activity.startActivity(intent);
        }
    }
}